namespace SeleniumGridManager.Agent
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
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.lblProcessCountPrompt = new System.Windows.Forms.Label();
			this.lblProcessCount = new System.Windows.Forms.Label();
			this.btnTerminateProcess = new System.Windows.Forms.Button();
			this.lblProcessSearchTermPrompt = new System.Windows.Forms.Label();
			this.txtProcessSearchTerm = new System.Windows.Forms.TextBox();
			this.btnSearchProcesses = new System.Windows.Forms.Button();
			this.lblStartProcessFilePathPrompt = new System.Windows.Forms.Label();
			this.txtStartProcessFilePath = new System.Windows.Forms.TextBox();
			this.btnStartProcess = new System.Windows.Forms.Button();
			this.lblStartProcessArgumentsPrompt = new System.Windows.Forms.Label();
			this.txtStartProcessArguments = new System.Windows.Forms.TextBox();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(597, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(37, 20);
			this.mnuFile.Text = "&File";
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Name = "mnuFileExit";
			this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
			this.mnuFileExit.Text = "E&xit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// lblProcessCountPrompt
			// 
			this.lblProcessCountPrompt.AutoSize = true;
			this.lblProcessCountPrompt.Location = new System.Drawing.Point(12, 125);
			this.lblProcessCountPrompt.Name = "lblProcessCountPrompt";
			this.lblProcessCountPrompt.Size = new System.Drawing.Size(110, 13);
			this.lblProcessCountPrompt.TabIndex = 1;
			this.lblProcessCountPrompt.Text = "Number of processes:";
			// 
			// lblProcessCount
			// 
			this.lblProcessCount.AutoSize = true;
			this.lblProcessCount.Location = new System.Drawing.Point(136, 125);
			this.lblProcessCount.Name = "lblProcessCount";
			this.lblProcessCount.Size = new System.Drawing.Size(63, 13);
			this.lblProcessCount.TabIndex = 2;
			this.lblProcessCount.Text = "(updating...)";
			// 
			// btnTerminateProcess
			// 
			this.btnTerminateProcess.Location = new System.Drawing.Point(507, 120);
			this.btnTerminateProcess.Name = "btnTerminateProcess";
			this.btnTerminateProcess.Size = new System.Drawing.Size(75, 23);
			this.btnTerminateProcess.TabIndex = 3;
			this.btnTerminateProcess.Text = "&Terminate...";
			this.btnTerminateProcess.UseVisualStyleBackColor = true;
			this.btnTerminateProcess.Click += new System.EventHandler(this.btnTerminateProcess_Click);
			// 
			// lblProcessSearchTermPrompt
			// 
			this.lblProcessSearchTermPrompt.AutoSize = true;
			this.lblProcessSearchTermPrompt.Location = new System.Drawing.Point(12, 96);
			this.lblProcessSearchTermPrompt.Name = "lblProcessSearchTermPrompt";
			this.lblProcessSearchTermPrompt.Size = new System.Drawing.Size(106, 13);
			this.lblProcessSearchTermPrompt.TabIndex = 4;
			this.lblProcessSearchTermPrompt.Text = "Process search term:";
			// 
			// txtProcessSearchTerm
			// 
			this.txtProcessSearchTerm.Location = new System.Drawing.Point(139, 93);
			this.txtProcessSearchTerm.Name = "txtProcessSearchTerm";
			this.txtProcessSearchTerm.Size = new System.Drawing.Size(362, 20);
			this.txtProcessSearchTerm.TabIndex = 1;
			this.txtProcessSearchTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProcessSearchTerm_KeyUp);
			// 
			// btnSearchProcesses
			// 
			this.btnSearchProcesses.Location = new System.Drawing.Point(507, 91);
			this.btnSearchProcesses.Name = "btnSearchProcesses";
			this.btnSearchProcesses.Size = new System.Drawing.Size(75, 23);
			this.btnSearchProcesses.TabIndex = 2;
			this.btnSearchProcesses.Text = "&Search";
			this.btnSearchProcesses.UseVisualStyleBackColor = true;
			this.btnSearchProcesses.Click += new System.EventHandler(this.btnSearchProcesses_Click);
			// 
			// lblStartProcessFilePathPrompt
			// 
			this.lblStartProcessFilePathPrompt.AutoSize = true;
			this.lblStartProcessFilePathPrompt.Location = new System.Drawing.Point(12, 35);
			this.lblStartProcessFilePathPrompt.Name = "lblStartProcessFilePathPrompt";
			this.lblStartProcessFilePathPrompt.Size = new System.Drawing.Size(112, 13);
			this.lblStartProcessFilePathPrompt.TabIndex = 5;
			this.lblStartProcessFilePathPrompt.Text = "Start process file path:";
			// 
			// txtStartProcessFilePath
			// 
			this.txtStartProcessFilePath.Location = new System.Drawing.Point(139, 32);
			this.txtStartProcessFilePath.Name = "txtStartProcessFilePath";
			this.txtStartProcessFilePath.Size = new System.Drawing.Size(362, 20);
			this.txtStartProcessFilePath.TabIndex = 6;
			// 
			// btnStartProcess
			// 
			this.btnStartProcess.Location = new System.Drawing.Point(507, 30);
			this.btnStartProcess.Name = "btnStartProcess";
			this.btnStartProcess.Size = new System.Drawing.Size(75, 23);
			this.btnStartProcess.TabIndex = 7;
			this.btnStartProcess.Text = "Start";
			this.btnStartProcess.UseVisualStyleBackColor = true;
			this.btnStartProcess.Click += new System.EventHandler(this.btnStartProcess_Click);
			// 
			// lblStartProcessArgumentsPrompt
			// 
			this.lblStartProcessArgumentsPrompt.AutoSize = true;
			this.lblStartProcessArgumentsPrompt.Location = new System.Drawing.Point(12, 61);
			this.lblStartProcessArgumentsPrompt.Name = "lblStartProcessArgumentsPrompt";
			this.lblStartProcessArgumentsPrompt.Size = new System.Drawing.Size(124, 13);
			this.lblStartProcessArgumentsPrompt.TabIndex = 8;
			this.lblStartProcessArgumentsPrompt.Text = "Start process arguments:";
			// 
			// txtStartProcessArguments
			// 
			this.txtStartProcessArguments.Location = new System.Drawing.Point(139, 58);
			this.txtStartProcessArguments.Name = "txtStartProcessArguments";
			this.txtStartProcessArguments.Size = new System.Drawing.Size(362, 20);
			this.txtStartProcessArguments.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnSearchProcesses;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 190);
			this.Controls.Add(this.txtStartProcessArguments);
			this.Controls.Add(this.lblStartProcessArgumentsPrompt);
			this.Controls.Add(this.btnStartProcess);
			this.Controls.Add(this.txtStartProcessFilePath);
			this.Controls.Add(this.lblStartProcessFilePathPrompt);
			this.Controls.Add(this.btnSearchProcesses);
			this.Controls.Add(this.txtProcessSearchTerm);
			this.Controls.Add(this.lblProcessSearchTermPrompt);
			this.Controls.Add(this.btnTerminateProcess);
			this.Controls.Add(this.lblProcessCount);
			this.Controls.Add(this.lblProcessCountPrompt);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Selenium Grid Manager Agent";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		private System.Windows.Forms.Label lblProcessCountPrompt;
		private System.Windows.Forms.Label lblProcessCount;
		private System.Windows.Forms.Button btnTerminateProcess;
		private System.Windows.Forms.Label lblProcessSearchTermPrompt;
		private System.Windows.Forms.TextBox txtProcessSearchTerm;
		private System.Windows.Forms.Button btnSearchProcesses;
    private System.Windows.Forms.Label lblStartProcessFilePathPrompt;
    private System.Windows.Forms.TextBox txtStartProcessFilePath;
    private System.Windows.Forms.Button btnStartProcess;
    private System.Windows.Forms.Label lblStartProcessArgumentsPrompt;
    private System.Windows.Forms.TextBox txtStartProcessArguments;
  }
}