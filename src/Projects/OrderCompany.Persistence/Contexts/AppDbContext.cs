using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderCompany.Domain.Entities;

namespace OrderCompany.Persistence.Contexts
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CarrierReport> CarrierReports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Carrier> Carriers{ get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations{ get; set; }
    }
}
