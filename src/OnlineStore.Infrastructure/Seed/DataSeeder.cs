using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Seed
{
    public class DataSeeder
    {
        private readonly StoreContext _context;
        public DataSeeder(StoreContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddUpdateProduct(new Product { ID = 1, Name = "Lavender heart", Price = "9.25" });
            AddUpdateProduct(new Product { ID = 2, Name = "Personalised cufflinks", Price = "45.00" });
            AddUpdateProduct(new Product { ID = 3, Name = "Kids T-shirt", Price = "19.95" });
        }

        private void AddUpdateProduct(Product product)
        {
            if (_context.Products.Where(x => x.ID == product.ID).FirstOrDefault() == null)
            {
                _context.Products.Add(new Product { Name = product.Name, Price = product.Price });
                _context.SaveChanges();
            }
        }

    }
}
