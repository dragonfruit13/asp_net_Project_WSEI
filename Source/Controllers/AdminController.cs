using System.Linq;
using asp_net_Project_WSEI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace asp_net_Project_WSEI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;

        public AdminController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index() => View(_repository.Products);

        public ViewResult Edit(int productId) =>
            View(_repository.Products.FirstOrDefault(p => p.PID == productId));

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                TempData["message"] = $"Saved {product.ProductName}.";
                return RedirectToAction("Index");
            }
            else
            {

                return View("Edit", product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult RemoveProduct(int productId)
        {
            Product removedProduct = _repository.RemoveProduct(productId);
            if (removedProduct != null)
                TempData["message"] = $"Removed {removedProduct.ProductName}.";
            return RedirectToAction("Index");
        }
    }
}