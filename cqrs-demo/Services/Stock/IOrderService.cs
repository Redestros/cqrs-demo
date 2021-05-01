using cqrs_demo.Domain.Stock;
using System;
using System.Collections.Generic;

namespace cqrs_demo.Services.Stock
{
    public interface IOrderService
    {
        ICollection<Order> GetOrders();
        Order GetOrderById(Guid orderId);
        Order GetOrderByDeliveryId(Guid deliveryId);

    }
}
