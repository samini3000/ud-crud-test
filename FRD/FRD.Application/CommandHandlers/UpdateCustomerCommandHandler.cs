using FRD.Domain;
using MediatR;

namespace FRD.Application
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CRUDCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CRUDCommandResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByIdAsync(request.CustomerId);
            customer.UpdateCustomer(request.FirstName, request.LastName, request.Email, request.PhoneNumber, request.DateOfBirth, request.BankAccountNumber);
            await _unitOfWork.CommitAsync();
            return new CRUDCommandResult { IsDone = true };
        }
    }
}
