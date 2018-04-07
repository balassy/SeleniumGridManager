using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using SeleniumGridManager.Lib.Services.HostProcess;

namespace SeleniumGridManager.Agent.Service.Processes
{
	[RoutePrefix( "api/processes" )]
	public class ProcessController : ApiController
	{
		[AcceptVerbs( "GET" )]
		[Route( "" )]
		[SuppressMessage( "Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate" )]
		public IEnumerable<ProcessDescriptor> GetProcesses()
		{
			string commandLineSearchTerm = Properties.Settings.Default.ProcessCommandLineSearchTerm;

			return ProcessManager.List( commandLineSearchTerm ).Select( p => new ProcessDescriptor
			{
				Id = p.Id,
				MainWindowTitle = p.MainWindowTitle
			} );
		}

		[AcceptVerbs( "DELETE" )]
		[Route( "" )]
		public void Kill()
		{
			string commandLineSearchTerm = Properties.Settings.Default.ProcessCommandLineSearchTerm;

			foreach( Process p in ProcessManager.List( commandLineSearchTerm ) )
			{
				ProcessManager.Kill( p.Id );
			}
		}
	}
}
