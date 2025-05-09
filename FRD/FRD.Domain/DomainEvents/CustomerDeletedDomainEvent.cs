namespace FRD.Domain
{
    internal class CustomerDeletedDomainEvent :DomainEvent
    {
        public Customer customer { get; }

        public CustomerDeletedDomainEvent(Customer order)
        {
            customer = order;
        }
    }
}
