using System.Collections.ObjectModel;

namespace SeleniumGridManager.Web.Services.Configuration
{
  public interface IAppConfigurationService
  {
    ReadOnlyCollection<NodeConfiguration> Nodes { get; }

    NodeConfiguration GetNodeConfiguration( string nodeId );
  }
}
