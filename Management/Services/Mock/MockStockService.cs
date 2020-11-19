﻿using Management.Interfaces;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Management.Services
{
    public class MockStockService : IStockService
    {
        private readonly HttpClient _client;

        MockStockService(HttpClient client)
        {
            _client = client;
        }

        public Task<PurchaseRequest> PutRequestStatus([FromBody] Guid requestId, bool approval)
        {
            throw new NotImplementedException();
        }
    }
}
