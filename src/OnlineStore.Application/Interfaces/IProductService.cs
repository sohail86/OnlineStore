using OnlineStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductByCode(int product_id);
        public Task<Product> AddProduct(string name, string price);
        public Task<Product> UpdateProduct(int product_id, string product_name);
        public Task<Product> DeleteProduct(int product_id);

    }
}
