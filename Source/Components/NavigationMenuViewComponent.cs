using System.Linq;
using asp_net_Project_WSEI.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_Project_WSEI.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository _repository;
        public NavigationMenuViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {

            return View(_repository.Products.Select(x => x.ProductCategory).Distinct().OrderBy(x => x));
        }
    }
}