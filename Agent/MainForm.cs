using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SeleniumGridManager.Lib.Services.HostProcess;

namespace SeleniumGridManager.Agent
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			this.InitializeComponent();
		}


		/// <summary>
		/// Event handler that is called when the form is first loaded.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void MainForm_Load( object sender, EventArgs e )
		{
      this.txtStartProcessFilePath.Text = Properties.Settings.Default.StartProcessCommandFilePath;
      this.txtStartProcessArguments.Text = Properties.Settings.Default.StartProcessCommandArguments;
			this.txtProcessSearchTerm.Text = Properties.Settings.Default.ProcessCommandLineSearchTerm;
			this.txtProcessSearchTerm.Focus();

			this.SearchProcesses();
		}


		/// <summary>
		/// Event handler that is called when the user clicks the Exit menu item in the File menu.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">Event arguments.</param>
		private void mnuFileExit_Click( object sender, EventArgs e )
		{
			this.Close();
		}


		private void txtProcessSearchTerm_KeyUp( object sender, KeyEventArgs e )
		{
			if( e.KeyCode == Keys.Enter )
			{
				this.SearchProcesses();
				e.Handled = true;
			}
		}


    private void btnStartProcess_Click( object sender, EventArgs e )
    {
      this.StartProcess();
    }


    private void btnSearchProcesses_Click( object sender, EventArgs e )
		{
			this.SearchProcesses();
		}


		[SuppressMessage( "Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Will not be localized." )]
		private void btnTerminateProcess_Click( object sender, EventArgs e )
		{
			string processCount = this.lblProcessCount.Text;
			string message = String.Format( CultureInfo.InvariantCulture, "You are about to terminate {0} processes with their parents and siblings!\n\nAre you sure?", processCount );

			if( MessageBox.Show( message, "Terminate process", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes )
			{
				string commandLineSearchTerm = this.txtProcessSearchTerm.Text;
				IEnumerable<Process> processes = ProcessManager.List( commandLineSearchTerm );
				foreach( Process process in processes )
				{
					ProcessManager.Kill( process.Id );
				}
				this.SearchProcesses();
			}
		}


		private void SearchProcesses()
		{
			string commandLineSearchTerm = this.txtProcessSearchTerm.Text;
			List<Process> processes = ProcessManager.List( commandLineSearchTerm ).ToList();
			this.lblProcessCount.Text = processes.Count.ToString( CultureInfo.InvariantCulture );
		}


    private void StartProcess()
    {
      string filePath = this.txtStartProcessFilePath.Text;
      string arguments = this.txtStartProcessArguments.Text;
      ProcessManager.Start( filePath, arguments );
    }
  }
}
