using cqrs_demo.Domain.Stock;
using System;
using System.Collections.Generic;

namespace cqrs_demo.Services.Stock
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();
        ICollection<Product> GetOrderProducts(Guid orderId);
        Product GetProductByReference(string reference);
        double GetProductsTotalPrice();
    }
}
