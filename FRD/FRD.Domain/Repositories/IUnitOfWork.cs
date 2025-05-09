namespace FRD.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(); // Save changes
    }
}
