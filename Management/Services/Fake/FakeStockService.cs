using Management.Interfaces;
using Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Management.Services.Fake
{
    public class FakeStockService : IStockService
    {
        private static readonly List<PurchaseRequest> requests = new List<PurchaseRequest>
        {
            new PurchaseRequest()
            {
                Accepted = false,
                Cost = 16032,
                Id = Guid.NewGuid(),
                ItemName = "Magic Moonbeams"
            },
            new PurchaseRequest()
            {
                Accepted = true,
                Cost = 53213,
                Id = Guid.NewGuid(),
                ItemName = "Wiggy Worm"
            },
            new PurchaseRequest()
            {
                Accepted = false,
                Cost = 519329,
                Id = Guid.NewGuid(),
                ItemName = "Dog Friend"
            },
            new PurchaseRequest()
            {
                Accepted = false,
                Cost = 36032,
                Id = Guid.NewGuid(),
                ItemName = "Magic Moonbeams 2"
            },
            new PurchaseRequest()
            {
                Accepted = true,
                Cost = 1003,
                Id = Guid.NewGuid(),
                ItemName = "Ryan's Mega Monday Juice"
            },
        };

        public async Task<bool> PutRequestStatus(string requestId, bool approval)
        {
            var request = requests.FirstOrDefault(x => x.Id.ToString() == requestId);

            if (request == default)
            {
                return false;
            }
            else
            {
                requests.Remove(request);
                return true;
            }
        }

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

                return true;
            }
        }

        public async Task<List<PurchaseRequest>> GetPurchaseRequests()
        {
            return requests;
        }

        public async Task<PurchaseRequest> GetSpecificRequest(string id)
        {
            return requests.FirstOrDefault(x => x.Id.ToString().Equals(id));
        }
    }
}
