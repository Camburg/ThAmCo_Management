using Management.Dto;
using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Services
{
    public class FakeAccountsService : IAccountsService
    {
        public Task<IEnumerable<AccountDto>> GetStaffAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
