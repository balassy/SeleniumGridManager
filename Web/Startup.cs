using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using SeleniumGridManager.Web.Services;

namespace SeleniumGridManager.Web
{
  public class Startup
  {
    public IConfiguration Configuration { get; }


    public Startup( IConfiguration configuration )
    {
      this.Configuration = configuration;
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices( IServiceCollection services )
    {
      // Add platform services.
      services
        .AddMvc()
        .AddJsonOptions( options =>
         {
           options.SerializerSettings.Formatting = Formatting.Indented;
         } );

      // Add application specific services.
      services.AddSingleton<IAppConfigurationService, AppConfigurationService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure( IApplicationBuilder app, IHostingEnvironment env )
    {
      if( env.IsDevelopment() )
      {
        app.UseDeveloperExceptionPage();
        app.UseWebpackDevMiddleware( new WebpackDevMiddlewareOptions
        {
          HotModuleReplacement = true
        } );
      }
      else
      {
        app.UseExceptionHandler( "/Home/Error" );
      }

      app.UseStaticFiles();

      app.UseMvc( routes =>
      {
        routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}" );

        routes.MapSpaFallbackRoute(
                name: "spa-fallback",
                defaults: new { controller = "Home", action = "Index" } );
      } );
    }
  }
}
