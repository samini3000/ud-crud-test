namespace FRD.Domain
{
    public interface ICustomerRepository 
    {
        Task AddAsync(Customer customer); 
        Task DeleteAsync(Customer entity);
        Task RestoreAsync(Customer entity);
        Task UpdateAsync(Customer entity);
        Task<Customer> FindByIdAsync(int id);
        Task<Customer> FindByEmailAsync(string Email);
        Task<(List<Customer>, int)> GetCustomersWithCountAsync(int pageIndex, int pageSize);
        bool IsCustomerExist(Customer customer);

    }
}
