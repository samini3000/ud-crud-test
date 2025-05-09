namespace FRD.Domain
{
    internal class CustomerRestoredDomainEvent : DomainEvent
    {
        public Customer customer { get; }

        public CustomerRestoredDomainEvent(Customer order)
        {
            customer = order;
        }
    }
}
