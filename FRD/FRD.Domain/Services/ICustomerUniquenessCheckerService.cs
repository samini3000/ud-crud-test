namespace FRD.Domain
{
    public interface ICustomerUniquenessCheckerService
    {
        bool IsCustomerUnique(Customer customer);
    }
}
