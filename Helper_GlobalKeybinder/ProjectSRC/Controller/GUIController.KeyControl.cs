using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Model;
using SlimDX.DirectInput;
using SlimDX.Multimedia;
using SlimDX.RawInput;
using DeviceFlags = SlimDX.DirectInput.DeviceFlags;

namespace Helper_GlobalKeybinder.ProjectSRC.Controller {
    public partial class GUIController {
        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private readonly KeysConverter _kc = new KeysConverter();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType code, HookProc func, IntPtr hInstance, int threadID);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey); // Keys enumeration
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);
        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);
        enum VirtualKeyStates : int {
            VK_LBUTTON = 0x01,
            VK_RBUTTON = 0x02,
            VK_CANCEL = 0x03,
            VK_MBUTTON = 0x04,
            //
            VK_XBUTTON1 = 0x05,
            VK_XBUTTON2 = 0x06,
            //
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            //
            VK_CLEAR = 0x0C,
            VK_RETURN = 0x0D,
            //
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12,
            VK_PAUSE = 0x13,
            VK_CAPITAL = 0x14,
            //
            VK_KANA = 0x15,
            VK_HANGEUL = 0x15,  /* old name - should be here for compatibility */
            VK_HANGUL = 0x15,
            VK_JUNJA = 0x17,
            VK_FINAL = 0x18,
            VK_HANJA = 0x19,
            VK_KANJI = 0x19,
            //
            VK_ESCAPE = 0x1B,
            //
            VK_CONVERT = 0x1C,
            VK_NONCONVERT = 0x1D,
            VK_ACCEPT = 0x1E,
            VK_MODECHANGE = 0x1F,
            //
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_PRINT = 0x2A,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,
            //
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_APPS = 0x5D,
            //
            VK_SLEEP = 0x5F,
            //
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_F13 = 0x7C,
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87,
            //
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            //
            VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
                                       //
            VK_OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
            VK_OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
            VK_OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
            VK_OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
            VK_OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key
                                     //
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5,
            //
            VK_BROWSER_BACK = 0xA6,
            VK_BROWSER_FORWARD = 0xA7,
            VK_BROWSER_REFRESH = 0xA8,
            VK_BROWSER_STOP = 0xA9,
            VK_BROWSER_SEARCH = 0xAA,
            VK_BROWSER_FAVORITES = 0xAB,
            VK_BROWSER_HOME = 0xAC,
            //
            VK_VOLUME_MUTE = 0xAD,
            VK_VOLUME_DOWN = 0xAE,
            VK_VOLUME_UP = 0xAF,
            VK_MEDIA_NEXT_TRACK = 0xB0,
            VK_MEDIA_PREV_TRACK = 0xB1,
            VK_MEDIA_STOP = 0xB2,
            VK_MEDIA_PLAY_PAUSE = 0xB3,
            VK_LAUNCH_MAIL = 0xB4,
            VK_LAUNCH_MEDIA_SELECT = 0xB5,
            VK_LAUNCH_APP1 = 0xB6,
            VK_LAUNCH_APP2 = 0xB7,
            //
            VK_OEM_1 = 0xBA,   // ';:' for US
            VK_OEM_PLUS = 0xBB,   // '+' any country
            VK_OEM_COMMA = 0xBC,   // ',' any country
            VK_OEM_MINUS = 0xBD,   // '-' any country
            VK_OEM_PERIOD = 0xBE,   // '.' any country
            VK_OEM_2 = 0xBF,   // '/?' for US
            VK_OEM_3 = 0xC0,   // '`~' for US
                               //
            VK_OEM_4 = 0xDB,  //  '[{' for US
            VK_OEM_5 = 0xDC,  //  '\|' for US
            VK_OEM_6 = 0xDD,  //  ']}' for US
            VK_OEM_7 = 0xDE,  //  ''"' for US
            VK_OEM_8 = 0xDF,
            //
            VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
            VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
            VK_ICO_HELP = 0xE3,  //  Help key on ICO
            VK_ICO_00 = 0xE4,  //  00 key on ICO
                               //
            VK_PROCESSKEY = 0xE5,
            //
            VK_ICO_CLEAR = 0xE6,
            //
            VK_PACKET = 0xE7,
            //
            VK_OEM_RESET = 0xE9,
            VK_OEM_JUMP = 0xEA,
            VK_OEM_PA1 = 0xEB,
            VK_OEM_PA2 = 0xEC,
            VK_OEM_PA3 = 0xED,
            VK_OEM_WSCTRL = 0xEE,
            VK_OEM_CUSEL = 0xEF,
            VK_OEM_ATTN = 0xF0,
            VK_OEM_FINISH = 0xF1,
            VK_OEM_COPY = 0xF2,
            VK_OEM_AUTO = 0xF3,
            VK_OEM_ENLW = 0xF4,
            VK_OEM_BACKTAB = 0xF5,
            //
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE
        }


        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);
        [DllImport("user32.dll")]
        static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        [DllImport("user32.dll")]
        static extern bool TranslateMessage([In] ref MSG lpMsg);
        [DllImport("user32.dll")]
        static extern IntPtr DispatchMessage([In] ref MSG lpmsg);
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG {
            public IntPtr hwnd;
            public UInt32 message;
            public IntPtr wParam;
            public IntPtr lParam;
            public UInt32 time;
            public POINT pt;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT {
            public int X;
            public int Y;

            public POINT(int x, int y) {
                this.X = x;
                this.Y = y;
            }

            public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }

            public static implicit operator System.Drawing.Point(POINT p) {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p) {
                return new POINT(p.X, p.Y);
            }
        }

        public enum HookType : int {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT {
            public uint vkCode;
            public uint scanCode;
            public KBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [Flags]
        public enum KBDLLHOOKSTRUCTFlags : uint {
            LLKHF_EXTENDED = 0x01,
            LLKHF_INJECTED = 0x10,
            LLKHF_ALTDOWN = 0x20,
            LLKHF_UP = 0x80,
        }

        public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
        private HookProc _keyPressedDelegate = null;
        private IntPtr _hook = IntPtr.Zero;

        private readonly Thread _handleHotkeyMessageThread;
        private bool _stop = false;

        private byte[] _keyState = new byte[256];

        private bool _menuDown = false;
        private bool _ctrlDown = false;
        private bool _shiftDown = false;

        private Keyboard _keyboard;
        private DirectInput _dInput = new DirectInput();

        private void Run() {
            if(!InitDevices()) return;
            while(!_stop) {
                //OldKeyboardCheck();
                //OldKeyboardCheck2();
                Thread.Sleep(10);
            }
        }

	   private void Device_MouseInput(object sender, MouseInputEventArgs e) {
	       Debug.WriteLine("Mouse: "+e.X+"/"+e.Y);
        }

        private void Device_KeyboardInput(object sender, KeyboardInputEventArgs e) {
            Debug.WriteLine("Key: "+e.Key);
        }

        private bool InitDevices() {
            bool success = true;
            /*
            Debug.WriteLine("Trying to init devices...");
            while(!View.IsHandleCreated) { Thread.Sleep(100); }
            View.Invoke((MethodInvoker) delegate {
                Debug.WriteLine("Invoking started");
                try {
                    _keyboard = new Keyboard(_dInput);
                    _keyboard.SetCooperativeLevel(View.Handle, CooperativeLevel.Nonexclusive | CooperativeLevel.Background);
                } catch(DirectInputException e) {
                    MessageBox.Show(e.Message);
                    success = false;
                }
                _keyboard.Acquire();
                Debug.WriteLine("Invoking done");
            });
            Debug.WriteLine("Returning success: "+success);
            */

            IList<DeviceInstance> instances = _dInput.GetDevices(DeviceClass.Keyboard, DeviceEnumerationFlags.AllDevices);
            Debug.WriteLine("DeviceCount: " + instances);
            foreach (DeviceInstance deviceInstance in instances) {
                Debug.WriteLine("Dev: " + deviceInstance.InstanceName + " / " + deviceInstance.ProductName);
            }

            SlimDX.RawInput.Device.RegisterDevice(UsagePage.Keyboard, UsageId.KeyboardaA, SlimDX.RawInput.DeviceFlags.None);
            SlimDX.RawInput.Device.RegisterDevice(UsagePage.Generic, UsageId.Mouse, SlimDX.RawInput.DeviceFlags.None);

            SlimDX.RawInput.Device.KeyboardInput += Device_KeyboardInput;
            SlimDX.RawInput.Device.MouseInput += Device_MouseInput;
            return success;
        }

        string keyBuffer = string.Empty;
        private void OldKeyboardCheck() {
            GetKeyState(VirtualKeyStates.VK_LEFT);
            GetKeyboardState(_keyState);
            for(int i = 0; i < _keyState.Length; i++) {
                byte state = _keyState[i];
                if((state & 0x80) != 0) {
                    keyBuffer += Enum.GetName(typeof(Keys), i) + " "; //this is WinAPI listener of the keys
                    //Logical 'and' so we can drop the low-order bit for toggled keys, else that key will appear with the value 1!
                }
            }
            if(keyBuffer!="") Debug.WriteLine(keyBuffer);

            keyBuffer = "";
        }

        /*
        private void OldKeyboardCheck2() {
            KeyboardState state = _keyboard.GetCurrentState();
            IList<Key> keys = state.PressedKeys;
            bool ctrl = false;
            bool alt = false;
            bool shift = false;
            if(keys.Contains(Key.LeftControl) || keys.Contains(Key.RightControl)) ctrl = true;
            if(keys.Contains(Key.LeftAlt) || keys.Contains(Key.RightAlt)) alt = true;
            if(keys.Contains(Key.LeftShift) || keys.Contains(Key.RightShift)) shift = true;
            ModCollection mods = GlobalHotkey.GetModifiers(GlobalHotkey.CalcModifier(shift, alt, ctrl));

            string keysBuilder = "";
            foreach(Key key in keys) {
                if(key == Key.LeftControl || key == Key.RightControl || 
                    key == Key.LeftAlt || key == Key.RightAlt ||
                    key == Key.LeftShift || key == Key.RightShift) continue;

                Keys translatedKey = GlobalHotkey.TranslateSlimDXKey(key);

                keysBuilder += (key+"/"+translatedKey+"  ");
                //HandleHotkeys(translatedKey, mods);
            }
            if(keysBuilder!="") Debug.WriteLine(keysBuilder);
        }
        */

        private void HandleHotkeys(Keys key, List<int> mods) {
            foreach(ProgramProfile program in Model.Programs) {
                if(!program.Enabled) continue;
                foreach(Keybind keybind in program.Keybinds) {
                    if(!keybind.Enabled) continue;
                    GlobalHotkey globalHotkey = keybind.InputSequence;
                    Debug.WriteLine("Trying to match " + key + " / " + ((int)key) + " with " + globalHotkey.Key);
                    if(globalHotkey.Matches(GlobalHotkey.GetVKFromChar((char)key), mods)) {
                        Debug.WriteLine("Matched! Sending...");
                        globalHotkey.SendToProcess(program.Name, keybind.OutputSequence);
                        //TODO: Add timeout to hotkey
                    }
                }
            }
        }

        /* HandleHotkey
        public IntPtr HandleHotkey(int code, IntPtr wParam, IntPtr lParam) {
            if(code < 0) {
                //you need to call CallNextHookEx without further processing
                //and return the value returned by CallNextHookEx
                Debug.WriteLine("Key pressed but code is < 0!");
                return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
            }
            // we can convert the 2nd parameter (the key code) to a System.Windows.Forms.Keys enum constant
            KBDLLHOOKSTRUCT kbd = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
            int vkCode = (int)kbd.vkCode;

            //Keys key = (Keys)(((int)lParam >> 16) & 0xFFFF);
            //int modifier = (int)lParam & 0xFFFF;
            //List<int> mods = GlobalHotkey.GetModifiers(modifier);

            bool keyDown = false;
            bool modKey = true;
            switch((int)wParam) {
                case Constants.WM_SYSKEYDOWN:
                case Constants.WM_KEYDOWN:
                    if(Constants.IsControlKey(vkCode)) _ctrlDown = true;
                    else if(Constants.IsAltKey(vkCode)) _menuDown = true;
                    else if(Constants.IsShiftKey(vkCode)) _shiftDown = true;
                    else modKey = false;
                    keyDown = true;
                    break;
                case Constants.WM_SYSKEYUP:
                case Constants.WM_KEYUP:
                    if(Constants.IsControlKey(vkCode)) _ctrlDown = false;
                    else if(Constants.IsAltKey(vkCode)) _menuDown = false;
                    else if(Constants.IsShiftKey(vkCode)) _shiftDown = false;
                    else modKey = false;
                    break;
            }
            if(!modKey && keyDown) {
                List<int> mods = GlobalHotkey.GetModifiers(GlobalHotkey.CalcModifier(_shiftDown, _menuDown, _ctrlDown));

                Debug.WriteLine("Searching programs for keybind...");
                foreach(ProgramProfile program in Model.Programs) {
                    Debug.WriteLine("Searching \"" + program.Name + "\" Enabled?: " + program.Enabled);
                    if(!program.Enabled) continue;
                    foreach(Keybind keybind in program.Keybinds) {
                        Debug.WriteLine("Trying to match " + keybind + " / Enabled?: " + keybind.Enabled);
                        if(!keybind.Enabled) continue;
                        GlobalHotkey globalHotkey = keybind.InputSequence;
                        if(globalHotkey.Matches(vkCode, mods)) {
                            Debug.WriteLine("Matched! Sending...");
                            globalHotkey.SendToProcess(program.Name, keybind.OutputSequence);
                            return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
                        }
                    }
                }
            }
            return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }
        */


        public void Close() {
            if (_hook != IntPtr.Zero) UnhookWindowsHookEx(_hook);
            _stop = true; //Ask the thread to stop
            this.Dispose();
            Thread.Sleep(1000);
            if (_handleHotkeyMessageThread == null || !_handleHotkeyMessageThread.IsAlive) return;
            _handleHotkeyMessageThread.Abort(); //Kill it without regrets
        }

        public void Dispose() {
            if (_keyboard != null) {
                _keyboard.Unacquire();
                _keyboard.Dispose();
                _keyboard = null;
            }
            if (_dInput != null) {
                _dInput.Dispose();
                _dInput = null;
            }
        }
    }
}