namespace Helper_GlobalKeybinder.ProjectSRC.Model.SelectProcess {
    public class RunningProcess {
        public int PID { get; set; }
        public string Name { get; set; }

        public RunningProcess(int pid, string name) {
            PID = pid;
            Name = name;
        }
    }
}