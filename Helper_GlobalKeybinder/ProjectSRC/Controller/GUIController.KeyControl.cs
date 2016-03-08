using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.GUI;
using Helper_GlobalKeybinder.ProjectSRC.Model;

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

        private bool _menuDown = false;
        private bool _ctrlDown = false;
        private bool _shiftDown = false;
        
        private void Run() {
            Debug.WriteLine("Runned");
            this._keyPressedDelegate = new HookProc(HandleHotkey);
            IntPtr hInstance = LoadLibrary("User32");
            _hook = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, this._keyPressedDelegate, hInstance, 0);
            /*
            while(!_stop) {
                Debug.WriteLine("Running...");
                MSG msg;
                Debug.WriteLine("Start Messaging...");
                while(GetMessage(out msg, IntPtr.Zero, 0, 0) > 0) {
                    Debug.WriteLine("Message in!");
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                    Debug.WriteLine("Messaging....");
                }
                Debug.WriteLine("END Messaging...");
            }
            */
        }

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

        public void Close() {
            if(_hook != IntPtr.Zero) UnhookWindowsHookEx(_hook);
            _stop = true; //Ask the thread to stop
            Thread.Sleep(1000);
            if(_handleHotkeyMessageThread == null || !_handleHotkeyMessageThread.IsAlive) return;
            _handleHotkeyMessageThread.Abort(); //Kill it without regrets
        }
    }
}