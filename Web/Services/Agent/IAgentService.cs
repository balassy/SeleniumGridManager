using System.Threading.Tasks;

namespace SeleniumGridManager.Web.Services.Agent
{
  public interface IAgentService
  {
    Task<ScreenshotResponse> GetScreenshot( string nodeId );

    Task TerminateProcess( string nodeId );
  }
}
