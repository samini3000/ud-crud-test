using FRD.Domain;
namespace FRD.Infrustructure
{
    public class CustomerUniquenessCheckerService : ICustomerUniquenessCheckerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUniquenessCheckerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool IsCustomerUnique(Customer customer)
        {
            return _customerRepository.IsCustomerExist(customer);
        }
    }
}
