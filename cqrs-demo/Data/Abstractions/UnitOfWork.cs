using cqrs_demo.Domain.Customers;
using cqrs_demo.Domain.Stock;
using System;

namespace cqrs_demo.Data.Abstractions
{
    public class UnitOfWork : IDisposable
    {

        private readonly ApplicationDBContext context = new ApplicationDBContext();

        private GenericRepository<Client> clientRepository;
        private GenericRepository<ClientConfiguration> clientConfigurationRepository;

        private GenericRepository<Delivery> deliveryRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Product> productRepository;

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new GenericRepository<Client>(context);
                }
                return clientRepository;
            }

        }

        public GenericRepository<ClientConfiguration> ClientConfigurationRepository
        {
            get
            {
                if (clientConfigurationRepository == null)
                {
                    clientConfigurationRepository = new GenericRepository<ClientConfiguration>(context);
                }
                return clientConfigurationRepository;
            }
        }

        public GenericRepository<Delivery> DeliveryRepository
        {
            get
            {
                if (deliveryRepository == null)
                {
                    deliveryRepository = new GenericRepository<Delivery>(context);
                }
                return deliveryRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
