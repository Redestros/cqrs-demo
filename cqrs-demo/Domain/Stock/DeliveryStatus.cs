namespace cqrs_demo.Domain.Stock
{
    public enum DeliveryStatus
    {
        InVendorStock = 10,
        InRammusStock = 20,
        OnRoad = 30,
        Delivered = 40,
        Canceled = 50
    }
}
