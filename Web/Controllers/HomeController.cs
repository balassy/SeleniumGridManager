using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SeleniumGridManager.Web.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}

		public IActionResult Error()
		{
			this.ViewData[ "RequestId" ] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
			return View();
		}
	}
}
