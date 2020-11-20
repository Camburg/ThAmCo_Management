using Management.Dto;
using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Services
{
    public class SysLogsService : ISysLogsService
    {
        private HttpClient _client;

        SysLogsService(HttpClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<SystemLogDto>> GetAllStaffSystemLogs()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SystemLogDto>> GetAllSystemLogs()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SystemLogDto>> GetAllUserSystemLogs()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SystemLogDto>> GetFilteredSystemLogs()
        {
            throw new NotImplementedException();
        }
    }
}
