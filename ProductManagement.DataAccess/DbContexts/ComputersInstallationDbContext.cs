using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.Models;
using System.Diagnostics.CodeAnalysis;


namespace ProductManagement.DataAccess.DbContexts
{
    public class ComputersInstallationDbContext : DbContext
    {
        public ComputersInstallationDbContext(DbContextOptions<ComputersInstallationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComputerInstallation>()
                .HasKey(bc => new { bc.ProductId, bc.ComputerId});

            modelBuilder.Entity<ComputerInstallation>()
                .HasOne(p => p.OracleProduct)
                .WithMany(pt => pt.ComputerInstallation)
                .HasForeignKey(ptk => ptk.ProductId);


            modelBuilder.Entity<ComputerInstallation>()
                .HasOne(c => c.Computer)
                .WithMany(ct => ct.ComputerInstallation)
                .HasForeignKey(ctk => ctk.ComputerId);

            //modelBuilder.Entity<Computers>()
            //    .HasMany(c => c.OracleProducts)
            //    .WithMany(p => p.Computers)
            //    .Map({ });

        }

        public DbSet<ComputerInstallation> ComputerInstallation { get; set; } = null!;
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=SKL-STEFA-TRAJA;initial catalog=ProductsManagement;trusted_connection=true");

            }
        }
    }
}
