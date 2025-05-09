namespace FRD.Application
{
    public class GetCustomerByIdQuery : IApplicationRequest<CustomerDto>
    {
        public int CustomerId {get;set;}
    }
}
