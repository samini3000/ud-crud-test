
using Microsoft.EntityFrameworkCore;
namespace FRD.Application
{
    public class PaginatedList<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int TotalCount { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public PaginatedList()
        {
            
        }

        public PaginatedList(IReadOnlyList<T> items, int totalCount, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await source.CountAsync(cancellationToken);
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
            throw new NotImplementedException();
        }
    }

}
