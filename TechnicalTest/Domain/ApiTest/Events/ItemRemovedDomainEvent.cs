using Domain.Common.Events;
using Domain.ApiTest.Entities;

namespace Domain.ApiTest.Events
{
    public class ItemRemovedDomainEvent : DomainEvent
    {
        public Item Item { get; }

        public ItemRemovedDomainEvent(Item item)
        {
            Item = item;
        }
    }
}
