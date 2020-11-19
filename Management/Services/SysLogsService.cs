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

    }
}
