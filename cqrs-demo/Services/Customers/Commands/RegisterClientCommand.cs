using cqrs_demo.CQRS;
using cqrs_demo.Domain.Common;

namespace cqrs_demo.Services.Customers.Commands
{
    public class RegisterClientCommand : ICommand
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public Address Address { get; set; }

        public RegisterClientCommand()
        {

        }
        public RegisterClientCommand(string name, string registrationNumber, Address address)
        {
            Name = name;
            RegistrationNumber = registrationNumber;
            Address = address;
        }
    }
}
