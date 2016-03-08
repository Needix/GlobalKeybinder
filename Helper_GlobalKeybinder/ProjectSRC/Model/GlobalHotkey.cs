using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Controller;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class GlobalHotkey {
        /*
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        */

        [DllImport("user32.dll")]
        static extern short VkKeyScan(char ch);
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        public int Modifier { get; private set; } //The "list" of modifiers
        public int Key { get; private set; } //VK_ variant of the Key

        public List<int> Keys { get; private set; } //THE VK_ bytes of the Text
        public string Text { get; set; }

        public IntPtr HWnd { get; private set; } 
        public int Id { get; private set; }

        [StructLayout(LayoutKind.Explicit)]
        struct Helper {
            [FieldOffset(0)]
            public short Value;
            [FieldOffset(0)]
            public byte Low;
            [FieldOffset(1)]
            public byte High;
        }

        /// <summary>
        /// "Text" Hotkey
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="form"></param>
        public GlobalHotkey(char[] chars, Form form) {
            Modifier = Constants.NOMOD;
            Text = string.Concat(chars);
            Keys = new List<int>();
            foreach(char c in chars) {
                Keys.Add((int)GetVKFromChar(c));
            }
            this.HWnd = form.Handle;
            Id = this.GetHashCode();
        }
        /// <summary>
        /// Single character hotkey with modifier
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        /// <param name="form"></param>
        public GlobalHotkey(int modifier, char key, Form form) {
            this.Modifier = modifier;
            this.Key = (int)GetVKFromChar(key);
            this.HWnd = form.Handle;
            Id = this.GetHashCode();
        }
        
        /*
        /// <summary>
        /// Registers this hotkey globally
        /// </summary>
        /// <returns>true, if successful, else false</returns>
        public bool Register() {
            Debug.WriteLine("Registering "+this);
            // setup a keyboard hook
            return _hook != IntPtr.Zero;
            //return RegisterHotKey(HWnd, Id, Modifier, Key);
        }

        /// <summary>
        /// Unregisters this hotkey
        /// </summary>
        /// <returns>true, if successful, else false</returns>
        public bool Unregister() {
            Debug.WriteLine("Unregistering " + this);
            if(_hook == IntPtr.Zero) return false;
            UnhookWindowsHookEx(_hook);
            return true;
            //return UnregisterHotKey(HWnd, Id);
        }
        */

        /// <summary>
        /// Checks if the given key with the given mods, matches this hotkey
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <param name="mods">The modifier of the key</param>
        /// <returns>true, if the key and modifier matches this hotkey, else false</returns>
        public bool Matches(int vk_code, List<int> mods) {
            if(vk_code != Key) return false;

            List<int> thisMods = GetModifiers(Modifier);
            if(mods.Count != thisMods.Count) return false;
            foreach(int thisMod in thisMods) {
                if(!mods.Contains(thisMod)) return false;
            }
            return true;
        }

        /// <summary>
        /// Sends the outputsequence to the process with the name "exename"
        /// </summary>
        /// <param name="exeName">The process where the sequence should be send to</param>
        /// <param name="seq">The OutputSequence to send</param>
        public void SendToProcess(string exeName, OutputSequence seq) {
            IntPtr handle = SearchWindowHandle(exeName);
            if(handle == IntPtr.Zero) {
                Debug.WriteLine("Could not find process: " + exeName);
                return;
            }
            Debug.WriteLine("Sending char sequence to: " + exeName);

            foreach(GlobalHotkey c in seq.Sequence) {
                if(c.Keys == null) {
                    byte key = GetVKFromChar((char) c.Key);
                    List<int> mod = GetModifiers(c.Modifier);
                    bool shift = false;
                    bool alt = false;
                    bool ctrl = false;
                    if(mod.Contains(Constants.ALT)) alt = true;
                    if(mod.Contains(Constants.CTRL)) ctrl = true;
                    if(mod.Contains(Constants.SHIFT)) shift = true;

                    Debug.WriteLine("Sending \"" + ((char)c.Key) + "\" with mods: \"CTRL:"+ctrl+" / ALT:"+alt+" / SHIFT:"+shift+"\" to " + exeName);
                    SendKeyToHandle(handle, key, shift, alt, ctrl);
                } else {
                    Debug.WriteLine("Sending text: \""+c.Text + "\" to "+exeName);
                    foreach(int key in c.Keys) {
                        Debug.WriteLine("Sending \"" + c.Key + "\"/\"" + key + "\" to " + exeName);
                        SendKeyToHandle(handle, key, false, false, false);
                    }  
                }
            }
        }
        private IntPtr SearchWindowHandle(string exeName) {
            Process[] processes = Process.GetProcessesByName(exeName);
            foreach(Process proc in processes) if(proc.ProcessName == exeName) return proc.MainWindowHandle;
            return IntPtr.Zero;
        }
        private void SendKeyToHandle(IntPtr windowHandle, int key, bool shift, bool alt, bool ctrl) {
            /*
            if(ctrl) PostMessage(windowHandle, Constants.WM_SYSKEYDOWN, Constants.VK_CONTROL, 0x0);
            if(shift) PostMessage(windowHandle, Constants.WM_SYSKEYDOWN, Constants.VK_SHIFT, 0x0);
            if(alt) PostMessage(windowHandle, Constants.WM_SYSKEYDOWN, Constants.VK_ALT, 0x0);
            */
            Debug.WriteLine("Sending byte: "+key);
            PostMessage(windowHandle, Constants.WM_KEYDOWN, key, 0);
            /*
            Thread.Sleep(10);
            PostMessage(windowHandle, Constants.WM_KEYUP, key, 0);
            if(alt) PostMessage(windowHandle, Constants.WM_SYSKEYUP, Constants.VK_ALT, 0x0);
            if(shift) PostMessage(windowHandle, Constants.WM_SYSKEYUP, Constants.VK_SHIFT, 0x0);
            if(ctrl) PostMessage(windowHandle, Constants.WM_SYSKEYUP, Constants.VK_CONTROL, 0x0);
            */
        }

        /// <summary>
        /// Transforms this char into the VirtualKey byte
        /// </summary>
        /// <param name="c">The char to transform</param>
        /// <returns>The Virtual Key Byte</returns>
        public static byte GetVKFromChar(char c) {
            var helper = new Helper { Value = VkKeyScan(c) };

            byte virtualKeyCode = helper.Low;
            byte shiftState = helper.High;
            return virtualKeyCode;

            /*
            Debug.WriteLine("{0}|{1}", virtualKeyCode, (Keys)virtualKeyCode);
            Debug.WriteLine("SHIFT pressed: {0}", (shiftState & 1) != 0);
            Debug.WriteLine("CTRL pressed: {0}", (shiftState & 2) != 0);
            Debug.WriteLine("ALT pressed: {0}", (shiftState & 4) != 0);

            Keys Key = (Keys)virtualKeyCode;

            Key |= (shiftState & 1) != 0 ? Keys.Shift : Keys.None;
            Key |= (shiftState & 2) != 0 ? Keys.Control : Keys.None;
            Key |= (shiftState & 4) != 0 ? Keys.Alt : Keys.None;

            Debug.WriteLine("Pressing Key: " + Key);
            Debug.WriteLine("Pressing Key: " + new KeysConverter().ConvertToString(Key));
            Debug.WriteLine("");
            */
        }
        public static List<int> GetModifiers(int mod) {
            List<int> resultList = new List<int>();
            if((mod & Constants.CTRL) == Constants.CTRL) resultList.Add(Constants.CTRL);
            if((mod & Constants.ALT) == Constants.ALT) resultList.Add(Constants.ALT);
            if((mod & Constants.SHIFT) == Constants.SHIFT) resultList.Add(Constants.SHIFT);
            return resultList;
        }
        public static int CalcModifier(bool shift, bool alt, bool ctrl) {
            int result = Constants.NOMOD;
            if(shift) result += Constants.SHIFT;
            if(alt) result += Constants.ALT;
            if(ctrl) result += Constants.CTRL;
            return result;
        }

        /// <summary>
        /// Formats the InputSequence in this format: (e.g. "CTRL + ALT + B")
        /// </summary>
        /// <returns>The input sequence in the said format</returns>
        public override string ToString() {
            string result = "";
            if(Keys == null) {
                List<string> resultList = new List<string>();
                if((Modifier & Constants.CTRL) == Constants.CTRL) resultList.Add("CTRL");
                if((Modifier & Constants.ALT) == Constants.ALT) resultList.Add("ALT");
                if((Modifier & Constants.SHIFT) == Constants.SHIFT) resultList.Add("SHIFT");
                string charString = new KeysConverter().ConvertToString(Key);
                resultList.Add(charString);
                foreach(string s in resultList) {
                    result += s + " ";
                    if(s != charString) result += "+ ";
                }
            } else {
                result = Text;
            }
            return result.Trim();
        }

        public override int GetHashCode() {
            return Modifier ^ Key ^ HWnd.ToInt32();
        }
    }
}