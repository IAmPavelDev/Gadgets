using Microsoft.EntityFrameworkCore;
using gadgets.Application.Interfaces;
using gadgets.Domain;
using gadgets.Persistance.EntityTypeConfiguration;

namespace gadgets.Persistance
{
    public class gadgetsDbContext : DbContext, IgadgetsDbContext
    {
        public DbSet<gadget> gadgets { get; set; }
        public gadgetsDbContext(DbContextOptions<gadgetsDbContext> options)
            : base(options) {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new gadgetsConfiguration());
            base.OnModelCreating(builder);

        }
    }
}
