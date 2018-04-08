using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using SeleniumGridManager.Agent.Service;
using System.Globalization;
using System.Security.Principal;

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
			string baseUrlPattern = "http://localhost:{0}";
			if( Program.IsCurrentUserAdmin() )
			{
				baseUrlPattern = "http://*:{0}";
			}

			string url = String.Format(CultureInfo.InvariantCulture, baseUrlPattern, portNumber);
			WebApp.Start<Startup>( url );
		}

		private static bool IsCurrentUserAdmin()
		{
			return new WindowsPrincipal( WindowsIdentity.GetCurrent() ).IsInRole( WindowsBuiltInRole.Administrator );
		}
	}
}
