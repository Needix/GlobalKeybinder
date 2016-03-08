using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Controller;
using Helper_GlobalKeybinder.ProjectSRC.GUI;

namespace Helper_GlobalKeybinder {
    static class Program {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GUIView view = new GUIView();
            GUIController controller = new GUIController(view); //Controller is saved in view as reference
            view.RegisterController(controller);

            Application.Run(view);
        }
    }
}
