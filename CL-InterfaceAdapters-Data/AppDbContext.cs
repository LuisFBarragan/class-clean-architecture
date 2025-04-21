using CL_EnterpriseLayer;
using CL_InterfaceAdapters_Models;
using Microsoft.EntityFrameworkCore;

namespace CL_InterfaceAdapters_Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<BeerModel> Beers { get; set; }
        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<ConceptModel> Concepts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerModel>().ToTable("Beer");
            modelBuilder.Entity<SaleModel>().ToTable("Sale");
            modelBuilder.Entity<ConceptModel>().ToTable("Concept");

            modelBuilder.Entity<SaleModel>()
            .HasMany(v => v.Concepts)
            .WithOne()
            .HasForeignKey(c => c.IdSale)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
