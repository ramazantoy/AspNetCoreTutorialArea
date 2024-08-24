using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_7.Data;
using Project_7.Interfaces;

namespace Project_7.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return  await _productContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}