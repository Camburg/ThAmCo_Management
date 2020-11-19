using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Services
{
    public class AccountsService : IAccountsService
    {
        private HttpClient _client;

        AccountsService(HttpClient client)
        {
            _client = client;
        }

    }
}
