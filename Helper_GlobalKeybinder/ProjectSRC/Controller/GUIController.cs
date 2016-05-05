// GUIController.cs
// Copyright 2015
// 
// Project Lead: Need
// Contact:      
//     Mail:     mailto:needdragon@gmail.com 
//     Twitter: https://twitter.com/NeedDragon

using System;
using System.Diagnostics;
using System.Threading;
using Helper_GlobalKeybinder.ProjectSRC.GUI;
using Helper_GlobalKeybinder.ProjectSRC.Model;

namespace Helper_GlobalKeybinder.ProjectSRC.Controller {
    public partial class GUIController {
        public static GUIController Instance;
        public GUIView View { get; set; }
        public Serializer Serializer { get; private set; }
        public GUIModel Model { get; set; }

        private Keybinder Keybinder { get; set; }

        public GUIController(GUIView view) {
            Instance = this;
            Serializer = new Serializer(this);
            Model = Serializer.Deserialize();
            if(Model == null) Model = new GUIModel();
            
            View = view;
            view.RegisterController(this);
            View.UpdateView(Model);

            Keybinder = new Keybinder(this);
            Keybinder.StartHook();
        }
        
        public void Close() {
            Keybinder.Close();
        }
    }
}