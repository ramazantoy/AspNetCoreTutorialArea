using System.Collections.Generic;
using System.Threading.Tasks;
using Project_7.Data;

namespace Project_7.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();

        public Task<Product> GetProductById(int id);

        public Task<Product> CreateAsync(Product product);

    }
}