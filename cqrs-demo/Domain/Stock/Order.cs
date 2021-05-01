using cqrs_demo.Data;
using System;
using System.Collections.Generic;

namespace cqrs_demo.Domain.Stock
{
    public partial class Order : BaseEntity
    {
        public string Reference { get; set; }
        public bool HasDeliveryTax { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Guid DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
