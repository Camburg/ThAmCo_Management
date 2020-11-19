using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Services
{
    public class MockAccountsService : IAccountsService
    {
        private HttpClient _client;

        MockAccountsService(HttpClient client)
        {
            _client = client;
        }

    }
}
