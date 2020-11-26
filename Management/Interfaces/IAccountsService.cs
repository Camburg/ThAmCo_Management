﻿using Management.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Interfaces
{
    public interface IAccountsService
    {
        public Task<List<AccountDto>> GetStaffAccounts();
    }
}
