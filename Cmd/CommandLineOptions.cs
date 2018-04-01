using System;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace SeleniumGridManager.Cmd
{
	public class CommandLineOptions
	{
		[Option( 'n', "new", HelpText = "Start a new process." )]
		public bool StartNewProcess { get; set; }

		[Option( 'p', "processes", HelpText = "List the processes." )]
		public bool ListProcesses { get; set; }

		[Option( 'k', "kill", HelpText = "Kill the specified process." )]
		public int ProcessIdToKill { get; set; }

		[Option('s', "screenshot", HelpText = "Capture screenshot. Please specify the target path.")]
		public string ScreenshotTargetFile { get; set; }

		[Usage(ApplicationAlias = "SeleniumGridManagare.Cmd.exe")]
		public static IEnumerable<Example> Examples
		{
			get
			{
				yield return new Example( "Capture screenshot of the desktop", new CommandLineOptions { ScreenshotTargetFile = "screenshot.png" } );
			}
		}
	}
}
