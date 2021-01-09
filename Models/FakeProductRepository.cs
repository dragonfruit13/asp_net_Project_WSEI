using System;
using System.Collections.Generic;
using System.Linq;

namespace asp_net_Project_WSEI.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{ ProductName = "Basketball", ProductPrice = 25 }
        }.AsQueryable<Product>();

        public Product RemoveProduct(int productID)
        {

            throw new NotImplementedException();

        }

        public void SaveProduct(Product product)
        {

            throw new NotImplementedException();

        }
    }
}
