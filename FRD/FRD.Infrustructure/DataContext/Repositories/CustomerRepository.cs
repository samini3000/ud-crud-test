using FRD.Domain;
using Microsoft.EntityFrameworkCore;

namespace FRD.Infrustructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FRDDbContext _fRDDbContext;
        public CustomerRepository(FRDDbContext fRDDbContext)
        {
            _fRDDbContext = fRDDbContext;
        }

        public async Task AddAsync(Customer customer)
        {
            await _fRDDbContext.Set<Customer>().AddAsync(customer);
        }

        public async Task DeleteAsync(Customer entity)
        {
            if (entity is ISoftDelete softDeletable)
            {
                softDeletable.IsDeleted = true;
                _fRDDbContext.Update(entity);
            }
            else
            {
                _fRDDbContext.Remove(entity);
            }

            await Task.CompletedTask;

        }

        public async Task RestoreAsync(Customer entity)
        {
            if (entity is ISoftDelete softDeletable)
            {
                softDeletable.IsDeleted = false;
                _fRDDbContext.Update(entity);
            }

            await Task.CompletedTask;

        }

        public async Task<Customer?> FindByIdAsync(int id)
        {
            return await _fRDDbContext.Customers.FindAsync( id);
        }

        public async  Task UpdateAsync(Customer entity)
        {
            _fRDDbContext.Customers.Update(entity);
            await Task.CompletedTask;
        }

        public async Task<Customer> FindByEmailAsync(string Email)
        {
            return await _fRDDbContext.Customers.Where(x => x.Email == Email).SingleOrDefaultAsync();
        }

        public async Task<(List<Customer>, int)> GetCustomersWithCountAsync(int pageIndex, int pageSize)
        {
            var query = _fRDDbContext.Customers.AsQueryable();

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public bool IsCustomerExist(Customer customer)
        {
            return !_fRDDbContext.Customers.Where(x=>x.FirstName == customer.FirstName 
                                            &&  x.LastName == customer.LastName 
                                            && x.Email == customer.Email ).Any();
        }
    }
}
