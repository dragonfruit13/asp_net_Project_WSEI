using System.Linq;

namespace asp_net_Project_WSEI.Models
{
	public interface IProductRepository
	{
		IQueryable<Product> Products { get; }
		void SaveProduct(Product product);
		Product RemoveProduct(int productID);
	}
}