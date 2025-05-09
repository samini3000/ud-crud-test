namespace FRD.Application
{
    public class GetCustomersListQuery : IApplicationRequest<PaginatedList<CustomerDto>>//should be paginatedlist
    {
        //complete according to paginated list
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
