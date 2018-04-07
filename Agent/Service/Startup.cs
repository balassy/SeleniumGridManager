using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup( typeof( SeleniumGridManager.Agent.Service.Startup ) )]

namespace SeleniumGridManager.Agent.Service
{
	public class Startup
	{
		[SuppressMessage( "Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Responsibility of the ASP.NET runtime." )]
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();

			this.ConfigureJsonOutput( config );
			this.ConfigureRoutes( config );

			app.UseWebApi( config );
		}


		private void ConfigureJsonOutput(HttpConfiguration config)
		{
			config.Formatters.Clear();
			config.Formatters.Add( new JsonMediaTypeFormatter() );
			config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Formatting = Formatting.Indented
			};
		}


		private void ConfigureRoutes(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute( name: "DefaultApi", routeTemplate: "api/{controller}/{action}" );
		}
	}
}
