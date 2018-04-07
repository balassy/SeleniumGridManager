using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SeleniumGridManager.Agent.Service;
using System.Globalization;

namespace SeleniumGridManager.Agent
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Program.StartService( 9000 );

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new MainForm() );
		}

		private static void StartService(int portNumber)
		{
			string url = String.Format(CultureInfo.InvariantCulture, "http://localhost:{0}", portNumber);
			WebApp.Start<Startup>( url );
		}
	}
}
