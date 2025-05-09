namespace FRD.Application
{
    public class RestoreCustomerCommand : IApplicationRequest<CRUDCommandResult>
    {
        public int CustomerId {  get; set; }
    }
}
