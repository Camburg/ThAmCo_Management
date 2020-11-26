using Management.Dto;
using Management.Enums;
using Management.Interfaces;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Services
{
    public class FakeSysLogsService : ISysLogsService
    {

        private readonly SystemLogDto[] Logs =
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

        public async Task<IEnumerable<SystemLogDto>> GetAllStaffSystemLogs()
        {
            return Logs.Where(x => x.Role.Equals("Staff", StringComparison.CurrentCulture));
        }

        public async Task<IEnumerable<SystemLogDto>> GetAllSystemLogs()
        {
            return Logs;
        }

        public async Task<IEnumerable<SystemLogDto>> GetAllUserSystemLogs()
        {
            return Logs.Where(x => x.Role.Equals("User", StringComparison.CurrentCulture));
        }

        public async Task<IEnumerable<SystemLogDto>> GetFilteredSystemLogs(Filter Filter)
        {
            IEnumerable<SystemLogDto> returnLogs = Logs;
            if (Filter.Date != default)
            {
                returnLogs = returnLogs.Where(x => x.Date == Filter.Date);
            }
            if (Filter.ComponentName != null)
            {
                returnLogs = returnLogs.Where(x => x.ComponentName.Equals(Filter.ComponentName));
            }
            if (Filter.AlertType != AlertType.NONE)
            {
                returnLogs = returnLogs.Where(x => x.AlertType == Filter.AlertType);
            }
            if (Filter.Role != null)
            {
                returnLogs = returnLogs.Where(x => x.Role.Equals(Filter.Role));
            }
            return returnLogs;
        }
    }
}
