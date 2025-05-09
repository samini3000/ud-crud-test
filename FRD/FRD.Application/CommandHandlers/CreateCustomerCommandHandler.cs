using FRD.Domain;
using MediatR;

namespace FRD.Application
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CRUDCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerUniquenessCheckerService _customerUniquenessCheckerService;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, ICustomerUniquenessCheckerService customerUniquenessCheckerService)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _customerUniquenessCheckerService = customerUniquenessCheckerService;
        }
        public async Task<CRUDCommandResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = Customer.CreateNewCustomer(request.FirstName, request.LastName, request.Email, request.PhoneNumber, request.DateOfBirth, request.BankAccountNumber, _customerUniquenessCheckerService);
           
            await _customerRepository.AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();

            return new CRUDCommandResult { IsDone = true };
        }
    }
}
