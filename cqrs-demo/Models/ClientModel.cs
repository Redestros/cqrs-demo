using System;

namespace cqrs_demo.Models
{
    public class ClientModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public AddressModel Address { get; set; }
    }
}
