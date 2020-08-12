using Microsoft.EntityFrameworkCore;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<PurchaseForm> PurchaseForm { get; set; }
    }
}
