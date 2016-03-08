namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class Constants {
        public const int NOMOD = 0x0000;
        public const int ALT = 0x0001;
        public const int CTRL = 0x0002;
        public const int SHIFT = 0x0004;
        public const int WIN = 0x0008;

        public const int VK_LSHIFT = 0xA0;
        public const int VK_RSHIFT = 0xA1;
        public const int VK_SHIFT = 0x10;
        public const int VK_CONTROL = 0x11;
        public const int VK_LCONTROL = 0xA2;
        public const int VK_RCONTROL = 0xA3;
        public const int VK_ALT = 0x12;
        public const int VK_LALT = 0xA4;
        public const int VK_RALT = 0xA5;

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public static bool IsControlKey(int vkCode) {
            return vkCode == VK_CONTROL || vkCode == VK_LCONTROL || vkCode == VK_RCONTROL;
        }
        public static bool IsShiftKey(int vkCode) {
            return vkCode == VK_SHIFT || vkCode == VK_LSHIFT || vkCode == VK_RSHIFT;
        }
        public static bool IsAltKey(int vkCode) {
            return vkCode == VK_ALT || vkCode == VK_LALT || vkCode == VK_RALT;
        }
    }
}