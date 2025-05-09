using FRD.Domain;
using Microsoft.EntityFrameworkCore;

namespace FRD.Infrustructure
{
    public class FRDDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public FRDDbContext(DbContextOptions<FRDDbContext> options) : base(options) { }
    }
}
