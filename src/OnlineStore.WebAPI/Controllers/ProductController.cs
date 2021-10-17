using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.WebAPI.Controllers
{
    public class ProductController : Controller
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("v1/products")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var result = await _productService.GetAllProducts();

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        [Route("v1/product/{product_id}")]
        public async Task<ActionResult<Product>> GetProductByID(int product_id)
        {
            var result = await _productService.GetProductByCode(product_id);

            return result == null ? NotFound() : Ok(result);

        }

        [HttpPost]
        [Route("v1/product")]
        public async Task<ActionResult<Product>> AddProduct([FromForm] Product product)
        {
            var result = await _productService.AddProduct(product.Name, product.Price);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        [Route("v1/product/{product_id}")]
        public async Task<ActionResult<Product>> UpdateProduct([FromForm] string name, int product_id)
        {
            var result = await _productService.UpdateProduct(product_id, name);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete]
        [Route("v1/product/{product_id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int product_id)
        {
            var result = await _productService.DeleteProduct(product_id);

            return result == null ? NotFound() : Ok(result);
        }
    }
}
