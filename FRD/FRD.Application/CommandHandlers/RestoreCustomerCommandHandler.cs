using FRD.Domain;
using MediatR;

namespace FRD.Application
{
    public class RestoreCustomerCommandHandler : IRequestHandler<RestoreCustomerCommand, CRUDCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CRUDCommandResult> Handle(RestoreCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByIdAsync(request.CustomerId);
            customer.RestoreCusomer();
            await _unitOfWork.CommitAsync();

            return new CRUDCommandResult { IsDone = true };
        }
    }
}
