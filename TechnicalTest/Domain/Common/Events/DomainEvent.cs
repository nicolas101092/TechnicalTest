namespace Domain.Common.Events
{
    public abstract class DomainEvent : INotification
    {
        protected DomainEvent()
        {
            TimeStamp = DateTimeOffset.UtcNow;
        }

        public bool IsPublished { get; set; }
        public DateTimeOffset TimeStamp { get; protected set; } = DateTime.UtcNow;
    }
}
