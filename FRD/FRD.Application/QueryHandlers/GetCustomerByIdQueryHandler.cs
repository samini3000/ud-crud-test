using AutoMapper;
using FRD.Domain;
using MediatR;
using System.Net.Http.Headers;

namespace FRD.Application
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindByIdAsync(request.CustomerId);
            var result = _mapper.Map<CustomerDto>(customer);
            return result;
        }
    }
}
