
using FRD.Domain;
using MediatR;

namespace FRD.Application
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, CRUDCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CRUDCommandResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByIdAsync(request.CustomerId);
            customer.DeleteCustomer();
            await _unitOfWork.CommitAsync();
            return new CRUDCommandResult { IsDone = true };
        }
    }
}
