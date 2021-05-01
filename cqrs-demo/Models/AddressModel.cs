using System;

namespace cqrs_demo.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        //public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}
