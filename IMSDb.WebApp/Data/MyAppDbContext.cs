using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IMSDb.WebApp.Components.Models;
using IMSDb.WebApp.Components.Models.Entities;

namespace IMSDb.WebApp.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext (DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<IMSDb.WebApp.Components.Models.Product> Product { get; set; } = default!;

        public DbSet<UserAccount> UserAccounts { get; set; } = default!;

        public DbSet<ProductAudit> ProductAudits { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "admin",
                    Role = "Administrator"
                }
            );
        }
    }
}
