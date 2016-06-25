using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Mail;
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
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

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
        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        const uint MAPVK_VK_TO_VSC = 0x00; //uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.
        const uint MAPVK_VSC_TO_VK = 0x01;  //uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If there is no translation, the function returns 0.
        const uint MAPVK_VK_TO_CHAR = 0x02; //uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0.
        const uint MAPVK_VSC_TO_VK_EX = 0x03; //uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is no translation, the function returns 0.
        const uint MAPVK_VK_TO_VSC_EX = 0x04;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static string GetActiveProcessFileName() {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            return p.MainModule.ModuleName;
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

        private readonly List<Thread> SendThreads = new List<Thread>(); 

        private readonly GUIController _controller;

        private readonly List<Keys> _PressedMouse;

        public ReadOnlyCollection<Keys> PressedMouse {
            get { return new ReadOnlyCollection<Keys>(_PressedMouse); }
        }

        private readonly List<VKKeyScanResult> _PressedKeys;

        public ReadOnlyCollection<VKKeyScanResult> PressedKeys {
            get { return new ReadOnlyCollection<VKKeyScanResult>(_PressedKeys); }
        }

        public Keybinder(GUIController controller) {
            _controller = controller;
            _PressedKeys = new List<VKKeyScanResult>();
            _PressedMouse = new List<Keys>();

            _llKeyboardProc = KeyboardHookCallback;
            _llMouseProc = MouseHookCallback;
        }

        public void StartHook() {
            _keyboardHookID = SetKeyboardHook(_llKeyboardProc);
            _mouseHookID = SetMousedHook(_llMouseProc);
        }

        //TODO: Add a timer to this (every 10 ms or so)
        public void HandleHotkeys() {
            foreach (VKKeyScanResult pressedKey in _PressedKeys) {
                foreach (ProgramProfile program in _controller.Model.Programs) {
                    if (!program.Enabled) continue;
                    foreach (Keybind keybind in program.Keybinds) {
                        if (!keybind.Enabled) continue;
                        GlobalHotkey globalHotkey = keybind.InputSequence;
                        string processName = GetActiveProcessFileName();
                        string processNameShort = processName.Substring(0, processName.LastIndexOf('.'));
                        if (!globalHotkey.Matches(pressedKey) || //Doesnt matched searched keybind
                            Environment.TickCount - globalHotkey.LastSend < GlobalHotkey.TimeBetweenSend ||  //Or was already executed in last (TimeBetweenSend) milliseconds
                            processNameShort != program.Name)
                                continue;

                        Debug.WriteLine("Matched! Sending...");
                        Thread t = new Thread((ThreadStart) delegate {
                            globalHotkey.LastSend = Environment.TickCount;
                            globalHotkey.SendToProcess(program.Name, keybind.OutputSequence, program.SingleSend);
                        });
                        t.Start();
                        SendThreads.Add(t);
                    }
                }
            }
        }

        private const int KEY_PRESSED = 0x8000;
        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            int vkCode = Marshal.ReadInt32(lParam);
            Keys key = (Keys) vkCode;
            Keys keys = Control.ModifierKeys;
            //TODO: Shift and Ctrl not set correctly (possible also alt)
            /*
             * EqualityCheck:
                ScanResult: High: Shift, Low: 90, Value: 346, Character: Z
                This: High: None, Low: 90, Value: 346, Character: Z
                Equals: False
            in HandleHotkeys(current pressed)
             */
            bool shift = (keys & Keys.Shift) != 0;
            bool alt = (keys & Keys.Alt) != 0;
            bool ctrl = (keys & Keys.Control) != 0;
            VKKeyScanResult result = new VKKeyScanResult(Convert.ToChar(MapVirtualKey((uint)vkCode, MAPVK_VK_TO_CHAR)));
            result.SetMod(shift, alt, ctrl);
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN) {
                if (!_PressedKeys.Contains(result)) {
                    _PressedKeys.Add(result);
                }
            }
            if (nCode >= 0 && wParam == (IntPtr) WM_KEYUP) {
                if (_PressedKeys.Contains(result)) {
                    _PressedKeys.Remove(result);
                }
            }
            HandleHotkeys();

            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }
        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
                //TODO: Add mouse hook functionality ( https://msdn.microsoft.com/en-us/library/windows/desktop/ms644986%28v=vs.85%29.aspx )

                /*
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
            */

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
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