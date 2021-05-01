using cqrs_demo.Data.Abstractions;
using cqrs_demo.Domain.Stock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cqrs_demo.Services.Stock
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork unitOfWork;

        public OrderService()
        {
            unitOfWork = new UnitOfWork();
        }
        public Order GetOrderByDeliveryId(Guid deliveryId)
        {
            return unitOfWork.OrderRepository.Get(x => x.DeliveryId == deliveryId).ToList().FirstOrDefault();
        }

        public Order GetOrderById(Guid orderId)
        {
            return unitOfWork.OrderRepository.GetByID(orderId);
        }

        public ICollection<Order> GetOrders()
        {
            return unitOfWork.OrderRepository.Get().ToList();
        }

        Order IOrderService.GetOrderByDeliveryId(Guid deliveryId)
        {
            throw new NotImplementedException();
        }

        Order IOrderService.GetOrderById(Guid orderId)
        {
            throw new NotImplementedException();
        }

        ICollection<Order> IOrderService.GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
