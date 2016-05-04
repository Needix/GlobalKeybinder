using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Helper_GlobalKeybinder.ProjectSRC.Controller;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.Controller {
    public class Keybinder {
        //Get Active Window
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle() {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0) {
                return Buff.ToString();
            }
            return null;
        }

        //ReadInput
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        #region DLLImport
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        private readonly LowLevelKeyboardProc _llKeyboardProc;
        private readonly LowLevelMouseProc _llMouseProc;

        private IntPtr _mouseHookID = IntPtr.Zero;
        private IntPtr _keyboardHookID = IntPtr.Zero;

        private GUIController _controller;

        private List<Keys> _PressedMouse;

        public ReadOnlyCollection<Keys> PressedMouse {
            get { return new ReadOnlyCollection<Keys>(_PressedMouse); }
        }

        private List<Keys> _PressedKeys;

        public ReadOnlyCollection<Keys> PressedKeys {
            get { return new ReadOnlyCollection<Keys>(_PressedKeys); }
        }

        public Keybinder(GUIController controller) {
            _controller = controller;
            _PressedKeys = new List<Keys>();
            _PressedMouse = new List<Keys>();

            _llKeyboardProc = KeyboardHookCallback;
            _llMouseProc = MouseHookCallback;
        }

        public void StartHook() {
            _keyboardHookID = SetKeyboardHook(_llKeyboardProc);
            _mouseHookID = SetMousedHook(_llMouseProc);
        }

        public void HandleHotkeys() {
            ModCollection mods = FindKeyMods();

            foreach (Keys pressedKey in _PressedKeys) {
                foreach (ProgramProfile program in _controller.Model.Programs) {
                    if (!program.Enabled) continue;
                    foreach (Keybind keybind in program.Keybinds) {
                        if (!keybind.Enabled) continue;
                        GlobalHotkey globalHotkey = keybind.InputSequence;
                        if (!globalHotkey.Matches(GlobalHotkey.GetVKFromChar((char) pressedKey), mods) ||
                            Environment.TickCount - globalHotkey.LastSend < GlobalHotkey.TimeBetweenSend) continue;

                        Debug.WriteLine("Matched! Sending...");
                        new Thread((ThreadStart) delegate {
                            globalHotkey.LastSend = Environment.TickCount;
                            globalHotkey.SendToProcess(program.Name, keybind.OutputSequence, program.SingleSend);
                        }).Start();
                    }
                }
            }
        }

        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            int vkCode = Marshal.ReadInt32(lParam);
            Keys key = (Keys) vkCode;
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN) {
                if (!_PressedKeys.Contains(key)) {
                    _PressedKeys.Add(key);
                }
            }
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYUP) {
                if (_PressedKeys.Contains(key)) {
                    _PressedKeys.Remove(key);
                }
            }
            HandleHotkeys();

            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }
        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
                //TODO: Add mouse hook functionality ( https://msdn.microsoft.com/en-us/library/windows/desktop/ms644986%28v=vs.85%29.aspx )
            int vkCode = Marshal.ReadInt32(lParam);
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN) {
                _PressedMouse.Add((Keys) vkCode);
                Debug.WriteLine("KeyDown: " + (Keys) vkCode);
            }
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYUP) {
                _PressedKeys.Remove((Keys) vkCode);
                Debug.WriteLine("KeyUp: " + (Keys) vkCode);
            }
            HandleHotkeys();

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }

        private ModCollection FindKeyMods() {
            bool shift = false;
            bool control = false;
            bool alt = false;
            foreach (Keys pressedKey in _PressedKeys) {
                if (pressedKey == Keys.LControlKey || pressedKey == Keys.RControlKey || pressedKey == Keys.ControlKey ||
                    pressedKey == Keys.Control) control = true;
                if (pressedKey == Keys.LShiftKey || pressedKey == Keys.RShiftKey || pressedKey == Keys.Shift ||
                    pressedKey == Keys.ShiftKey) shift = true;
                if (pressedKey == Keys.Alt) alt = true;
            }
            return new ModCollection(shift, control, alt);
        }

        private IntPtr SetMousedHook(LowLevelMouseProc proc) {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private IntPtr SetKeyboardHook(LowLevelKeyboardProc proc) {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public void Close() {
            UnhookWindowsHookEx(_keyboardHookID);
            UnhookWindowsHookEx(_mouseHookID);
        }
    }
}