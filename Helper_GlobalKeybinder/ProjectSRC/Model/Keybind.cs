using System.Collections.Generic;
using Helper_GlobalKeybinder.ProjectSRC.Controller;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class Keybind {
        public string Name { get; set; }
        public bool Enabled { get; set; } //TODO: Add "enabled" func to keybind (incorperate/sync with listviews checkboxes)
        public GlobalHotkey InputSequence { get; set; }
        public OutputSequence OutputSequence { get; set; }

        public Keybind() {}
        public Keybind(string name, GlobalHotkey inputSequence, OutputSequence outputSequence) {
            Name = name;
            InputSequence = inputSequence;
            OutputSequence = outputSequence;
        }
    }

    public class OutputSequence {
        public List<GlobalHotkey> Sequence { get; private set; }

        public OutputSequence(List<GlobalHotkey> sequence) {
            Sequence = sequence;
        }

        /// <summary>
        /// Returns the sequence of chars, separated by a space
        /// </summary>
        /// <returns>The sequence of chars</returns>
        public override string ToString() {
            string result = "";
            foreach(GlobalHotkey key in Sequence) {
                result += key + "\n";
            }
            return result.Trim();
        }
    }
}