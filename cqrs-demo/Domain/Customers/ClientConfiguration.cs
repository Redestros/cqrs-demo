using cqrs_demo.Data;
using System;

namespace cqrs_demo.Domain.Customers
{
    public partial class ClientConfiguration : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public double DeliveryTax { get; set; }
        public bool DeliveryTaxEnabled { get; set; }
        public bool PromotionEnabled { get; set; }
        public double Promotion { get; set; }
        public DateTime PromotionStartDate { get; set; }
        public DateTime PromotionEndDate { get; set; }
        public virtual Client Customer { get; set; }
    }
}
