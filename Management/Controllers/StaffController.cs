using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    public class StaffController : Controller
    {
        private List<AccountDto> accounts;

        private void PopulateAccounts()
        {

        }

        // GET: StaffController
        public ActionResult Index()
        {
            return View(accounts);
        }

        // GET: StaffController/SetRoles
        public ActionResult SetRoles()
        {
            return View();
        }

        // POST: StaffController/SetRoles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetRoles(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
}
