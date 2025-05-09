using AutoMapper;
using FRD.Domain;
using MediatR;

namespace FRD.Application
{
    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByEmailQueryHandler(ICustomerRepository  customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByEmailAsync(request.Email);
            var result = _mapper.Map<CustomerDto>(customer);
            return result;
        }
    }
}
