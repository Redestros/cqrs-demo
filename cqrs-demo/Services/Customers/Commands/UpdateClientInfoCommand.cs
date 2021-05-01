using cqrs_demo.CQRS;
using cqrs_demo.Models;
using System;

namespace cqrs_demo.Services.Customers.Commands
{
    public class UpdateClientInfoCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public AddressModel Address { get; }

        public UpdateClientInfoCommand(Guid id, string name, AddressModel address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
