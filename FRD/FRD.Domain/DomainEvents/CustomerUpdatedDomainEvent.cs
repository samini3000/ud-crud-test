namespace FRD.Domain
{
    internal class CustomerUpdatedDomainEvent : DomainEvent
    {
        public Customer customer { get; }

        public CustomerUpdatedDomainEvent(Customer order)
        {
            customer = order;
        }
    }
}
