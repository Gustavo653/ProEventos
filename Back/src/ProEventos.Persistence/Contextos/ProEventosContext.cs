using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductConfiguration> ProductConfiguration { get; set; }
        public DbSet<ProductFilter> ProductFilter { get; set; }
        public DbSet<ProductFilterItem> ProductFilterItem { get; set; }
        public DbSet<ProductGrade> ProductGrade { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<ProductSubGroup> ProductSubGroup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(x => x.Configs).WithOne(x => x.Product);
        }
    }
}