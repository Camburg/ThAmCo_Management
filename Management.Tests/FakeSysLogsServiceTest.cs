using Management.Dto;
using Management.Enums;
using Management.Services;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Management.Tests
{
    public class FakeSysLogsServiceTest
    {
        private readonly FakeSysLogsService _service;
        private readonly IEnumerable<SystemLogDto> TestLogs = new SystemLogDto[]
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

        public FakeSysLogsServiceTest()
        {
            _service = new FakeSysLogsService();
        }

        [Fact]
        public async Task TestGetAllSystemLogsCorrectClass()
        {
            var Logs = await _service.GetAllSystemLogs();

            Assert.IsAssignableFrom<List<SystemLogDto>>(Logs);
        }

        [Fact]
        public async Task TestGetAllSystemLogsDataGiven()
        {
            List<SystemLogDto> Logs = await _service.GetAllSystemLogs();
            List<string> TestDetails = TestLogs.Select(x => x.Details).ToList();
            List<string> ActualDetails = Logs.Select(x => x.Details).ToList();

            Assert.Equal(TestDetails, ActualDetails);
        }

        [Fact]
        public async Task TestGetFilteredSystemLogs()
        {
            Filter filter = new Filter
            {
                AlertType = AlertType.ERROR,
                ComponentName = null,
                Date = default,
                Role = null
            };
            List<SystemLogDto> Logs = await _service.GetFilteredSystemLogs(filter);
            var TestDetails = "Accounts List failed to Load";
            var ActualDetails = Logs.FirstOrDefault().Details;

            Assert.Equal(TestDetails, ActualDetails);
        }
    }
}
