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

        public ProgramProfile() {
            Keybinds = new List<Keybind>();
            Enabled = true;
            SingleSend = false;
        }
        public ProgramProfile(string name) : this() {
            Name = name;
        }

        /// <summary>
        /// Shows the program profile in this style: 
        ///     Enabled: "Name"
        ///     Disabled: "Name + (Disabled)"
        /// </summary>
        /// <returns>The a program profile string as displayed in the description</returns>
        public override string ToString() {
            return Name + (!Enabled ? " (Disabled)" : " (Enabled)");
        }

        public int GetFirstFreeId() {
            int curID = 0;
            int freeId = -1;
            while (freeId == -1) {
                bool found = false;
                foreach (Keybind keybind in Keybinds) {
                    if (keybind.ID == curID) {
                        found = true;
                        break;
                    }
                }
                if (!found) freeId = curID;
                else curID++;
            }
            return freeId;
        }
    }
}