using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Item
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
    }
}