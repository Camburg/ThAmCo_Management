using Management.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Interfaces
{
    public interface IAccountsService
    {
        public Task<List<AccountDto>> GetAccounts();

        public Task<AccountDto> GetAccount(string id);

        public Task<AccountDto> UpdateRoles(AccountDto account, Role role);
    }
}
