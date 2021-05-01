using cqrs_demo.Data;
using System;

namespace cqrs_demo.Domain.Stock
{
    public partial class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
