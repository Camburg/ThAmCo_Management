using Management.Dto;
using Management.Interfaces;
using Management.Models;
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

        public async Task<List<SystemLogDto>> GetAllStaffSystemLogs()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SystemLogDto>> GetAllSystemLogs()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SystemLogDto>> GetAllUserSystemLogs()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SystemLogDto>> GetFilteredSystemLogs(Filter Filter)
        {
            throw new NotImplementedException();
        }
    }
}
