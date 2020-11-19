using Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Data
{
    public class ManagementDbContext : DbContext
    {
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
