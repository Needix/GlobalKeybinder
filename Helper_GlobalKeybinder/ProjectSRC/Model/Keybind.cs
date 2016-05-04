using System.Collections.Generic;
using System.Xml.Serialization;
using Helper_GlobalKeybinder.ProjectSRC.Controller;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class Keybind {
        public string Name { get; set; }
        public bool Enabled { get; set; } 
        public GlobalHotkey InputSequence { get; set; }
        public OutputSequence OutputSequence { get; set; } //TODO: Split output and "hotkey"

        public Keybind() {}
        public Keybind(string name, GlobalHotkey inputSequence, OutputSequence outputSequence) {
            Name = name;
            InputSequence = inputSequence;
            OutputSequence = outputSequence;
        }

        public override string ToString() {
            return $"Name: {Name}\n" +
                   $"\t InputSequence: {InputSequence}\n" +
                   $"\t OutputSequence: {OutputSequence}";
        }
    }

    public class OutputSequence {
        [XmlArray("Sequence")]
        [XmlArrayItem("SequenceCharacter")]
        public List<GlobalHotkey> Sequence { get; set; }
        
        public OutputSequence() { }
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
                result += key + " | \n";
            }
            return result.Trim();
        }
    }
}