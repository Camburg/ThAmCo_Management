using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Models
{
    public class PurchaseRequest
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public int Cost { get; set; }
        public bool Accepted { get; set; }
    }
}
