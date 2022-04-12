using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using gadgets.Domain;
namespace gadgets.Persistance.EntityTypeConfiguration
{
    public class gadgetsConfiguration : IEntityTypeConfiguration<gadget>
    {
        public void Configure(EntityTypeBuilder<gadget> builder)
        {
            builder.HasKey(g => g.Id);
            builder.HasIndex(g => g.Id).IsUnique();
            builder.Property(g => g.Title).HasMaxLength(250);
        }
    }
}
