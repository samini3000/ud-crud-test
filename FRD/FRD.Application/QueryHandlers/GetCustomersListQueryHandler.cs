using AutoMapper;
using FRD.Domain;
using MediatR;

namespace FRD.Application
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, PaginatedList<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CustomerDto>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var(customers, totalCount) = await _customerRepository.GetCustomersWithCountAsync(request.PageIndex, request.PageSize);
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);
            
            return new PaginatedList<CustomerDto>(customerDtos, totalCount, request.PageIndex, request.PageSize);
        }
    }
}
