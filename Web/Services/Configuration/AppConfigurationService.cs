using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace SeleniumGridManager.Web.Services.Configuration
{
  public class AppConfigurationService : IAppConfigurationService
  {
    private IConfiguration _config;


    public ReadOnlyCollection<NodeConfiguration> Nodes
    {
      get
      {
        NodeConfiguration[] array = this._config.GetSection( "Nodes" ).Get<NodeConfiguration[]>();
        return Array.AsReadOnly( array );
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
