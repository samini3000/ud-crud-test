using FRD.Domain;

namespace FRD.Infrustructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FRDDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(FRDDbContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
