using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductManagement.DataAccess.DbContexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComputerInstallation>().HasKey(sc => new { sc.ProductId, sc.ComputerId});

            modelBuilder.Entity<ComputerInstallation>()
             .HasOne(p => p.OracleProduct)
             .WithMany(pt => pt.ComputerInstallation)
             .HasForeignKey(ptk => ptk.ProductId);


            modelBuilder.Entity<ComputerInstallation>()
                .HasOne(c => c.Computer)
                .WithMany(ct => ct.ComputerInstallation)
                .HasForeignKey(ctk => ctk.ComputerId);


        }

        public DbSet<Computer> Computer { get; set; } = null!;
        public DbSet<OracleProduct> OracleProduct { get; set; } = null!;
        public DbSet<ComputerInstallation> ComputerInstallation { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("data source=SKL-STEFA-TRAJA;initial catalog=ProductsManagement;trusted_connection=true");
                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProductsManagementDbConnection"));
            }
        }

    }
}
