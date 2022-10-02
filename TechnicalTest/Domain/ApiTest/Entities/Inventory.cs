using System.ComponentModel.DataAnnotations;

namespace Domain.ApiTest.Entities
{
    public class Inventory
    {
        #region Properties

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        #endregion

        #region Relations

        public virtual ICollection<Item>? Items { get; set; }

        #endregion
    }
}
