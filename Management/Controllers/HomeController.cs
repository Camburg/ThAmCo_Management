using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Management.Models;
using Management.Interfaces;

namespace Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISysLogsService _sysLogsService;

        public HomeController(ILogger<HomeController> logger, ISysLogsService sysLogsService)
        {
            _logger = logger;
            _sysLogsService = sysLogsService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sysLogsService.GetAllSystemLogs());
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
