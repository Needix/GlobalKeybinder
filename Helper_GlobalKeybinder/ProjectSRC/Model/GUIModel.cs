// GUIModel.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Helper_GlobalKeybinder.ProjectSRC.Model {
    [XmlRoot("GUIModel")]
    [XmlInclude(typeof(ProgramProfile)), XmlInclude(typeof(GlobalHotkey)), XmlInclude(typeof(Keybind)), XmlInclude(typeof(OutputSequence))]
    public class GUIModel {
        [XmlArray("Programs")]
        [XmlArrayItem("ProgramProfile")]
        public List<ProgramProfile> Programs { get; set; } 

        [XmlIgnore]
        public ProgramProfile CurSelectedProgramProfile { get; set; }

        [XmlIgnore]
        public string CurExeName { get; set; }

        [XmlIgnore]
        public Keybind CurSelectedKeybind { get; set; }

        [XmlIgnore]
        public string CurKBName { get; set; }
        [XmlIgnore]
        public GlobalHotkey CurKBInput { get; set; }
        [XmlIgnore]
        public OutputSequence CurKBOutput { get; set; }

        public GUIModel() {
            Programs = new List<ProgramProfile>();
        }

        public Keybind CreateKeyBindFromData() {
            return new Keybind(CurKBName, CurKBInput, CurKBOutput);
        }

        public ProgramProfile CreateProgramFromData() {
            return new ProgramProfile(CurExeName);
        }
    }
}