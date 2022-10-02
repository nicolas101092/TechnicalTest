using Domain.Entities;

namespace Infrastructure.Persistence.Contexts.ApiTest.ContextInventory.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasIndex(u => u.Name)
                   .IsUnique();

            builder.HasOne(item => item.InventoryNavigation)
                   .WithMany(inventory => inventory.Items)
                   .HasForeignKey(item => item.IdInventory);
        }
    }
}
