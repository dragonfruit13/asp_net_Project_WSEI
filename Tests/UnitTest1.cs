using Moq;
using Xunit;
using asp_net_Project_WSEI.Models;
using asp_net_Project_WSEI.Controllers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_Project_WSEI_tests
{

    public class ProductControllerTests
    {
        [Theory]
        [InlineData(1, "Scooter")]
        [InlineData(2, "Basketball")]
        public void GetProductByID(int PID, string expectedProductName)
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(repo => repo.Products).Returns(new Product[]
                {
                    new Product { PID = 1, ProductName = "Scooter"},
                    new Product { PID = 2, ProductName = "Basketball"}
                }.AsQueryable<Product>());

            var controller = new ProductController(mock.Object);

            Product result = GetViewModel<Product>(controller.GetProductByID(PID));

            Assert.Equal(expected: expectedProductName, actual: result.ProductName);
            Assert.Equal(expected: PID, actual: result.PID);
        }
        [Fact]
        public void GetAllProducts()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(repo => repo.Products).Returns(new Product[] {
                new Product { PID = 1, ProductName = "P1" },
                new Product { PID = 2, ProductName = "P2" },
                new Product { PID = 3, ProductName = "P3" }
            }.AsQueryable<Product>);

            AdminController controller = new AdminController(mock.Object);

            Product[] result = GetViewModel<IEnumerable<Product>>(controller.Index())?.ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal("P1", result[0].ProductName);
            Assert.Equal(3, result[2].PID);
        }

        [Fact]
        public void GetProductByCategory()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(repo => repo.Products).Returns(new Product[] {
                new Product { PID = 1, ProductName = "P1", ProductCategory = "fruit" },
                new Product { PID = 2, ProductName = "P2", ProductCategory = "vegetable" },
                new Product { PID = 3, ProductName = "P3", ProductCategory = "fruit" }
            }.AsQueryable<Product>);

            ProductController controller = new ProductController(mock.Object);

            Product[] result = GetViewModel<IQueryable<Product>>(controller.List("fruit")).ToArray();

            Assert.Equal(2, result.Length);
            Assert.True(result[0].ProductCategory == "fruit");
            Assert.True(result[1].ProductCategory == "fruit");
        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
