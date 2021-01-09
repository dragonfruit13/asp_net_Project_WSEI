using System.Linq;
using asp_net_Project_WSEI.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_Project_WSEI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public ViewResult List(string category) => View(_productRepository.Products.Where(p => p.ProductCategory == category));

        public IActionResult Index()
        {
            return View("List");
        }

    }
}