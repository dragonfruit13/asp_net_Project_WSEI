using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using asp_net_Project_WSEI.Models;
using System.Linq;

namespace asp_net_Project_WSEI
{
    public class APIController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public APIController(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }
        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("product")]
        public ActionResult<Product> GetProduct()
        {
            var product = _repository.Products.ToList();

            return Ok(product);
        }
        /// <summary>
        /// Get product by product ID
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        [HttpGet("PID")]
        public ActionResult<Product> GetProductByID(int PID)
        {
            var product = _repository.Products.SingleOrDefault(p => p.PID == PID);
            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        /// <summary>
        /// Remove product by Product ID
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        [HttpDelete("product")]
        public ActionResult<Product> RemoveProduct(int PID)
        {
            _repository.RemoveProduct(PID);

            return NoContent();
        }
        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("product")]
        public ActionResult<Product> AddProduct(Product product)
        {
            _repository.AddProduct(product);

            return CreatedAtAction(actionName: nameof(GetProductByID), routeValues: new { id = product.PID }, value: product);
        }
        /// <summary>
        /// Edit product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("product")]
        public ActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            if (!_repository.Products.Any(p => p.PID == product.PID)) { return NotFound(); }

            _repository.AddProduct(product);

            return NoContent();
        }
    }

}