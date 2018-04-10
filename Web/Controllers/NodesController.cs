using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeleniumGridManager.Web.Models.Agent;
using SeleniumGridManager.Web.Models.Api;

namespace Web.Controllers
{
  [Produces( "application/json" )]
  [Route( "api/nodes" )]
  public class NodesController : Controller
  {
    [HttpGet]
    public IEnumerable<Node> Get()
    {
      return new Node[]
      {
        new Node { Id = "1", Name = "Agent 1" },
        new Node { Id = "2", Name = "Agent 2" }
      };
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
