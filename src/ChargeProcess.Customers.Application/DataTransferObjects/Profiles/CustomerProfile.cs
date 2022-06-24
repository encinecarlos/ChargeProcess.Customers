using AutoMapper;
using ChargeProcess.Customers.Application.Queries.GetCustomerBydocument;
using ChargeProcess.Customers.Domain.Entity;

namespace ChargeProcess.Customers.Application.DataTransferObjects.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.Document,
                    opt => opt.MapFrom(src => src.DocumentId))
                .ForMember(
                    dest => dest.Province,
                    opt => opt.MapFrom<string>(src => src.Province));
        }
    }
}
