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
        public Task<IEnumerable<SystemLogDto>> GetAllSystemLogs();
        public Task<IEnumerable<SystemLogDto>> GetAllStaffSystemLogs();
        public Task<IEnumerable<SystemLogDto>> GetAllUserSystemLogs();
        public Task<IEnumerable<SystemLogDto>> GetFilteredSystemLogs(Filter Filter);
    }
}
