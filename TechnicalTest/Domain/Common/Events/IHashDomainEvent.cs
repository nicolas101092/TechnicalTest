namespace Domain.Common.Events
{
    public interface IHashDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}
