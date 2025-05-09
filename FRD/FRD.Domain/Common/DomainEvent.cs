namespace FRD.Domain
{
    public abstract class DomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
