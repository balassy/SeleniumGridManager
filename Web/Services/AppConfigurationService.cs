using Microsoft.Extensions.Configuration;

namespace SeleniumGridManager.Web.Services
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
  }
}
