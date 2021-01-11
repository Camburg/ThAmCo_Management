using Management.Dto;
using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Management.Services.Real
{
    public class AccountsService : IAccountsService
    {
        private HttpClient _client;

        public AccountsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AccountDto>> GetAccounts()
        {
            List<AccountDto> accounts;

            _client.BaseAddress = new System.Uri("https://thamco-accounts.azurewebsites.net/");

            var response = await _client.GetAsync("account/Accounts");

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

        public async Task<AccountDto> GetAccount(string id)
        {
            var account = new AccountDto();

            _client.BaseAddress = new System.Uri("https://thamco-accounts.azurewebsites.net/");

            HttpResponseMessage response = await _client.GetAsync("id/" + id);

            if (response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadFromJsonAsync<AccountDto>();
            }

            return account;
        }

        //Updates the roles of the account to be the Role given
        public async Task<AccountDto> UpdateRoles(AccountDto account, Role role)
        {
            _client.BaseAddress = new System.Uri("https://thamco-accounts.azurewebsites.net/");
            HttpResponseMessage response;
            List<string> diff;
            List<string> def = new List<string>{"Customer"};
            
            //checks whether it needs to remove roles or add them
            if (account.Roles.Count > role.RolesList.Count)
            {
                diff = account.Roles.Except(role.RolesList).ToList();
                if (diff.Count == 2)
                {
                    await RemoveRole(account, "Admin");
                    await RemoveRole(account, "Staff");
                }
                else
                {
                    await RemoveRole(account, diff.FirstOrDefault().ToString());
                }
                account.Roles = role.RolesList;
            }
            else if (role.RolesList.Count > account.Roles.Count)
            {
                diff = role.RolesList.Except(account.Roles).ToList();
                foreach(string rl in diff)
                {
                    await AddRole(account, rl);
                }
                account.Roles = role.RolesList;
            }

            return account;
        }

        private async Task RemoveRole(AccountDto account, string role)
        {
            _client.BaseAddress = new System.Uri("https://thamco-accounts.azurewebsites.net/");
            HttpResponseMessage response = await _client.PutAsync($"removeRole/{account.Id}/{role}", null);
        }

        private async Task AddRole(AccountDto account, string role)
        {
            _client.BaseAddress = new System.Uri("https://thamco-accounts.azurewebsites.net/");
            HttpResponseMessage response = await _client.PutAsync($"addRole/{account.Id}/{role}", null);
        }
    }
}
