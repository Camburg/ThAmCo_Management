using Management.Dto;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Management.Interfaces
{
    //SysLogsService makes HTTP calls to the System Logs component in order to get these values
    public interface ISysLogsService
    {
        public Task<List<SystemLogDto>> GetAllSystemLogs();
        public Task<List<SystemLogDto>> GetFilteredSystemLogs(Filter filter);
        public Task<bool> SendSystemLog(string componentName, string details, string role, AlertType alertType);
    }
}
