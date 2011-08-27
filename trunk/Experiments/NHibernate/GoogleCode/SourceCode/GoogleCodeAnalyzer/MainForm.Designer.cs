namespace GoogleCodeAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCurrentProject = new System.Windows.Forms.TextBox();
            this.lblCurrentProject = new System.Windows.Forms.Label();
            this.txtTotalProjects = new System.Windows.Forms.TextBox();
            this.lblTotalProjects = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.bgProjectWorker = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCurrentProject
            // 
            this.txtCurrentProject.Location = new System.Drawing.Point(134, 116);
            this.txtCurrentProject.Name = "txtCurrentProject";
            this.txtCurrentProject.ReadOnly = true;
            this.txtCurrentProject.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentProject.TabIndex = 9;
            // 
            // lblCurrentProject
            // 
            this.lblCurrentProject.AutoSize = true;
            this.lblCurrentProject.Location = new System.Drawing.Point(27, 119);
            this.lblCurrentProject.Name = "lblCurrentProject";
            this.lblCurrentProject.Size = new System.Drawing.Size(76, 13);
            this.lblCurrentProject.TabIndex = 8;
            this.lblCurrentProject.Text = "Current project";
            // 
            // txtTotalProjects
            // 
            this.txtTotalProjects.Location = new System.Drawing.Point(134, 88);
            this.txtTotalProjects.Name = "txtTotalProjects";
            this.txtTotalProjects.ReadOnly = true;
            this.txtTotalProjects.Size = new System.Drawing.Size(100, 20);
            this.txtTotalProjects.TabIndex = 7;
            // 
            // lblTotalProjects
            // 
            this.lblTotalProjects.AutoSize = true;
            this.lblTotalProjects.Location = new System.Drawing.Point(27, 91);
            this.lblTotalProjects.Name = "lblTotalProjects";
            this.lblTotalProjects.Size = new System.Drawing.Size(71, 13);
            this.lblTotalProjects.TabIndex = 6;
            this.lblTotalProjects.Text = "Total projects";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(30, 41);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 30);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Fetch Projects";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bgProjectWorker
            // 
            this.bgProjectWorker.WorkerReportsProgress = true;
            this.bgProjectWorker.WorkerSupportsCancellation = true;
            this.bgProjectWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgProcessor_DoWork);
            this.bgProjectWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgProcessor_RunWorkerCompleted);
            this.bgProjectWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgProcessor_ProgressChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(186, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 272);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCurrentProject);
            this.Controls.Add(this.lblCurrentProject);
            this.Controls.Add(this.txtTotalProjects);
            this.Controls.Add(this.lblTotalProjects);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCurrentProject;
        private System.Windows.Forms.Label lblCurrentProject;
        private System.Windows.Forms.TextBox txtTotalProjects;
        private System.Windows.Forms.Label lblTotalProjects;
        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker bgProjectWorker;
        private System.Windows.Forms.Button btnCancel;
    }
}

