using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BasicGrpcSample.WebClient.Models;

namespace BasicGrpcSample.WebClient.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Server.Greeter.GreeterClient _greeter;

		public HomeController(ILogger<HomeController> logger, Server.Greeter.GreeterClient greeter)
		{
			_logger = logger;
			_greeter = greeter;
		}

		public async Task<IActionResult> IndexAsync()
		{
			var response = await _greeter.SayHelloAsync(new Server.HelloRequest { Name = "Kevin" });
			return View(response);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
