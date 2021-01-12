using Management.Interfaces;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Management.Data;
using Microsoft.EntityFrameworkCore;

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

        //Sends the updated request status to the Stock Management Component
        public async Task<bool> PutRequestStatus(string requestId, bool approval)
        {
            var logs = await _context.PurchaseRequests.Where(x => x.Id.ToString() == requestId).ToListAsync();
            //Put the request status in the Stock Management Component here
            
            //Removes unneeded value from the database
            var log = logs.FirstOrDefault();
            if (log != null)
            {
                _context.PurchaseRequests.Remove(log);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Takes the Item's Name and Cost and adds it to the database of 
        public async Task<bool> PostPurchaseRequest(string itemName, int cost)
        {
            if (itemName == null || itemName.Equals("") || cost == 0)
            {
                return false;
            }
            else
            {
                var purchaseRequest = new PurchaseRequest
                {
                    Accepted = false,
                    Cost = cost,
                    Id = Guid.NewGuid(),
                    ItemName = itemName
                };

                _context.Add(purchaseRequest);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<PurchaseRequest>> GetPurchaseRequests()
        {
            var systemLogs = await _context.PurchaseRequests.ToListAsync();
            return systemLogs;
        }
    }
}
