using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeleniumGridManager.Web.Models.Api;
using SeleniumGridManager.Web.Services.Agent;
using SeleniumGridManager.Web.Services.Configuration;

namespace Web.Controllers
{
  [Produces( "application/json" )]
  [Route( "api/nodes" )]
  public class NodesController : Controller
  {
    private IAppConfigurationService _config;

    private IAgentService _agent;

    public NodesController( IAppConfigurationService config, IAgentService agent )
    {
      this._config = config;
      this._agent = agent;
    }

    [HttpGet]
    public IEnumerable<Node> Get()
    {
      return this._config.Nodes.Select( n => new Node { Id = n.Id, Name = n.Name } );
    }


    [HttpGet( "{id}" )]
    public NodeStatus Get( string id )
    {
      return new NodeStatus { Id = "2", Name = "Agent " + id, AgentHealthy = id == "1" };
    }


    [HttpGet( "{id}/screenshot" )]
    public async Task<ActionResult> GetScreenshot( string id )
    {
      ScreenshotResponse screenshotResponse = await this._agent.GetScreenshot( id );

      if( screenshotResponse == null )
      {
        return this.NotFound();
      }

      Screenshot result = new Screenshot
      {
        MediaType = screenshotResponse.MediaType,
        ImageContent = screenshotResponse.ImageContent
      };
      return this.Ok( result );
    }

  }
}
