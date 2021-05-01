using cqrs_demo.Data.Abstractions;
using cqrs_demo.Domain.Stock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cqrs_demo.Services.Stock
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork unitOfWork;

        public ProductService()
        {
            unitOfWork = new UnitOfWork();
        }
        public ICollection<Product> GetOrderProducts(Guid orderId)
        {
            return unitOfWork.ProductRepository.Get(x => x.OrderId == orderId).ToList();
        }

        public Product GetProductByReference(string reference)
        {
            return unitOfWork.ProductRepository.Get(x => x.Reference.Equals(reference)).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return unitOfWork.ProductRepository.Get().ToList();
        }

        public double GetProductsTotalPrice()
        {
            return unitOfWork.ProductRepository.Get().Select(x => x.Price).Sum();
        }
    }
}
