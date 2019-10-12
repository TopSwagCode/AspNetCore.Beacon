using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TopSwagCode.AspNetCore.Beacon.Data;
using TopSwagCode.AspNetCore.Beacon.Models;
using TopSwagCode.AspNetCore.Beacon.Services;

namespace TopSwagCode.AspNetCore.Beacon.Controllers
{
    [Route("beacon")]
    public class BeaconController : Controller
    {
        private readonly ILogger<BeaconController> _logger;
        private readonly IAnalyticsService _analyticsService;


        public BeaconController(ILogger<BeaconController> logger, IAnalyticsService analyticsService)
        {
            _logger = logger;
            _analyticsService = analyticsService;
        }

        public ActionResult<BeaconListResponse> Index()
        {
            _logger.LogWarning("Wrong Endpoint hit");

            var response = new BeaconListResponse
            {
                Beacons = new List<string>(){"Test beacon 1", "Test beacon 2"}
            };

            return View(response);
        }

        [HttpPost]
        public async Task Post()
        {
            using StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            var json = await reader.ReadToEndAsync();
            
            var beaconRequest = System.Text.Json.JsonSerializer.Deserialize<BeaconRequest>(json);

            string userId = string.Empty;
            
            if(!User.Identity.IsAuthenticated)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            await _analyticsService.InsertAnalytics(new Analytic());
            
            _logger.LogWarning(json);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}