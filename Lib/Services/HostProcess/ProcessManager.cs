using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Management;

namespace SeleniumGridManager.Lib.Services.HostProcess
{
	/// <summary>
	/// Provides functions to manage the Selenium process.
	/// </summary>
	public static class ProcessManager
	{
		/// <summary>
		/// Starts a new process by executing the specified command line.
		/// </summary>
		/// <param name="commandLine">The command line to execute.</param>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="commandLine"/> is <c>null</c> or empty.</exception>
		public static void Start( string commandLine )
		{
			if( String.IsNullOrEmpty( commandLine ) )
			{
				throw new ArgumentNullException( "commandLine", "Please specify the command line to execute!" );
			}

			Process.Start( commandLine );
		}


		/// <summary>
		/// List all Selenium processes.
		/// </summary>
		/// <returns>All Selenium related processes.</returns>
		public static IEnumerable<Process> List()
		{
			return FindProcesses( "webdriver" );
		}


		/// <summary>
		/// Terminates the specified Selenium process including the terminal window that runs it.
		/// </summary>
		/// <param name="processId">The unique identifier of the Selenium process.</param>
		/// <exception cref="ArgumentException">If the specified <paramref name="processId"/> is <c>0</c>.</exception>
		public static void Kill( int processId )
		{
			if( processId == default(int) )
			{
				throw new ArgumentException( "Please specify the ID of the process to terminate!", "processId" );
			}

			Process targetProcess = Process.GetProcessById( processId );
			Process parentProcess = targetProcess.GetParent();
			parentProcess.Exterminate();
		}


		/// <summary>
		/// Returns the list of processes where the command line contains the specified term.
		/// </summary>
		/// <param name="commandLineTerm">The term to look for in the command line.</param>
		/// <returns>The list of matching processes.</returns>
		/// <exception cref="ArgumentNullException">If the specified <paramref name="commandLineTerm"/> is <c>null</c> or empty.</exception>
		private static IEnumerable<Process> FindProcesses( string commandLineTerm )
		{
			if( String.IsNullOrEmpty( commandLineTerm ) )
			{
				throw new ArgumentNullException( "commandLineTerm", "Please specify the term to look for in the command line!" );
			}

			string query = String.Format( CultureInfo.InvariantCulture, @"SELECT ProcessId FROM Win32_Process WHERE CommandLine LIKE ""%{0}%""", commandLineTerm );
			using( ManagementObjectSearcher searcher = new ManagementObjectSearcher( query ) )
			{
				return searcher.Get()
					.OfType<ManagementObject>()
					.Select( p => Process.GetProcessById( (int) (uint) p[ "ProcessId" ] ) );
			}
		}
	}
}
