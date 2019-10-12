using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TopSwagCode.AspNetCore.Beacon.Models;

namespace TopSwagCode.AspNetCore.Beacon.Controllers
{
    public class BeaconController : Controller
    {
        private readonly ILogger<BeaconController> _logger;

        public BeaconController(ILogger<BeaconController> logger)
        {
            _logger = logger;
        }

        public ActionResult<BeaconListResponse> Index()
        {
            var response = new BeaconListResponse
            {
                Beacons = new List<string>(){"Test beacon 1", "Test beacon 2"}
            };

            return View(response);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}