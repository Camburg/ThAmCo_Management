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
        public Task<PurchaseRequest> PutRequestStatus([FromRoute] Guid requestId, bool approval);
    }
}
