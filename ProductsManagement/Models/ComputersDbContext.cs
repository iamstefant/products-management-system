using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ProductsManagement.Models
{
    public class ComputersDbContext : DbContext
    {
        public ComputersDbContext(DbContextOptions<ComputersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computers>(b =>
            {
                b.HasKey(e => e.ComputerId);
                b.Property(e => e.ComputerId).ValueGeneratedOnAdd();
            });
        }

        public DbSet<Computers> Computers { get; set; } = null!;
    }
}
