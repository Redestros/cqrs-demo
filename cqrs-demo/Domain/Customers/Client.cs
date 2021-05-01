using cqrs_demo.Data;
using cqrs_demo.Domain.Common;
using cqrs_demo.Domain.Stock;
using System.Collections.Generic;

namespace cqrs_demo.Domain.Customers
{
    public partial class Client : BaseEntity
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public virtual Address Address { get; set; }
        public virtual ClientConfiguration Configuration { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
