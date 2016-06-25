using System;
using System.Runtime.InteropServices;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class VKKeyScanResult {
        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char ch);

        [StructLayout(LayoutKind.Explicit)]
        public struct Helper {
            [FieldOffset(0)]
            public short Value;
            [FieldOffset(0)]
            public byte Low;
            [FieldOffset(1)]
            public byte High;
        }

        [Flags]
        public enum ShiftStates {
            None = 0,
            Shift = 1,
            Ctrl = 2,
            Alt = 4,
            Hankaku = 8,
            Reserved1 = 16,
            Reserved2 = 32,
        }

        public ShiftStates High { get; set; }
        public byte Low { get; set; }
        public short Value { get; set; }
        public char Character { get; set; }

        public VKKeyScanResult() { }
        public VKKeyScanResult(char c) {
            Character = c;
            var helper = new Helper { Value = VkKeyScan(c) };
            Value = helper.Value;
            Low = helper.Low;
            High = (ShiftStates)helper.High;
        }

        public void SetMod(bool shift, bool alt, bool ctrl) {
            High = ShiftStates.None;
            if(shift) High |= ShiftStates.Shift;
            if(alt) High |= ShiftStates.Alt;
            if(ctrl) High |= ShiftStates.Ctrl;
        }

        public bool ShiftPressed() {
            return High.HasFlag(ShiftStates.Shift);
        }

        public bool AltPressed() {
            return High.HasFlag(ShiftStates.Alt);
        }

        public bool CtrlPressed() {
            return High.HasFlag(ShiftStates.Ctrl);
        }

        protected bool Equals(VKKeyScanResult other) {
            return High == other.High && Low == other.Low && Value == other.Value;
        }

        public override string ToString() {
            return $"High: {High}, Low: {Low}, Value: {Value}, Character: {Character}";
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((VKKeyScanResult) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = High.GetHashCode();
                hashCode = (hashCode*397) ^ Low.GetHashCode();
                hashCode = (hashCode*397) ^ Value.GetHashCode();
                return hashCode;
            }
        }
    }
}