namespace FRD.Application
{
    public class DeleteCustomerCommand : IApplicationRequest<CRUDCommandResult>
    {
        public int CustomerId {  get; set; }
    }
}
