using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Helper_GlobalKeybinder.ProjectSRC.Controller;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class Keybind {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; } 
        public GlobalHotkey InputSequence { get; set; }
        public OutputSequence OutputSequence { get; set; } //TODO: Split output and "hotkey"

        public Keybind() {}
        public Keybind(int id, string name, GlobalHotkey inputSequence, OutputSequence outputSequence) {
            Name = name;
            InputSequence = inputSequence;
            OutputSequence = outputSequence;
            Enabled = true;
            ID = id;
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
            if(sequence == null || sequence.Count == 0) throw new InvalidOperationException("Output Sequence was empty!");
            Sequence = sequence;
        }

        public OutputSequence CreateCopy() {
            List<GlobalHotkey> hotkeys = new List<GlobalHotkey>();
            foreach (GlobalHotkey globalHotkey in Sequence) {
                hotkeys.Add(new GlobalHotkey(globalHotkey));
            }
            return new OutputSequence(hotkeys);
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