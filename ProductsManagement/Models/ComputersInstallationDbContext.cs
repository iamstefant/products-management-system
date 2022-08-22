using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ProductsManagement.Models
{
    public class ComputersInstallationDbContext : DbContext
    {
        public ComputersInstallationDbContext(DbContextOptions<ComputersInstallationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ComputersInstallation>()
            //    .HasOne(x => x.ProductId)
            //    .WithMany( )
        }

        public DbSet<ComputersInstallation> ComputersInstallation { get; set; } = null!;

    }
}
