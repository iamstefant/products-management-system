using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using NLog.Internal;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using ProductManagement.DataAccess.Models;


namespace ProductManagement.DataAccess.DbContexts
{
    public class OracleProductsDbContext : DbContext
    {
        public OracleProductsDbContext(DbContextOptions<OracleProductsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OracleProducts>(b =>
            {
                b.HasKey(e => e.ProductId);
                b.Property(e => e.ProductId).ValueGeneratedOnAdd();
            });
        }

        public DbSet<OracleProducts> OracleProducts { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=SKL-STEFA-TRAJA;initial catalog=ProductsManagement;trusted_connection=true");

            }
        }
    }
}
