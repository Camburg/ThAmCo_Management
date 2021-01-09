using Management.Dto;
using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Management.Services
{
    public class AccountsService : IAccountsService
    {
        private HttpClient _client;
        private List<AccountDto> accounts;

        AccountsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AccountDto>> GetAccounts()
        {
            _client.BaseAddress = new System.Uri("");
            _client.DefaultRequestHeaders.Accept.ParseAdd("");

            HttpResponseMessage response = await _client.GetAsync("account/Accounts?page=1");

            if (response.IsSuccessStatusCode)
            {
                var accountsIn = await response.Content.ReadFromJsonAsync<IEnumerable<AccountDto>>();
                accounts = accountsIn.ToList();
            }
            else
            {
                accounts = new List<AccountDto>();
            }

            return accounts;
        }
    }
}
