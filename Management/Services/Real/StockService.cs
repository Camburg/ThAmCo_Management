using Management.Interfaces;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Management.Data;

namespace Management.Services.Real
{
    public class StockService : IStockService
    {
        private readonly HttpClient _client;
        private readonly ManagementDbContext _context;

        StockService(HttpClient client, ManagementDbContext context)
        {
            _client = client;
            _context = context;
        }

        public async Task<PurchaseRequest> PutRequestStatus([FromBody] Guid requestId, bool approval)
        {
            throw new NotImplementedException();
        }
    }
}
