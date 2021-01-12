using System.Linq;

namespace asp_net_Project_WSEI.Models
{
	public interface IProductRepository
	{
		IQueryable<Product> Products { get; }
		void AddProduct(Product product);
		Product RemoveProduct(int productID);
	}
}