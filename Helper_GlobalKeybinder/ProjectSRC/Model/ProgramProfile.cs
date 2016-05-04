using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class ProgramProfile {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool SingleSend { get; set; }

        [XmlArray("Keybinds")]
        [XmlArrayItem("Keybind")]
        public List<Keybind> Keybinds { get; set; }

        public ProgramProfile() { }
        public ProgramProfile(string name) {
            Name = name;
            Enabled = true;
            SingleSend = false;

            Keybinds = new List<Keybind>();
        }

        public override string ToString() {
            return $"{Name}";
        }
    }
}