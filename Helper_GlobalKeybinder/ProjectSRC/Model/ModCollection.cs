namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class ModCollection {
        public bool ShiftPressed { get; private set; } 
        public bool ControlPressed { get; private set; }
        public bool AltPressed { get; private set; }

        public ModCollection(bool shiftPressed, bool controlPressed, bool altPressed) {
            ShiftPressed = shiftPressed;
            ControlPressed = controlPressed;
            AltPressed = altPressed;
        }
    }
}