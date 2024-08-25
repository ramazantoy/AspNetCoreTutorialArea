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
            return await _productContext.Products.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _productContext.AddAsync(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {

            var unchangedEntity =await _productContext.Products.FindAsync(product.Id);
            _productContext.Entry(unchangedEntity).CurrentValues.SetValues(product);
            await _productContext.SaveChangesAsync();

        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _productContext.Products.FindAsync(id);
            _productContext.Products.Remove(removedEntity);
         await   _productContext.SaveChangesAsync();
        }
    }
}