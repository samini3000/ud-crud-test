using AutoMapper;
using FRD.Domain;

namespace FRD.Application
{
    public class mapperConfig : Profile
    {
        public mapperConfig()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }
            
        
    }
}
