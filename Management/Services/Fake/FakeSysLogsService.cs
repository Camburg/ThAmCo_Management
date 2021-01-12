using Management.Dto;
using Management.Enums;
using Management.Interfaces;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Management.Services.Fake
{
    public class FakeSysLogsService : ISysLogsService
    {

        private readonly List<SystemLogDto> Logs = new List<SystemLogDto>
            {
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Accounts",
                    AlertType = AlertType.INFO,
                    Role = "User",
                    Date = DateTime.Today,
                    Details = "Account Deleted"
                },
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Accounts",
                    AlertType = AlertType.INFO,
                    Role = "Staff",
                    Date = DateTime.Today,
                    Details = "Account Updated"
                },
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Accounts",
                    AlertType = AlertType.INFO,
                    Role = "User",
                    Date = DateTime.Today,
                    Details = "Account Added"
                },
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Accounts",
                    AlertType = AlertType.ERROR,
                    Role = "User",
                    Date = DateTime.Today,
                    Details = "Accounts List failed to Load"
                },
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Profile",
                    AlertType = AlertType.INFO,
                    Role = "Staff",
                    Date = DateTime.Today,
                    Details = "Profile Updated"
                },
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Accounts",
                    AlertType = AlertType.INFO,
                    Role = "User",
                    Date = DateTime.Today,
                    Details = "Account Added"
                },
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Accounts",
                    AlertType = AlertType.WARNING,
                    Role = "Staff",
                    Date = DateTime.Today,
                    Details = "Login Failed"
                },
                new SystemLogDto
                {
                    Id = Guid.NewGuid(),
                    ComponentName = "Accounts",
                    AlertType = AlertType.WARNING,
                    Role = "Management",
                    Date = DateTime.Today,
                    Details = "Login Failed"
                },

            };

        public async Task<List<SystemLogDto>> GetAllSystemLogs()
        {
            return Logs.ToList();
        }

        public async Task<List<SystemLogDto>> GetFilteredSystemLogs(Filter filter)
        {
            var returnLogs = Logs;
            if (filter.Date != default)
            {
                returnLogs = returnLogs.Where(x => x.Date == filter.Date).ToList();
            }
            if (filter.ComponentName != null)
            {
                returnLogs = returnLogs.Where(x => x.ComponentName.Equals(filter.ComponentName)).ToList();
            }
            if (filter.AlertType != AlertType.NONE)
            {
                returnLogs = returnLogs.Where(x => x.AlertType == filter.AlertType).ToList();
            }
            if (filter.Role != null)
            {
                returnLogs = returnLogs.Where(x => x.Role.Equals(filter.Role)).ToList();
            }
            return returnLogs;
        }

        public async Task<bool> SendSystemLog(string componentName, string details, string role, AlertType alertType)
        {
            return true;
        }
    }
}
