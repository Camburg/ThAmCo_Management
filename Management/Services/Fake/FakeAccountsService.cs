using Management.Dto;
using Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Services.Fake
{
    public class FakeAccountsService : IAccountsService
    {
        private List<AccountDto> accounts = new List<AccountDto>
        {
            new AccountDto
            {
                Id = Guid.NewGuid(),
                Username = "CamMack44",
                Email = "CamMack44@hotmail.com",
                Forename = "Cameron",
                Surname = "Mackenzie",
                Roles = new List<string>{"Customer"}
            },
            new AccountDto
            {
                Id = Guid.NewGuid(),
                Username = "Camburg",
                Email = "Camburg@hotmail.com",
                Forename = "Cameron",
                Surname = "Mackenzie",
                Roles = new List<string>{"Customer", "Staff"}
            },
            new AccountDto
            {
                Id = Guid.NewGuid(),
                Username = "random5078",
                Email = "minecrafterbob1998@gmail.com",
                Forename = "Luke",
                Surname = "Dobson",
                Roles = new List<string>{"Customer", "Staff", "Admin"}
            },
            new AccountDto
            {
                Id = Guid.NewGuid(),
                Username = "gligsonno1",
                Email = "gligsonno1@gmail.com",
                Forename = "Stort",
                Surname = "Gligson",
                Roles = new List<string>{"Customer", "Staff", "Admin"}
            },
            new AccountDto
            {
                Id = Guid.NewGuid(),
                Username = "wigsonno1",
                Email = "wigsonno1@gmail.com",
                Forename = "Keith",
                Surname = "Wiggy",
                Roles = new List<string>{"Customer", "Staff"}
            }
        };

        public async Task<List<AccountDto>> GetAccounts()
        {
            return accounts;
        }

        public async Task<AccountDto> GetAccount(string id)
        {
            return accounts.FirstOrDefault(x => x.Id.ToString().Equals(id));
        }

        public async Task<AccountDto> UpdateRoles(AccountDto account, Role role)
        {
            int accountPos = accounts.IndexOf(account);
            List<string> diff;

            //checks whether it needs to remove roles or add them
            if (account.Roles.Count > role.RolesList.Count)
            {
                diff = account.Roles.Except(role.RolesList).ToList();
                account.Roles = account.Roles.Except(diff).ToList();
                account.Roles = role.RolesList;
                accounts[accountPos] = account;
            }
            else if (role.RolesList.Count > account.Roles.Count)
            {
                account.Roles = role.RolesList;
                accounts[accountPos] = account;
            }

            return account;
        }
    }
}
