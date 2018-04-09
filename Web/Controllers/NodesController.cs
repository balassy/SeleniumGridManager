using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SeleniumGridManager.Web.Models.Api;

namespace Web.Controllers
{
  [Produces( "application/json" )]
  [Route( "api/nodes" )]
  public class NodesController : Controller
  {
    [HttpGet]
    public IEnumerable<NodeStatus> Get()
    {
      return new NodeStatus[]
      {
        new NodeStatus { Id = "1", Name = "Agent 1", AgentHealthy = true },
        new NodeStatus { Id = "2", Name = "Agent 2", AgentHealthy = false }
      };
    }


    [HttpGet( "{id}")]
    public NodeStatus Get( string id )
    {
      return new NodeStatus { Id = "2", Name = "Agent 2", AgentHealthy = false };
    }

  }
}
