namespace Helper_GlobalKeybinder.ProjectSRC.GUI {
    partial class SelectProcess {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listView_processes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.b_exit = new System.Windows.Forms.Button();
            this.b_chooseProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_processes
            // 
            this.listView_processes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_processes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_processes.FullRowSelect = true;
            this.listView_processes.Location = new System.Drawing.Point(12, 12);
            this.listView_processes.Name = "listView_processes";
            this.listView_processes.Size = new System.Drawing.Size(747, 420);
            this.listView_processes.TabIndex = 0;
            this.listView_processes.UseCompatibleStateImageBehavior = false;
            this.listView_processes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ProcessName";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 508;
            // 
            // b_exit
            // 
            this.b_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_exit.Location = new System.Drawing.Point(579, 438);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(180, 23);
            this.b_exit.TabIndex = 1;
            this.b_exit.Text = "Exit";
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_chooseProcess
            // 
            this.b_chooseProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_chooseProcess.Location = new System.Drawing.Point(393, 438);
            this.b_chooseProcess.Name = "b_chooseProcess";
            this.b_chooseProcess.Size = new System.Drawing.Size(180, 23);
            this.b_chooseProcess.TabIndex = 2;
            this.b_chooseProcess.Text = "Choose Process";
            this.b_chooseProcess.UseVisualStyleBackColor = true;
            this.b_chooseProcess.Click += new System.EventHandler(this.b_chooseProcess_Click);
            // 
            // SelectProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 473);
            this.Controls.Add(this.b_chooseProcess);
            this.Controls.Add(this.b_exit);
            this.Controls.Add(this.listView_processes);
            this.Name = "SelectProcess";
            this.Text = "SelectProcess";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_processes;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_chooseProcess;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}