using cqrs_demo.Data.Abstractions;
using cqrs_demo.Domain.Stock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cqrs_demo.Services.Stock
{
    public class DeliveryService : IDeliveryService
    {
        private readonly UnitOfWork unitOfWork;

        public DeliveryService()
        {
            unitOfWork = new UnitOfWork();
        }
        public void AssignOrChangeAssignneDelivery(Guid deliveryId, string assignee)
        {
            throw new NotImplementedException();
        }

        public ICollection<Delivery> GetDeliveries()
        {
            return unitOfWork.DeliveryRepository.Get().ToList();
        }

        public ICollection<Delivery> GetDeliveriesBetween(DateTime startDate, DateTime endDate)
        {
            return unitOfWork.DeliveryRepository.
                Get(x => x.CreationDate > startDate && x.CreationDate < endDate)
                .ToList();
        }

        public Delivery GetDelivery(Guid deliveryId)
        {
            return unitOfWork.DeliveryRepository.Get(x => x.Id == deliveryId).FirstOrDefault();
        }

        public ICollection<Delivery> GetTodayDeliveries()
        {
            return unitOfWork.DeliveryRepository.Get(x => x.CreationDate.Date == DateTime.Now.Date).ToList();
        }
    }
}
