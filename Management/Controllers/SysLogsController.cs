using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Management.Dto;
using Management.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Management.Models;
using Management.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management.Controllers
{
    public class SysLogsController : Controller
    {
        private readonly ILogger<SysLogsController> _logger;
        private readonly ISysLogsService _sysLogsService;
        private readonly RoleList _roles;
        private readonly List<Component> _components;
        private readonly List<Alert> _alertTypes;

        public SysLogsController(ILogger<SysLogsController> logger, ISysLogsService sysLogsService)
        {
            _logger = logger;
            _sysLogsService = sysLogsService;
            _roles = CreateRoleList();
            _components = CreateComponentList();
            _alertTypes = CreateAlertList();
        }

        //Page should have filters at the top that redirect to a filter page when used to search
        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel
            {
                AlertTypes = new SelectList(_alertTypes, "AlertId", "AlertName"),
                Components = new SelectList(_components, "ComponentId", "ComponentName"),
                Roles = new SelectList(_roles.Roles, "RoleId", "RoleName"),
                Date = DateTime.Now,
                Logs = await _sysLogsService.GetAllSystemLogs()
            };
            vm.Logs = vm.Logs.OrderByDescending(x => x.Date).ToList();

            return View(vm);
        }

        public async Task<IActionResult> FilterIndex([Bind("RoleId,AlertId,ComponentId,Date")]IndexViewModel model)
        {
            var alertType = _alertTypes.FirstOrDefault(x => x.AlertId == model.AlertId);
            var role = _roles.Roles.FirstOrDefault(x => x.RoleId == model.RoleId);
            var component = _components.FirstOrDefault(x => x.ComponentId == model.ComponentId);

            var filter = new Filter
            {
                AlertType = alertType.AlertName,
                ComponentName = component.ComponentName,
                Date = model.Date.Date,
                Role = role.RoleName
            };

            var vm = new IndexViewModel
            {
                AlertTypes = new SelectList(_alertTypes, "AlertId", "AlertName"),
                Components = new SelectList(_components, "ComponentId", "ComponentName"),
                Roles = new SelectList(_roles.Roles, "RoleId", "RoleName"),
                Logs = await _sysLogsService.GetFilteredSystemLogs(filter)
            };
            vm.Logs = vm.Logs.OrderByDescending(x => x.Date).ToList();

            return View("Index", vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private RoleList CreateRoleList()
        {
            List<Role> roleList = new List<Role>
            {
                new Role
                {
                    RoleId = 1,
                    RoleName = "ANY",
                    RolesList = new List<String>()
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Customer",
                    RolesList = new List<string>{"Customer"}
                },
                new Role
                {
                    RoleId = 3,
                    RoleName = "Staff",
                    RolesList = new List<string>{"Customer", "Staff"}
                },
                new Role
                {
                    RoleId = 4,
                    RoleName = "Admin",
                    RolesList = new List<string>{"Customer", "Staff", "Admin"}
                }
            };

            return new RoleList
            {
                Roles = roleList
            };
        }

        private List<Alert> CreateAlertList()
        {
            List<Alert> alertList = new List<Alert>
            {
                new Alert()
                {
                    AlertId = 1,
                    AlertName = AlertType.ANY
                },
                new Alert()
                {
                    AlertId = 2,
                    AlertName = AlertType.INFO
                },
                new Alert()
                {
                    AlertId = 3,
                    AlertName = AlertType.WARNING
                },
                new Alert()
                {
                    AlertId = 4,
                    AlertName = AlertType.ERROR
                }
            };
            return alertList;
        }

        private List<Component> CreateComponentList()
        {
            List<Component> componentList = new List<Component>
            {
                new Component
                {
                    ComponentId = 1,
                    ComponentName = "ANY"
                },
                new Component()
                {
                    ComponentId = 2,
                    ComponentName = "accounts"
                },
                new Component()
                {
                    ComponentId = 3,
                    ComponentName = "profile"
                },
                new Component()
                {
                    ComponentId = 4,
                    ComponentName = "orders"
                },
                new Component()
                {
                    ComponentId = 5,
                    ComponentName = "invoices"
                },
                new Component()
                {
                    ComponentId = 6,
                    ComponentName = "catalogue"
                },
                new Component()
                {
                    ComponentId = 7,
                    ComponentName = "reviews"
                },
                new Component()
                {
                    ComponentId = 8,
                    ComponentName = "stockmanagement"
                },
                new Component()
                {
                    ComponentId = 9,
                    ComponentName = "resales"
                },
                new Component()
                {
                    ComponentId = 10,
                    ComponentName = "management"
                },
                new Component()
                {
                    ComponentId = 11,
                    ComponentName = "systemlogs"
                }

            };

            return componentList;
        }
    }
}
