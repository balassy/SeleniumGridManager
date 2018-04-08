using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Web.Http;

using SeleniumGridManager.Lib.Services.Screenshot;

namespace SeleniumGridManager.Agent.Service.Screenshot
{
	[RoutePrefix( "api/screenshot" )]
	public class ScreenshotController : ApiController
	{
		[AcceptVerbs("GET")]
		[Route("")]
		public ScreenshotResponse Get()
		{
			Bitmap bitmap = ScreenshotManager.CaptureDesktop();
			string bitmapEncoded;
			using( MemoryStream stream = new MemoryStream() )
			{
				bitmap.Save( stream, ImageFormat.Png );
				bitmapEncoded = Convert.ToBase64String( stream.GetBuffer() );
			}

			return new ScreenshotResponse
			{
				MediaType = "image/png",
				ImageContent = String.Format( CultureInfo.InvariantCulture, "data:image/png;base64,{0}", bitmapEncoded )
			};
		}
	}
}
