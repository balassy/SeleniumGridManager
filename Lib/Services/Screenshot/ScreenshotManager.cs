using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SeleniumGridManager.Lib.Services.Screenshot
{
	/// <summary>
	/// Provides functions to capture screenshots.
	/// </summary>
	public static class ScreenshotManager
	{
		/// <summary>
		/// Creates a screenshot of the desktop.
		/// </summary>
		public static Bitmap CaptureDesktop()
		{
			return ScreenshotManager.CaptureDesktop( ScreenshotArea.WholeDesktop );
		}


		/// <summary>
		/// Captures the content of the desktop.
		/// </summary>
		/// <param name="area">Specifies which area of the desktop should be captured.</param>
		/// <returns>The content of the desktop.</returns>
		private static Bitmap CaptureDesktop( ScreenshotArea area )
		{
			Rectangle desktop = Rectangle.Empty;
			Screen[] screens = Screen.AllScreens;

			for( int i = 0; i < screens.Length; i++ )
			{
				Screen screen = screens[ i ];
				Rectangle rect = area == ScreenshotArea.WorkingAreaOnly ? screen.WorkingArea : screen.Bounds;
				desktop = Rectangle.Union( desktop, rect );
			}

			return ScreenshotManager.CaptureRegion( desktop );
		}


		/// <summary>
		/// Captures the content of the specified screen region.
		/// </summary>
		/// <param name="region">The region of the screen to capture.</param>
		/// <returns>The content of the screen at the specified region.</returns>
		private static Bitmap CaptureRegion( Rectangle region )
		{
			IntPtr desktophWnd = IntPtr.Zero;
			IntPtr desktopDc = IntPtr.Zero;
			IntPtr memoryDc = IntPtr.Zero;
			IntPtr bitmap = IntPtr.Zero;
			IntPtr oldBitmap = IntPtr.Zero;

			try
			{
				desktophWnd = NativeMethods.GetDesktopWindow();
				desktopDc = NativeMethods.GetWindowDC( desktophWnd );
				memoryDc = NativeMethods.CreateCompatibleDC( desktopDc );
				bitmap = NativeMethods.CreateCompatibleBitmap( desktopDc, region.Width, region.Height );
				oldBitmap = NativeMethods.SelectObject( memoryDc, bitmap );
				bool success = NativeMethods.BitBlt( memoryDc, 0, 0, region.Width, region.Height, desktopDc, region.Left, region.Top, NativeMethods.RasterOperations.SRCCOPY | NativeMethods.RasterOperations.CAPTUREBLT );

				if( !success )
				{
					throw new Win32Exception();
				}

				Bitmap result = Image.FromHbitmap( bitmap );
				return result;
			}
			finally
			{
				NativeMethods.SelectObject( memoryDc, oldBitmap );
				if( bitmap != IntPtr.Zero )
				{
					NativeMethods.DeleteObject( bitmap );
				}
				if( memoryDc != IntPtr.Zero )
				{
					NativeMethods.DeleteDC( memoryDc );
				}
				if( desktopDc != IntPtr.Zero && desktophWnd != IntPtr.Zero )
				{
					NativeMethods.ReleaseDC( desktophWnd, desktopDc );
				}
			}

		}
	}
}
