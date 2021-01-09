using System.Linq;

namespace asp_net_Project_WSEI.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly AppDbContext _ctx;

        public EFProductRepository(AppDbContext ctx)
        {
            this._ctx = ctx;
        }
        public IQueryable<Product> Products => _ctx.Products;

        public void SaveProduct(Product product)
        {
            if(product.PID == 0)
            {
                _ctx.Products.Add(product);
            } else
            {
                Product dbEntry = _ctx.Products.FirstOrDefault(p => p.PID == product.PID);
                if(dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.ProductDescription = product.ProductDescription;
                    dbEntry.ProductPrice = product.ProductPrice;
                    dbEntry.ProductCategory = product.ProductCategory;
                }

            }

            _ctx.SaveChanges();
        }

        public Product RemoveProduct(int productID)
        {
            Product dbEntry = _ctx.Products.FirstOrDefault(p => p.PID == productID);
            if(dbEntry != null)
            {
                _ctx.Products.Remove(dbEntry);
                _ctx.SaveChanges();
            }

            return dbEntry;

        }
    }
}