using Domain.Entities;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory.Configuration;

namespace Infrastructure.Persistence.Contexts.ApiTest.ContextInventory
{
    public class InventoryContext : ApiTestContext
    {
        #region Properties

        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

        #endregion

        public InventoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
