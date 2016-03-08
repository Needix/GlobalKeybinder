using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Helper_GlobalKeybinder.ProjectSRC.Model.SelectProcess;

namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    public partial class SelectProcess : Form {
        private List<RunningProcess> _savedProcesses = new List<RunningProcess>();
        public RunningProcess SelectedProcess { get; private set; }

        private bool _stopUpdating = false;
        private Thread _updateProcessListThread;

        public SelectProcess() {
            InitializeComponent();

            _updateProcessListThread = new Thread(Run);
            _updateProcessListThread.Start();
        }

        private void Run() {
            while(!_stopUpdating) {
                Process[] processList = Process.GetProcesses();

                bool listChanged = false;
                List<RunningProcess> newList = new List<RunningProcess>();
                foreach(Process process in processList) {
                    bool found = false;
                    foreach(RunningProcess runningProcess in _savedProcesses) { //Readd all entries, that are already in list
                        if(runningProcess.PID == process.Id) {
                            found = true;
                            newList.Add(runningProcess);
                            break;
                        }
                    }
                    if(!found) { //Add a new Process
                        listChanged = true;
                        RunningProcess newProcess = new RunningProcess(process.Id, process.ProcessName);
                        newList.Add(newProcess);
                        listView_processes.Invoke((MethodInvoker)delegate {
                            listView_processes.Items.Add(newProcess.Name).SubItems.Add(newProcess.PID.ToString());
                        });
                    }
                }
                foreach(RunningProcess process in _savedProcesses) {
                    bool found = false;
                    foreach(Process runningProcess in processList) {
                        if(runningProcess.Id == process.PID) {
                            found = true;
                            break;
                        }
                    }
                    if(!found) { //Delete a old Process
                        listChanged = true;
                        listView_processes.Invoke((MethodInvoker) delegate {
                            listView_processes.Items.RemoveByKey(process.Name);
                        });
                    }
                }
                _savedProcesses = newList;
                if(listChanged) {
                    listView_processes.Invoke((MethodInvoker) delegate {
                        listView_processes.Columns[0].Width = -1;
                    });
                }

                Thread.Sleep(100);
            }
        }

        private void b_chooseProcess_Click(object sender, EventArgs e) {
            ListView.SelectedIndexCollection coll = listView_processes.SelectedIndices;
            if(coll.Count == 0) return;

            int selectedIndex = coll[0];
            SelectedProcess = _savedProcesses[selectedIndex];
            CloseForm();
        }

        private void b_exit_Click(object sender, EventArgs e) {
            CloseForm();
        }

        private void CloseForm() {
            _stopUpdating = true;
            this.Close();
        }
    }
}
