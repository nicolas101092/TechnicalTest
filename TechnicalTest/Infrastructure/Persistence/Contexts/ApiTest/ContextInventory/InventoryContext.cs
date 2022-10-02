using Domain.ApiTest.Entities;
using Domain.Common.Events;
using Infrastructure.Persistence.Contexts.ApiTest.ContextInventory.Configuration;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Contexts.ApiTest.ContextInventory
{
    public class InventoryContext : ApiTestContext
    {
        private readonly IPublisher _publisher = null!;
        private readonly ILogger<InventoryContext> _logger = null!;

        #region Properties

        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

        #endregion

        public InventoryContext(DbContextOptions options) : base(options)
        {
        }

        public InventoryContext(DbContextOptions options, IPublisher publisher, ILogger<InventoryContext> logger) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            var events = ChangeTracker.Entries<IHashDomainEvent>()
                                      .Select(x => x.Entity.DomainEvents)
                                      .SelectMany(x => x)
                                      .Where(domainEvent => !domainEvent.IsPublished )
                                      .ToArray();

            foreach (var @event in events)
            {
                @event.IsPublished = true;

                _logger.LogInformation("New domain event {Event}", @event.GetType().Name);

                await _publisher.Publish(@event);
            }

            return result;
        }
    }
}
