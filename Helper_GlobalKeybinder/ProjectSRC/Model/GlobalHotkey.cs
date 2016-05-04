using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Helper_GlobalKeybinder.ProjectSRC.Controller;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class GlobalHotkey {
        #region SendInput
        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT {
            internal InputType type;
            internal InputUnion U;

            internal static int Size {
                get { return Marshal.SizeOf(typeof(INPUT)); }
            }
        }

        internal enum InputType : uint {
            MOUSE = 0,
            KEYBOARD = 1,
            HARDWARE = 2
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct InputUnion {
            [FieldOffset(0)]
            internal MOUSEINPUT mi;
            [FieldOffset(0)]
            internal KEYBDINPUT ki;
            [FieldOffset(0)]
            internal HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT {
            internal int dx;
            internal int dy;
            internal int mouseData;
            internal MOUSEEVENTF dwFlags;
            internal uint time;
            internal UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT {
            internal VirtualKeyShort wVk;
            internal ScanCodeShort wScan;
            internal KEYEVENTF dwFlags;
            internal int time;
            internal UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HARDWAREINPUT {
            internal int uMsg;
            internal short wParamL;
            internal short wParamH;
        }

        [Flags]
        internal enum KEYEVENTF : uint {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            SCANCODE = 0x0008,
            UNICODE = 0x0004
        }

        [Flags]
        internal enum MOUSEEVENTF : uint {
            ABSOLUTE = 0x8000,
            HWHEEL = 0x01000,
            MOVE = 0x0001,
            MOVE_NOCOALESCE = 0x2000,
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            VIRTUALDESK = 0x4000,
            WHEEL = 0x0800,
            XDOWN = 0x0080,
            XUP = 0x0100
        }

        internal enum VirtualKeyShort : short {
            ///<summary>
            ///Left mouse button
            ///</summary>
            LBUTTON = 0x01,

            ///<summary>
            ///Right mouse button
            ///</summary>
            RBUTTON = 0x02,

            ///<summary>
            ///Control-break processing
            ///</summary>
            CANCEL = 0x03,

            ///<summary>
            ///Middle mouse button (three-button mouse)
            ///</summary>
            MBUTTON = 0x04,

            ///<summary>
            ///Windows 2000/XP: X1 mouse button
            ///</summary>
            XBUTTON1 = 0x05,

            ///<summary>
            ///Windows 2000/XP: X2 mouse button
            ///</summary>
            XBUTTON2 = 0x06,

            ///<summary>
            ///BACKSPACE key
            ///</summary>
            BACK = 0x08,

            ///<summary>
            ///TAB key
            ///</summary>
            TAB = 0x09,

            ///<summary>
            ///CLEAR key
            ///</summary>
            CLEAR = 0x0C,

            ///<summary>
            ///ENTER key
            ///</summary>
            RETURN = 0x0D,

            ///<summary>
            ///SHIFT key
            ///</summary>
            SHIFT = 0x10,

            ///<summary>
            ///CTRL key
            ///</summary>
            CONTROL = 0x11,

            ///<summary>
            ///ALT key
            ///</summary>
            MENU = 0x12,

            ///<summary>
            ///PAUSE key
            ///</summary>
            PAUSE = 0x13,

            ///<summary>
            ///CAPS LOCK key
            ///</summary>
            CAPITAL = 0x14,

            ///<summary>
            ///Input Method Editor (IME) Kana mode
            ///</summary>
            KANA = 0x15,

            ///<summary>
            ///IME Hangul mode
            ///</summary>
            HANGUL = 0x15,

            ///<summary>
            ///IME Junja mode
            ///</summary>
            JUNJA = 0x17,

            ///<summary>
            ///IME final mode
            ///</summary>
            FINAL = 0x18,

            ///<summary>
            ///IME Hanja mode
            ///</summary>
            HANJA = 0x19,

            ///<summary>
            ///IME Kanji mode
            ///</summary>
            KANJI = 0x19,

            ///<summary>
            ///ESC key
            ///</summary>
            ESCAPE = 0x1B,

            ///<summary>
            ///IME convert
            ///</summary>
            CONVERT = 0x1C,

            ///<summary>
            ///IME nonconvert
            ///</summary>
            NONCONVERT = 0x1D,

            ///<summary>
            ///IME accept
            ///</summary>
            ACCEPT = 0x1E,

            ///<summary>
            ///IME mode change request
            ///</summary>
            MODECHANGE = 0x1F,

            ///<summary>
            ///SPACEBAR
            ///</summary>
            SPACE = 0x20,

            ///<summary>
            ///PAGE UP key
            ///</summary>
            PRIOR = 0x21,

            ///<summary>
            ///PAGE DOWN key
            ///</summary>
            NEXT = 0x22,

            ///<summary>
            ///END key
            ///</summary>
            END = 0x23,

            ///<summary>
            ///HOME key
            ///</summary>
            HOME = 0x24,

            ///<summary>
            ///LEFT ARROW key
            ///</summary>
            LEFT = 0x25,

            ///<summary>
            ///UP ARROW key
            ///</summary>
            UP = 0x26,

            ///<summary>
            ///RIGHT ARROW key
            ///</summary>
            RIGHT = 0x27,

            ///<summary>
            ///DOWN ARROW key
            ///</summary>
            DOWN = 0x28,

            ///<summary>
            ///SELECT key
            ///</summary>
            SELECT = 0x29,

            ///<summary>
            ///PRINT key
            ///</summary>
            PRINT = 0x2A,

            ///<summary>
            ///EXECUTE key
            ///</summary>
            EXECUTE = 0x2B,

            ///<summary>
            ///PRINT SCREEN key
            ///</summary>
            SNAPSHOT = 0x2C,

            ///<summary>
            ///INS key
            ///</summary>
            INSERT = 0x2D,

            ///<summary>
            ///DEL key
            ///</summary>
            DELETE = 0x2E,

            ///<summary>
            ///HELP key
            ///</summary>
            HELP = 0x2F,

            ///<summary>
            ///0 key
            ///</summary>
            KEY_0 = 0x30,

            ///<summary>
            ///1 key
            ///</summary>
            KEY_1 = 0x31,

            ///<summary>
            ///2 key
            ///</summary>
            KEY_2 = 0x32,

            ///<summary>
            ///3 key
            ///</summary>
            KEY_3 = 0x33,

            ///<summary>
            ///4 key
            ///</summary>
            KEY_4 = 0x34,

            ///<summary>
            ///5 key
            ///</summary>
            KEY_5 = 0x35,

            ///<summary>
            ///6 key
            ///</summary>
            KEY_6 = 0x36,

            ///<summary>
            ///7 key
            ///</summary>
            KEY_7 = 0x37,

            ///<summary>
            ///8 key
            ///</summary>
            KEY_8 = 0x38,

            ///<summary>
            ///9 key
            ///</summary>
            KEY_9 = 0x39,

            ///<summary>
            ///A key
            ///</summary>
            KEY_A = 0x41,

            ///<summary>
            ///B key
            ///</summary>
            KEY_B = 0x42,

            ///<summary>
            ///C key
            ///</summary>
            KEY_C = 0x43,

            ///<summary>
            ///D key
            ///</summary>
            KEY_D = 0x44,

            ///<summary>
            ///E key
            ///</summary>
            KEY_E = 0x45,

            ///<summary>
            ///F key
            ///</summary>
            KEY_F = 0x46,

            ///<summary>
            ///G key
            ///</summary>
            KEY_G = 0x47,

            ///<summary>
            ///H key
            ///</summary>
            KEY_H = 0x48,

            ///<summary>
            ///I key
            ///</summary>
            KEY_I = 0x49,

            ///<summary>
            ///J key
            ///</summary>
            KEY_J = 0x4A,

            ///<summary>
            ///K key
            ///</summary>
            KEY_K = 0x4B,

            ///<summary>
            ///L key
            ///</summary>
            KEY_L = 0x4C,

            ///<summary>
            ///M key
            ///</summary>
            KEY_M = 0x4D,

            ///<summary>
            ///N key
            ///</summary>
            KEY_N = 0x4E,

            ///<summary>
            ///O key
            ///</summary>
            KEY_O = 0x4F,

            ///<summary>
            ///P key
            ///</summary>
            KEY_P = 0x50,

            ///<summary>
            ///Q key
            ///</summary>
            KEY_Q = 0x51,

            ///<summary>
            ///R key
            ///</summary>
            KEY_R = 0x52,

            ///<summary>
            ///S key
            ///</summary>
            KEY_S = 0x53,

            ///<summary>
            ///T key
            ///</summary>
            KEY_T = 0x54,

            ///<summary>
            ///U key
            ///</summary>
            KEY_U = 0x55,

            ///<summary>
            ///V key
            ///</summary>
            KEY_V = 0x56,

            ///<summary>
            ///W key
            ///</summary>
            KEY_W = 0x57,

            ///<summary>
            ///X key
            ///</summary>
            KEY_X = 0x58,

            ///<summary>
            ///Y key
            ///</summary>
            KEY_Y = 0x59,

            ///<summary>
            ///Z key
            ///</summary>
            KEY_Z = 0x5A,

            ///<summary>
            ///Left Windows key (Microsoft Natural keyboard)
            ///</summary>
            LWIN = 0x5B,

            ///<summary>
            ///Right Windows key (Natural keyboard)
            ///</summary>
            RWIN = 0x5C,

            ///<summary>
            ///Applications key (Natural keyboard)
            ///</summary>
            APPS = 0x5D,

            ///<summary>
            ///Computer Sleep key
            ///</summary>
            SLEEP = 0x5F,

            ///<summary>
            ///Numeric keypad 0 key
            ///</summary>
            NUMPAD0 = 0x60,

            ///<summary>
            ///Numeric keypad 1 key
            ///</summary>
            NUMPAD1 = 0x61,

            ///<summary>
            ///Numeric keypad 2 key
            ///</summary>
            NUMPAD2 = 0x62,

            ///<summary>
            ///Numeric keypad 3 key
            ///</summary>
            NUMPAD3 = 0x63,

            ///<summary>
            ///Numeric keypad 4 key
            ///</summary>
            NUMPAD4 = 0x64,

            ///<summary>
            ///Numeric keypad 5 key
            ///</summary>
            NUMPAD5 = 0x65,

            ///<summary>
            ///Numeric keypad 6 key
            ///</summary>
            NUMPAD6 = 0x66,

            ///<summary>
            ///Numeric keypad 7 key
            ///</summary>
            NUMPAD7 = 0x67,

            ///<summary>
            ///Numeric keypad 8 key
            ///</summary>
            NUMPAD8 = 0x68,

            ///<summary>
            ///Numeric keypad 9 key
            ///</summary>
            NUMPAD9 = 0x69,

            ///<summary>
            ///Multiply key
            ///</summary>
            MULTIPLY = 0x6A,

            ///<summary>
            ///Add key
            ///</summary>
            ADD = 0x6B,

            ///<summary>
            ///Separator key
            ///</summary>
            SEPARATOR = 0x6C,

            ///<summary>
            ///Subtract key
            ///</summary>
            SUBTRACT = 0x6D,

            ///<summary>
            ///Decimal key
            ///</summary>
            DECIMAL = 0x6E,

            ///<summary>
            ///Divide key
            ///</summary>
            DIVIDE = 0x6F,

            ///<summary>
            ///F1 key
            ///</summary>
            F1 = 0x70,

            ///<summary>
            ///F2 key
            ///</summary>
            F2 = 0x71,

            ///<summary>
            ///F3 key
            ///</summary>
            F3 = 0x72,

            ///<summary>
            ///F4 key
            ///</summary>
            F4 = 0x73,

            ///<summary>
            ///F5 key
            ///</summary>
            F5 = 0x74,

            ///<summary>
            ///F6 key
            ///</summary>
            F6 = 0x75,

            ///<summary>
            ///F7 key
            ///</summary>
            F7 = 0x76,

            ///<summary>
            ///F8 key
            ///</summary>
            F8 = 0x77,

            ///<summary>
            ///F9 key
            ///</summary>
            F9 = 0x78,

            ///<summary>
            ///F10 key
            ///</summary>
            F10 = 0x79,

            ///<summary>
            ///F11 key
            ///</summary>
            F11 = 0x7A,

            ///<summary>
            ///F12 key
            ///</summary>
            F12 = 0x7B,

            ///<summary>
            ///F13 key
            ///</summary>
            F13 = 0x7C,

            ///<summary>
            ///F14 key
            ///</summary>
            F14 = 0x7D,

            ///<summary>
            ///F15 key
            ///</summary>
            F15 = 0x7E,

            ///<summary>
            ///F16 key
            ///</summary>
            F16 = 0x7F,

            ///<summary>
            ///F17 key  
            ///</summary>
            F17 = 0x80,

            ///<summary>
            ///F18 key  
            ///</summary>
            F18 = 0x81,

            ///<summary>
            ///F19 key  
            ///</summary>
            F19 = 0x82,

            ///<summary>
            ///F20 key  
            ///</summary>
            F20 = 0x83,

            ///<summary>
            ///F21 key  
            ///</summary>
            F21 = 0x84,

            ///<summary>
            ///F22 key, (PPC only) Key used to lock device.
            ///</summary>
            F22 = 0x85,

            ///<summary>
            ///F23 key  
            ///</summary>
            F23 = 0x86,

            ///<summary>
            ///F24 key  
            ///</summary>
            F24 = 0x87,

            ///<summary>
            ///NUM LOCK key
            ///</summary>
            NUMLOCK = 0x90,

            ///<summary>
            ///SCROLL LOCK key
            ///</summary>
            SCROLL = 0x91,

            ///<summary>
            ///Left SHIFT key
            ///</summary>
            LSHIFT = 0xA0,

            ///<summary>
            ///Right SHIFT key
            ///</summary>
            RSHIFT = 0xA1,

            ///<summary>
            ///Left CONTROL key
            ///</summary>
            LCONTROL = 0xA2,

            ///<summary>
            ///Right CONTROL key
            ///</summary>
            RCONTROL = 0xA3,

            ///<summary>
            ///Left MENU key
            ///</summary>
            LMENU = 0xA4,

            ///<summary>
            ///Right MENU key
            ///</summary>
            RMENU = 0xA5,

            ///<summary>
            ///Windows 2000/XP: Browser Back key
            ///</summary>
            BROWSER_BACK = 0xA6,

            ///<summary>
            ///Windows 2000/XP: Browser Forward key
            ///</summary>
            BROWSER_FORWARD = 0xA7,

            ///<summary>
            ///Windows 2000/XP: Browser Refresh key
            ///</summary>
            BROWSER_REFRESH = 0xA8,

            ///<summary>
            ///Windows 2000/XP: Browser Stop key
            ///</summary>
            BROWSER_STOP = 0xA9,

            ///<summary>
            ///Windows 2000/XP: Browser Search key
            ///</summary>
            BROWSER_SEARCH = 0xAA,

            ///<summary>
            ///Windows 2000/XP: Browser Favorites key
            ///</summary>
            BROWSER_FAVORITES = 0xAB,

            ///<summary>
            ///Windows 2000/XP: Browser Start and Home key
            ///</summary>
            BROWSER_HOME = 0xAC,

            ///<summary>
            ///Windows 2000/XP: Volume Mute key
            ///</summary>
            VOLUME_MUTE = 0xAD,

            ///<summary>
            ///Windows 2000/XP: Volume Down key
            ///</summary>
            VOLUME_DOWN = 0xAE,

            ///<summary>
            ///Windows 2000/XP: Volume Up key
            ///</summary>
            VOLUME_UP = 0xAF,

            ///<summary>
            ///Windows 2000/XP: Next Track key
            ///</summary>
            MEDIA_NEXT_TRACK = 0xB0,

            ///<summary>
            ///Windows 2000/XP: Previous Track key
            ///</summary>
            MEDIA_PREV_TRACK = 0xB1,

            ///<summary>
            ///Windows 2000/XP: Stop Media key
            ///</summary>
            MEDIA_STOP = 0xB2,

            ///<summary>
            ///Windows 2000/XP: Play/Pause Media key
            ///</summary>
            MEDIA_PLAY_PAUSE = 0xB3,

            ///<summary>
            ///Windows 2000/XP: Start Mail key
            ///</summary>
            LAUNCH_MAIL = 0xB4,

            ///<summary>
            ///Windows 2000/XP: Select Media key
            ///</summary>
            LAUNCH_MEDIA_SELECT = 0xB5,

            ///<summary>
            ///Windows 2000/XP: Start Application 1 key
            ///</summary>
            LAUNCH_APP1 = 0xB6,

            ///<summary>
            ///Windows 2000/XP: Start Application 2 key
            ///</summary>
            LAUNCH_APP2 = 0xB7,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_1 = 0xBA,

            ///<summary>
            ///Windows 2000/XP: For any country/region, the '+' key
            ///</summary>
            OEM_PLUS = 0xBB,

            ///<summary>
            ///Windows 2000/XP: For any country/region, the ',' key
            ///</summary>
            OEM_COMMA = 0xBC,

            ///<summary>
            ///Windows 2000/XP: For any country/region, the '-' key
            ///</summary>
            OEM_MINUS = 0xBD,

            ///<summary>
            ///Windows 2000/XP: For any country/region, the '.' key
            ///</summary>
            OEM_PERIOD = 0xBE,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_2 = 0xBF,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_3 = 0xC0,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_4 = 0xDB,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_5 = 0xDC,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_6 = 0xDD,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_7 = 0xDE,

            ///<summary>
            ///Used for miscellaneous characters; it can vary by keyboard.
            ///</summary>
            OEM_8 = 0xDF,

            ///<summary>
            ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
            ///</summary>
            OEM_102 = 0xE2,

            ///<summary>
            ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
            ///</summary>
            PROCESSKEY = 0xE5,

            ///<summary>
            ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
            ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
            ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
            ///</summary>
            PACKET = 0xE7,

            ///<summary>
            ///Attn key
            ///</summary>
            ATTN = 0xF6,

            ///<summary>
            ///CrSel key
            ///</summary>
            CRSEL = 0xF7,

            ///<summary>
            ///ExSel key
            ///</summary>
            EXSEL = 0xF8,

            ///<summary>
            ///Erase EOF key
            ///</summary>
            EREOF = 0xF9,

            ///<summary>
            ///Play key
            ///</summary>
            PLAY = 0xFA,

            ///<summary>
            ///Zoom key
            ///</summary>
            ZOOM = 0xFB,

            ///<summary>
            ///Reserved
            ///</summary>
            NONAME = 0xFC,

            ///<summary>
            ///PA1 key
            ///</summary>
            PA1 = 0xFD,

            ///<summary>
            ///Clear key
            ///</summary>
            OEM_CLEAR = 0xFE
        }

        internal enum ScanCodeShort : short {
            LBUTTON = 0,
            RBUTTON = 0,
            CANCEL = 70,
            MBUTTON = 0,
            XBUTTON1 = 0,
            XBUTTON2 = 0,
            BACK = 14,
            TAB = 15,
            CLEAR = 76,
            RETURN = 28,
            SHIFT = 42,
            CONTROL = 29,
            MENU = 56,
            PAUSE = 0,
            CAPITAL = 58,
            KANA = 0,
            HANGUL = 0,
            JUNJA = 0,
            FINAL = 0,
            HANJA = 0,
            KANJI = 0,
            ESCAPE = 1,
            CONVERT = 0,
            NONCONVERT = 0,
            ACCEPT = 0,
            MODECHANGE = 0,
            SPACE = 57,
            PRIOR = 73,
            NEXT = 81,
            END = 79,
            HOME = 71,
            LEFT = 75,
            UP = 72,
            RIGHT = 77,
            DOWN = 80,
            SELECT = 0,
            PRINT = 0,
            EXECUTE = 0,
            SNAPSHOT = 84,
            INSERT = 82,
            DELETE = 83,
            HELP = 99,
            KEY_0 = 11,
            KEY_1 = 2,
            KEY_2 = 3,
            KEY_3 = 4,
            KEY_4 = 5,
            KEY_5 = 6,
            KEY_6 = 7,
            KEY_7 = 8,
            KEY_8 = 9,
            KEY_9 = 10,
            KEY_A = 30,
            KEY_B = 48,
            KEY_C = 46,
            KEY_D = 32,
            KEY_E = 18,
            KEY_F = 33,
            KEY_G = 34,
            KEY_H = 35,
            KEY_I = 23,
            KEY_J = 36,
            KEY_K = 37,
            KEY_L = 38,
            KEY_M = 50,
            KEY_N = 49,
            KEY_O = 24,
            KEY_P = 25,
            KEY_Q = 16,
            KEY_R = 19,
            KEY_S = 31,
            KEY_T = 20,
            KEY_U = 22,
            KEY_V = 47,
            KEY_W = 17,
            KEY_X = 45,
            KEY_Y = 21,
            KEY_Z = 44,
            LWIN = 91,
            RWIN = 92,
            APPS = 93,
            SLEEP = 95,
            NUMPAD0 = 82,
            NUMPAD1 = 79,
            NUMPAD2 = 80,
            NUMPAD3 = 81,
            NUMPAD4 = 75,
            NUMPAD5 = 76,
            NUMPAD6 = 77,
            NUMPAD7 = 71,
            NUMPAD8 = 72,
            NUMPAD9 = 73,
            MULTIPLY = 55,
            ADD = 78,
            SEPARATOR = 0,
            SUBTRACT = 74,
            DECIMAL = 83,
            DIVIDE = 53,
            F1 = 59,
            F2 = 60,
            F3 = 61,
            F4 = 62,
            F5 = 63,
            F6 = 64,
            F7 = 65,
            F8 = 66,
            F9 = 67,
            F10 = 68,
            F11 = 87,
            F12 = 88,
            F13 = 100,
            F14 = 101,
            F15 = 102,
            F16 = 103,
            F17 = 104,
            F18 = 105,
            F19 = 106,
            F20 = 107,
            F21 = 108,
            F22 = 109,
            F23 = 110,
            F24 = 118,
            NUMLOCK = 69,
            SCROLL = 70,
            LSHIFT = 42,
            RSHIFT = 54,
            LCONTROL = 29,
            RCONTROL = 29,
            LMENU = 56,
            RMENU = 56,
            BROWSER_BACK = 106,
            BROWSER_FORWARD = 105,
            BROWSER_REFRESH = 103,
            BROWSER_STOP = 104,
            BROWSER_SEARCH = 101,
            BROWSER_FAVORITES = 102,
            BROWSER_HOME = 50,
            VOLUME_MUTE = 32,
            VOLUME_DOWN = 46,
            VOLUME_UP = 48,
            MEDIA_NEXT_TRACK = 25,
            MEDIA_PREV_TRACK = 16,
            MEDIA_STOP = 36,
            MEDIA_PLAY_PAUSE = 34,
            LAUNCH_MAIL = 108,
            LAUNCH_MEDIA_SELECT = 109,
            LAUNCH_APP1 = 107,
            LAUNCH_APP2 = 33,
            OEM_1 = 39,
            OEM_PLUS = 13,
            OEM_COMMA = 51,
            OEM_MINUS = 12,
            OEM_PERIOD = 52,
            OEM_2 = 53,
            OEM_3 = 41,
            OEM_4 = 26,
            OEM_5 = 43,
            OEM_6 = 27,
            OEM_7 = 40,
            OEM_8 = 0,
            OEM_102 = 86,
            PROCESSKEY = 0,
            PACKET = 0,
            ATTN = 0,
            CRSEL = 0,
            EXSEL = 0,
            EREOF = 93,
            PLAY = 0,
            ZOOM = 98,
            NONAME = 0,
            PA1 = 0,
            OEM_CLEAR = 0,
        }
        #endregion

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        const uint MAPVK_VK_TO_VSC = 0x00; //uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.
        const uint MAPVK_VSC_TO_VK = 0x01;  //uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If there is no translation, the function returns 0.
        const uint MAPVK_VK_TO_CHAR = 0x02; //uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0.
        const uint MAPVK_VSC_TO_VK_EX = 0x03; //uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is no translation, the function returns 0.
        const uint MAPVK_VK_TO_VSC_EX = 0x04;


        [DllImport("user32.dll")]
        static extern short VkKeyScan(char ch);
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        public enum KeyTypes {
            IsChar = 0,
            IsText = 1,
            IsDelay = 2,
        }
        public KeyTypes KeyType { get; set; }

        public int Modifier { get; set; } //The "list" of modifiers
        public int Key { get; set; } //VK_ variant of the Key
        
        [XmlArray("Keys")]
        [XmlArrayItem("Key")]
        public List<int> Keys { get; set; } //THE VK_ bytes of the Text
        public string Text { get; set; }

        public int Delay { get; set; }

        [XmlIgnore]
        public int LastSend { get; set; }

        public static int TimeBetweenSend = 500;

        [StructLayout(LayoutKind.Explicit)]
        struct Helper {
            [FieldOffset(0)]
            public short Value;
            [FieldOffset(0)]
            public byte Low;
            [FieldOffset(1)]
            public byte High;
        }

        public GlobalHotkey() {
            LastSend = 0;
        }

        public GlobalHotkey(int delay) : this() {
            KeyType = KeyTypes.IsDelay;
            Delay = delay;
        }
        /// <summary>
        /// "Text" Hotkey
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="form"></param>
        public GlobalHotkey(string text, int delay = -1) : this() {
            Delay = -1;
            Modifier = Constants.NOMOD;
            Text = text;
            Delay = delay;
            KeyType = KeyTypes.IsText;
            Keys = new List<int>();
            foreach(char c in text.ToCharArray()) {
                Keys.Add(GetVKFromChar(c)); //Fix: only lower case working
            }
        }
        /// <summary>
        /// Single character hotkey with modifier
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        /// <param name="form"></param>
        public GlobalHotkey(int modifier, char key) {
            this.Modifier = modifier;
            this.Key = GetVKFromChar(key);
            KeyType = KeyTypes.IsChar;
            Delay = -1;
        }
        
        /// <summary>
        /// Checks if the given key with the given mods, matches this hotkey
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <param name="mods">The modifier of the key</param>
        /// <returns>true, if the key matches and all the modificator keys that are pressed in this hotkey are also pressed in the parameter collection</returns>
        public bool Matches(int vk_code, ModCollection mods) {
            if(vk_code != Key) return false;

            ModCollection thisMods = GetModifiers(Modifier);
            return thisMods.AltPressed == mods.AltPressed && //TODO: Add "partial correctness" // Return true, if pressed modifiers matches this hotkey (but additional mods are allowed down too)
                thisMods.ControlPressed == mods.ControlPressed &&
                thisMods.ShiftPressed == mods.ShiftPressed;
        }

        /// <summary>
        /// Sends the outputsequence to the process with the name "exename"
        /// </summary>
        /// <param name="exeName">The process where the sequence should be send to</param>
        /// <param name="seq">The OutputSequence to send</param>
        public void SendToProcess(string exeName, OutputSequence seq, bool singleSend) {
            IntPtr handle = SearchWindowHandle(exeName);
            if(handle == IntPtr.Zero) {
                Debug.WriteLine("Could not find process: " + exeName);
                return;
            }
            Debug.WriteLine("Sending char sequence to: " + exeName);

            foreach(GlobalHotkey c in seq.Sequence) {
                if(c.KeyType == KeyTypes.IsChar) {
                    byte key = GetVKFromChar((char) c.Key);
                    ModCollection mod = GetModifiers(c.Modifier);
                    bool shift = mod.ShiftPressed;
                    bool alt = mod.AltPressed;
                    bool ctrl = mod.ControlPressed;

                    Debug.WriteLine("Sending \"" + ((char)c.Key) + "\" with mods: \"CTRL:"+ctrl+" / ALT:"+alt+" / SHIFT:"+shift+"\" to " + exeName);
                    //TODO: Add/fix mod sending
                    SendKeyToHandle(handle, key, singleSend, shift, alt, ctrl);

                } else if (c.KeyType == KeyTypes.IsText) {
                    Debug.WriteLine("Sending text: \""+c.Text+"\" to: "+exeName);
                    foreach (int key in c.Keys) {
                        if (c.Delay > 0) Thread.Sleep(c.Delay);
                        SendKeyToHandle(handle, key, singleSend, false, false, false);
                    }
                }
                if (c.Delay > 0) Thread.Sleep(c.Delay);
            }
            LastSend = Environment.TickCount;
        }
        private IntPtr SearchWindowHandle(string exeName) {
            Process[] processes = Process.GetProcessesByName(exeName);
            foreach(Process proc in processes) if(proc.ProcessName == exeName) return proc.MainWindowHandle;
            return IntPtr.Zero;
        }
        private void SendKeyToHandle(IntPtr windowHandle, int key, bool singleSend, bool shift, bool alt, bool ctrl) {
            SendKey((ScanCodeShort)MapVirtualKey((uint)key, MAPVK_VK_TO_VSC), (VirtualKeyShort)key, singleSend);
            //SendKeyOldWorkingRL(windowHandle, key);
        }

        private void SendKeyOldWorkingRL(IntPtr windowHandle, int key) {
            PostMessage(windowHandle, Constants.WM_KEYDOWN, key, 0);

            //Mod version (not tested):
            /*
            if(ctrl) PostMessage(windowHandle, Constants.WM_SYSKEYDOWN, Constants.VK_CONTROL, 0x0);
            if(shift) PostMessage(windowHandle, Constants.WM_SYSKEYDOWN, Constants.VK_SHIFT, 0x0);
            if(alt) PostMessage(windowHandle, Constants.WM_SYSKEYDOWN, Constants.VK_ALT, 0x0);
            PostMessage(windowHandle, Constants.WM_KEYDOWN, key, 0);
            Thread.Sleep(10);
            PostMessage(windowHandle, Constants.WM_KEYUP, key, 0);
            if(alt) PostMessage(windowHandle, Constants.WM_SYSKEYUP, Constants.VK_ALT, 0x0);
            if(shift) PostMessage(windowHandle, Constants.WM_SYSKEYUP, Constants.VK_SHIFT, 0x0);
            if(ctrl) PostMessage(windowHandle, Constants.WM_SYSKEYUP, Constants.VK_CONTROL, 0x0);
            */
        }

        private void SendKey(ScanCodeShort scanCode, VirtualKeyShort vkey, bool singleSend) {
            Debug.WriteLine("Sending "+scanCode+" / "+vkey+" to "+Keybinder.GetActiveWindowTitle());
            INPUT input1 = new INPUT() {
                type = InputType.KEYBOARD,
                U = new InputUnion() {
                    ki = new KEYBDINPUT() {
                        wScan = scanCode,
                        wVk = vkey
                    }
                }
            };
            INPUT input2 = new INPUT() {
                type = InputType.KEYBOARD,
                U = new InputUnion() {
                    ki = new KEYBDINPUT() {
                        wScan = scanCode,
                        wVk = vkey,
                        dwFlags = KEYEVENTF.KEYUP
                    }
                }
            };
            int amount = singleSend ? 1 : 2;
            INPUT[] pInputs = new INPUT[amount];
            pInputs[0] = input1;
            if (!singleSend) pInputs[1] = input2;

            SendInput((uint)pInputs.Length, pInputs, INPUT.Size);
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
        public static ModCollection GetModifiers(int mod) {
            bool ctrl = (mod & Constants.CTRL) == Constants.CTRL;
            bool shift = (mod & Constants.SHIFT) == Constants.SHIFT;
            bool alt = (mod & Constants.ALT) == Constants.ALT;
            return new ModCollection(shift, ctrl, alt);
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
            string delayString = " (Delay: " + Delay + ")";
            if (KeyType == KeyTypes.IsChar) {
                List<string> resultList = new List<string>();
                if ((Modifier & Constants.CTRL) == Constants.CTRL) resultList.Add("CTRL");
                if ((Modifier & Constants.ALT) == Constants.ALT) resultList.Add("ALT");
                if ((Modifier & Constants.SHIFT) == Constants.SHIFT) resultList.Add("SHIFT");
                string charString = new KeysConverter().ConvertToString(Key);
                resultList.Add(charString);
                foreach (string s in resultList) {
                    result += s + " ";
                    if (s != charString) result += "+ ";
                }
            } else if(KeyType == KeyTypes.IsText) {
                result = Text;
            } else if (KeyType == KeyTypes.IsDelay) {
                
            }
            if(Delay>-1) result += delayString;
            return result.Trim();
        }
    }
}