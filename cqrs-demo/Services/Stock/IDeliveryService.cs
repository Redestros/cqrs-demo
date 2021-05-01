using cqrs_demo.Domain.Stock;
using System;
using System.Collections.Generic;

namespace cqrs_demo.Services.Stock
{
    public interface IDeliveryService
    {
        ICollection<Delivery> GetDeliveries();
        ICollection<Delivery> GetTodayDeliveries();
        ICollection<Delivery> GetDeliveriesBetween(DateTime startDate, DateTime endDate);
        Delivery GetDelivery(Guid deliveryId);
        void AssignOrChangeAssignneDelivery(Guid deliveryId, string assignee);
    }
}
