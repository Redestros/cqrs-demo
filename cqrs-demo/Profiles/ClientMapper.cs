using AutoMapper;
using cqrs_demo.Domain.Customers;
using cqrs_demo.Models;
using cqrs_demo.Services.Customers.Commands;

namespace cqrs_demo.Profiles
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<RegisterClientCommand, Client>();
            CreateMap<Client, ClientModel>();
        }
    }
}
