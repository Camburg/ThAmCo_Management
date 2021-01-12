using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Management.Data;
using Management.Enums;
using Management.Interfaces;
using Management.Models;
using Microsoft.Extensions.Logging;

namespace Management.Controllers
{
    public class PurchaseRequestsController : Controller
    {
        private readonly ILogger<PurchaseRequestsController> _logger;
        private readonly IStockService _stockService;
        private readonly ISysLogsService _sysLogsService;

        public PurchaseRequestsController(ILogger<PurchaseRequestsController> logger, IStockService stockService, ISysLogsService sysLogsService)
        {
            _logger = logger;
            _stockService = stockService;
            _sysLogsService = sysLogsService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _stockService.GetPurchaseRequests());
        }


        public async Task<IActionResult> AcceptRequest([FromRoute] string id)
        {
            if (await _stockService.PutRequestStatus(id, true))
            {
                await _sysLogsService.SendSystemLog("Management", "Request Accepted", "Admin", AlertType.INFO);
                return RedirectToAction("Index");
            }
            else
            {
                await _sysLogsService.SendSystemLog("Management", "Request Acception Failed", "Admin", AlertType.ERROR);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> RefuseRequest([FromRoute] string id)
        {
            if (await _stockService.PutRequestStatus(id, false))
            {
                await _sysLogsService.SendSystemLog("Management", "Request Refused", "Admin", AlertType.INFO);
                return RedirectToAction("Index");
            }
            else
            {
                await _sysLogsService.SendSystemLog("Management", "Request Refusal Failed", "Admin", AlertType.ERROR);
                return RedirectToAction("Index");
            }
        }

        [HttpPost("stock/{itemName}/{cost}")]
        public async Task<IActionResult> PostPurchaseRequest([FromRoute] string itemName, int cost)
        {
            if (await _stockService.PostPurchaseRequest(itemName, cost))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
