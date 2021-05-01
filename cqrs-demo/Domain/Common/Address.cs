using cqrs_demo.Data;
using cqrs_demo.Domain.Customers;
using System;

namespace cqrs_demo.Domain.Common
{
    public partial class Address : BaseEntity
    {
        public string Email { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Client Customer { get; set; }
    }
}
