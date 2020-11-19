using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Services
{
    public class MockSysLogsService : ISysLogsService
    {
        private HttpClient _client;

        MockSysLogsService(HttpClient client)
        {
            _client = client;
        }

    }
}
