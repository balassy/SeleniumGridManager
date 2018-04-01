using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Management;

namespace SeleniumGridManager.Lib.Services.HostProcess
{
	/// <summary>
	/// Extension methods of the <see cref="Process"/> class.
	/// </summary>
	internal static class ProcessExtensions
	{
		/// <summary>
		/// Returns the parent process of this process instance.
		/// </summary>
		/// <param name="process">This process instance.</param>
		/// <returns>The parent of this process instance.</returns>
		[SuppressMessage( "Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Must swallow all exceptions." )]
		public static Process GetParent( this Process process )
		{
			using( ManagementObjectSearcher searcher = new ManagementObjectSearcher( "SELECT * FROM Win32_Process WHERE ProcessId=" + process.Id ) )
			{
				return searcher
					.Get()
					.OfType<ManagementObject>()
					.Select( p => Process.GetProcessById( (int) (uint) p[ "ParentProcessId" ] ) )
					.FirstOrDefault();
			}
		}


		/// <summary>
		/// Terminates this process instance and all of its child processes.
		/// </summary>
		/// <param name="process">This process instance.</param>
		public static void Exterminate( this Process process )
		{
			using( ManagementObjectSearcher searcher = new ManagementObjectSearcher( "SELECT * FROM Win32_Process WHERE ParentProcessID=" + process.Id ) )
			{
				ManagementObjectCollection moc = searcher.Get();
				foreach( ManagementObject mo in moc )
				{
					int pid = Convert.ToInt32( mo[ "ProcessID" ], CultureInfo.InvariantCulture );
					Process p = Process.GetProcessById( pid );
					p.Exterminate();
				}

				try
				{
					process.Kill();
				}
				catch( ArgumentException )
				{
					// Process already exited.
				}
			}
		}
	}
}
