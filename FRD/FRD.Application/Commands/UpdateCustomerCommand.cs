namespace FRD.Application
{
    public class UpdateCustomerCommand : IApplicationRequest<CRUDCommandResult>
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }//change type
        public DateTime DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
