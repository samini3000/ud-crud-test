using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace FRD.Domain
{
    public class Customer : AggregateRoot<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }//change type
        public DateTime DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
        protected Customer(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, string bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            BankAccountNumber = bankAccountNumber;
            AddDomainEvent(new CustomerCreatedDomainEvent(this));
        }

        public static Customer CreateNewCustomer(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, string bankAccountNumber, ICustomerUniquenessCheckerService customerUniquenessCheckerService)
        {
            var customer = new Customer(firstName, lastName, email, phoneNumber, dateOfBirth, bankAccountNumber);
            if (customerUniquenessCheckerService != null && !customerUniquenessCheckerService.IsCustomerUnique(customer))
                throw new Exception("customer not unique");

            return customer;

        }
        public void DeleteCustomer()
        {
            this.IsDeleted = true;
            AddDomainEvent(new CustomerDeletedDomainEvent(this));
        }

        public void RestoreCusomer()
        {
            this.IsDeleted = false;
            AddDomainEvent(new CustomerRestoredDomainEvent(this));
        }

        public void UpdateCustomer(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, string bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            BankAccountNumber = bankAccountNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            AddDomainEvent(new CustomerUpdatedDomainEvent(this));
        }

        private readonly List<DomainEvent> _domainEvents = new();
        private IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }

}
