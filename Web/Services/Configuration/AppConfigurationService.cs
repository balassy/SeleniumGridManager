using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace SeleniumGridManager.Web.Services.Configuration
{
  public class AppConfigurationService : IAppConfigurationService
  {
    private IConfiguration _config;


    public NodeConfiguration[] Nodes
    {
      get
      {
        return this._config.GetSection( "Nodes" ).Get<NodeConfiguration[]>();
      }
    }


    public AppConfigurationService( IConfiguration config)
    {
      this._config = config;
    }


    public NodeConfiguration GetNodeConfiguration(string nodeId)
    {
      return this.Nodes.FirstOrDefault( n => n.Id.Equals( nodeId, StringComparison.OrdinalIgnoreCase ) );
    }
  }
}
