using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeleniumGridManager.Web.Models.Agent;
using SeleniumGridManager.Web.Models.Api;
using SeleniumGridManager.Web.Services;

namespace Web.Controllers
{
  [Produces( "application/json" )]
  [Route( "api/nodes" )]
  public class NodesController : Controller
  {
    private IAppConfigurationService _config;

    public NodesController( IAppConfigurationService config )
    {
      this._config = config;
    }

    [HttpGet]
    public IEnumerable<Node> Get()
    {
      return this._config.Nodes.Select(n => new Node { Id = n.Id, Name = n.Name } );
    }


    [HttpGet( "{id}")]
    public NodeStatus Get( string id )
    {
      return new NodeStatus { Id = "2", Name = "Agent " + id, AgentHealthy = id == "1" };
    }


    [HttpGet( "{id}/screenshot" )]
    public async Task<Screenshot> GetScreenshot( string id )
    {
      using( HttpClient client = new HttpClient() )
      {
        string uri = "http://localhost:9000/api/screenshot";
        string response = await client.GetStringAsync( uri );
        ScreenshotResponse screenshotResponse = JsonConvert.DeserializeObject<ScreenshotResponse>(response);
        return new Screenshot
        {
          MediaType = screenshotResponse.MediaType,
          ImageContent = screenshotResponse.ImageContent
        };
      }
    }

  }
}
