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
    }
}
