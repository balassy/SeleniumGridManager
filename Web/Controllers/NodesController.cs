using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
      return this._config.Nodes
        .Where( n => n.Id == id )
        .Select( n => new NodeStatus
        {
          Id = n.Id,
          Name = n.Name,
          AgentHealthy = true
        } )
        .FirstOrDefault();
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


    [HttpDelete( "{id}/processes" )]
    public async Task<ActionResult> TerminateProcesses( string id )
    {
      if( String.IsNullOrEmpty( id ) )
      {
        return this.BadRequest();
      }

      try
      {
        await this._agent.TerminateProcess( id );
        return this.NoContent();
      }
      catch( ArgumentOutOfRangeException )
      {
        return this.NotFound();
      }
    }
  }
}
