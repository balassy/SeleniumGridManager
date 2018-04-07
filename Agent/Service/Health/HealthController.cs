using System;
using System.Web.Http;

namespace SeleniumGridManager.Agent.Service.Health
{
	public class HealthController : ApiController
	{
		[AcceptVerbs("GET")]
		public HealthCheckResponse Check()
		{
			return new HealthCheckResponse { Status = true, Timestamp = DateTime.Now };
		}
	}
}
