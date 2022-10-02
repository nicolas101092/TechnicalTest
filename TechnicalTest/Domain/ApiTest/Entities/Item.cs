using Domain.Common.Events;
using System.ComponentModel.DataAnnotations;

namespace Domain.ApiTest.Entities
{
    public class Item : IHashDomainEvent
    {
        #region Properties

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(400)]
        public string Description { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }

        #region Relation properties

        public int IdInventory { get; set; }

        #endregion

        #endregion

        #region Relations

        public virtual Inventory InventoryNavigation { get; set; } = null!;

        #endregion

        #region Domain Events

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        #endregion
    }
}