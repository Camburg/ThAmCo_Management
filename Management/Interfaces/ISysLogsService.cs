using Management.Dto;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Interfaces
{
    //SysLogsService makes HTTP calls to the System Logs component in order to get these values
    public interface ISysLogsService
    {
        public Task<List<SystemLogDto>> GetAllSystemLogs();
        public Task<List<SystemLogDto>> GetAllStaffSystemLogs();
        public Task<List<SystemLogDto>> GetAllUserSystemLogs();
        public Task<List<SystemLogDto>> GetFilteredSystemLogs(Filter Filter);
    }
}
