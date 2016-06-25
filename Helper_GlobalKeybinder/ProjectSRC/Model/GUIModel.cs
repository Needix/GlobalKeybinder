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
    [XmlInclude(typeof(ProgramProfile)), XmlInclude(typeof(GlobalHotkey)), XmlInclude(typeof(Keybind)), XmlInclude(typeof(OutputSequence)), XmlInclude(typeof(VKKeyScanResult))]
    public class GUIModel {
        [XmlArray("Programs")]
        [XmlArrayItem("ProgramProfile")]
        public List<ProgramProfile> Programs { get; set; } 

        [XmlIgnore]
        public ProgramProfile CurSelectedProgramProfile { get; set; }
        
        [XmlIgnore]
        public Keybind CurSelectedKeybind { get; set; }

        public GUIModel() {
            Programs = new List<ProgramProfile>();
        }
    }
}