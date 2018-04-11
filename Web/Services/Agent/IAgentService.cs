using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeleniumGridManager.Web.Services.Agent
{
  public interface IAgentService
  {
    Task<ScreenshotResponse> GetScreenshot( string nodeId );
  }
}
