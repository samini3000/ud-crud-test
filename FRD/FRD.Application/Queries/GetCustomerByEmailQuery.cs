namespace FRD.Application
{
    public class GetCustomerByEmailQuery : IApplicationRequest<CustomerDto>
    {
        public string Email { get; set; }
    }
}
