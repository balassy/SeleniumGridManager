namespace SeleniumGridManager.Web.Services.Configuration
{
  public interface IAppConfigurationService
  {
    NodeConfiguration[] Nodes { get; }

    NodeConfiguration GetNodeConfiguration( string nodeId );
  }
}
