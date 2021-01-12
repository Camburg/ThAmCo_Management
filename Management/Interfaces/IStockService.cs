using Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Interfaces
{
    public interface IStockService
    {
        public Task<bool> PutRequestStatus([FromRoute] string requestId, bool approval);

        public Task<bool> PostPurchaseRequest([FromRoute] string itemName, int cost);

        public Task<List<PurchaseRequest>> GetPurchaseRequests();

        public Task<PurchaseRequest> GetSpecificRequest(string id);
    }
}
