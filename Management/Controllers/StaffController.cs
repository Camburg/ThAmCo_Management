using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Dto;
using Management.Enums;
using Management.Interfaces;
using Management.Models;
using Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management.Controllers
{
    public class StaffController : Controller
    {
        private readonly IAccountsService _accountsService;
        private readonly ISysLogsService _sysLogsService;
        private readonly RoleList _roles;

        public StaffController(IAccountsService accountsService, ISysLogsService sysLogsService)
        {
            _accountsService = accountsService;
            _sysLogsService = sysLogsService;
            _roles = CreateRoleList();
        }

        //populates the list of accounts by calling the Accounts Service
        private async Task<List<AccountDto>> PopulateAccounts()
        {
            var accounts = await _accountsService.GetAccounts();
            //Orders the accounts so that accounts with the most roles are at the top
            accounts = accounts.OrderByDescending(x => x.Roles.Count).ToList();

            return accounts;
        }

        // GET: StaffController
        public async Task<IActionResult> Index()
        {
            //Checks whether the accounts are loaded so that the page can load
            return View(await PopulateAccounts());
        }

        // GET: StaffController/SetRoles
        public async Task<IActionResult> SetRoles(string? id)
        {
            AccountDto selectedAccount = await _accountsService.GetAccount(id);
            var roles = _roles.Roles;

            if (selectedAccount != null)
            {
                roles.RemoveAt(selectedAccount.Roles.Count - 1);
                var vm = new SetRolesViewModel
                {
                    Name = selectedAccount.Forename + " " + selectedAccount.Surname,
                    Username = selectedAccount.Username,
                    HighestRole = GetHighestRole(selectedAccount.Roles.ToList()),
                    Roles = new SelectList(roles, "RoleId", "RoleName")
                };

                return View(vm);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: StaffController/SetRoles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetRoles(string id, [Bind("RoleId")] SetRolesViewModel model)
        {
            var selectedAccount = await _accountsService.GetAccount(id);
            Role role = _roles.Roles.FirstOrDefault(x => x.RoleId == model.RoleId);

            await _accountsService.UpdateRoles(selectedAccount, role);

            await _sysLogsService.SendSystemLog("Management", "Account Updated", "Admin", AlertType.INFO);

            return View("Index", await PopulateAccounts());
        }

        private RoleList CreateRoleList()
        {
            List<Role> roleList = new List<Role>
            {
                new Role
                {
                    RoleId = 1,
                    RoleName = "Customer",
                    RolesList = new List<string>{"Customer"}
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Staff",
                    RolesList = new List<string>{"Customer", "Staff"}
                },
                new Role
                {
                    RoleId = 3,
                    RoleName = "Admin",
                    RolesList = new List<string>{"Customer", "Staff", "Admin"}
                }
            };

            return new RoleList
            {
                Roles = roleList
            };
        }

        private string GetHighestRole(List<string> roles)
        {
            string topRole;
            if (roles.Contains("Admin"))
            {
                topRole = "Admin";
            }
            else if (roles.Contains("Staff"))
            {
                topRole = "Staff";
            }
            else
            {
                topRole = "Customer";
            }

            return topRole;
        }
    }
}
