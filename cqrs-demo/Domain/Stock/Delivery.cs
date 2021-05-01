using cqrs_demo.Data;

namespace cqrs_demo.Domain.Stock
{
    public partial class Delivery : BaseEntity
    {
        public string Reference { get; set; }
        public string ClientNumber { get; set; }
        public string ClientAddress { get; set; }
        public int DeliveryStatusId { get; set; }
        public string Assignee { get; set; }
        public DeliveryStatus Deliverystatus
        {
            get => (DeliveryStatus) DeliveryStatusId;
            set => DeliveryStatusId = (int) value;
        }
        public virtual Order Order { get; set; }
    }
}
