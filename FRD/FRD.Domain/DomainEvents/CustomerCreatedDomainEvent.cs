namespace FRD.Domain
{
    public class CustomerCreatedDomainEvent : DomainEvent
    {
        public Customer customer { get; }

        public CustomerCreatedDomainEvent(Customer customer)
        {
            customer = customer;
        }
    }
}
