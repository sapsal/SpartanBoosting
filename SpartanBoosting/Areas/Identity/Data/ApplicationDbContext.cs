using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models;
using SpartanBoosting.Models.Pricing;

namespace SpartanBoosting.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PurchaseForm> PurchaseForm { get; set; }
        public DbSet<DiscountModel> Discount { get; set; }
        public DbSet<ChatModel> ChatModel { get; set; }
        public DbSet<LeagueOfLegendsAuditModel> LeagueOfLegendsAuditModel { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
