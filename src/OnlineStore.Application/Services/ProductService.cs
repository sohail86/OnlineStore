using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Services
{
    public class ProductService : IProductService
    {
        public IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(string name, string price)
        {
            var product = new Product() { Name = name, Price = price };

            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> DeleteProduct(int product_id)
        {
            var product = await _productRepository.GetByIdAsync(product_id);

            return product == null ? null : await _productRepository.DeleteAsync(product);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByCode(int product_id)
        {
            return await _productRepository.GetByIdAsync(product_id);
        }

        public async Task<Product> UpdateProduct(int product_id, string product_name)
        {
            var product = await _productRepository.GetByIdAsync(product_id);

            if (product == null)
                return null;
            else
                product.Name = product_name;

            return await _productRepository.UpdateAsync(product);
        }
    }
}
