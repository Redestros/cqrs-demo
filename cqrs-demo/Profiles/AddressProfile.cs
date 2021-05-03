using AutoMapper;
using cqrs_demo.Domain.Common;
using cqrs_demo.Models;

namespace cqrs_demo.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressModel>().ReverseMap();
        }
    }
}
