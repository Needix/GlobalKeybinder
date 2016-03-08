using System;
using System.Collections.Generic;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    public class ProgramProfile {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public List<Keybind> Keybinds { get; private set; }

        public ProgramProfile() { }
        public ProgramProfile(string name) {
            Name = name;
            Enabled = true;

            Keybinds = new List<Keybind>();
        }

        public override string ToString() {
            return $"{Name}";
        }
    }
}