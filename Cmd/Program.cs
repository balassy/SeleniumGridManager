using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using CommandLine;

using SeleniumGridManager.Lib.Services.HostProcess;
using SeleniumGridManager.Lib.Services.Screenshot;

namespace SeleniumGridManager.Cmd
{
  class Program
  {
    static void Main( string[] args )
    {
      CommandLine.Parser.Default.ParseArguments<CommandLineOptions>( args )
        .WithParsed( Program.HandleRecognizedCommandLineOptions )
        .WithNotParsed( Program.HandleUnrecognizedCommandLineOptions );
    }

    private static void HandleRecognizedCommandLineOptions( CommandLineOptions opts )
    {
      if( !String.IsNullOrEmpty( opts.ScreenshotTargetFile ) )
      {
        Bitmap bmp = ScreenshotManager.CaptureDesktop();
        bmp.Save( opts.ScreenshotTargetFile );
      }

      if( opts.ListProcesses )
      {
        IEnumerable<Process> processes = ProcessManager.List();
        foreach( Process p in processes )
        {
          Console.WriteLine( "{0}\t{1}", p.Id, p.MainWindowTitle );
        }
      }

      if( opts.ProcessIdToKill != default( int ) )
      {
        ProcessManager.Kill( opts.ProcessIdToKill );
      }

      if( opts.StartNewProcess )
      {
        ProcessManager.Start( @"C:\Users\Selenium\Desktop\Startup\start_node.cmd", String.Empty );
      }
    }

    private static void HandleUnrecognizedCommandLineOptions( IEnumerable<Error> errors )
    {
    }
  }
}
