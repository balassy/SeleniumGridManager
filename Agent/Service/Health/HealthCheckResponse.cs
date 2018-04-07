using System;

namespace SeleniumGridManager.Agent.Service.Health
{
	public class HealthCheckResponse
	{
		public bool Status { get; set; }

		public DateTime Timestamp { get; set; }
	}
}
