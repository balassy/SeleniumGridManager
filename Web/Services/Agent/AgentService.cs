using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using SeleniumGridManager.Web.Services.Configuration;

namespace SeleniumGridManager.Web.Services.Agent
{
  public class AgentService : IAgentService
  {
    private IAppConfigurationService _config;

    public AgentService( IAppConfigurationService config )
    {
      this._config = config;
    }

    public Task<ScreenshotResponse> GetScreenshot( string nodeId )
    {
      if( String.IsNullOrEmpty( nodeId ) )
      {
        throw new ArgumentNullException( nameof( nodeId ), "Please specify the ID of the node!" );
      }

      return this.GetAs<ScreenshotResponse>( nodeId, "/api/screenshot" );
    }


    private async Task<T> GetAs<T>(string nodeId, string relativePath)
    {
      if( String.IsNullOrEmpty( nodeId ) )
      {
        throw new ArgumentNullException( nameof( nodeId ), "Please specify the ID of the node!" );
      }

      if( String.IsNullOrEmpty( relativePath ) )
      {
        throw new ArgumentNullException( nameof( relativePath ), "Please specify the relative path to the agent endpoint!" );
      }

      NodeConfiguration nodeConfig = this._config.GetNodeConfiguration( nodeId );
      if( nodeConfig == null )
      {
        return default(T);
      }

      using( HttpClient client = new HttpClient() )
      {
        Uri baseUri = new Uri( nodeConfig.Endpoint );
        Uri endpointUri = new Uri( baseUri, relativePath );
        string response = await client.GetStringAsync( endpointUri );
        return JsonConvert.DeserializeObject<T>( response );
      }
    }
  }
}
