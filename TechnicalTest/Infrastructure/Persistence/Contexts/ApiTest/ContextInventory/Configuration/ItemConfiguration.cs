using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.ApiTest.ContextInventory.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(item => item.InventoryNavigation)
                   .WithMany(inventory => inventory.Items)
                   .HasForeignKey(item => item.IdInventory);
        }
    }
}
