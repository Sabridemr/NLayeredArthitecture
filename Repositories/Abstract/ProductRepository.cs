using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Entities;

namespace NLayeredArthitecture.Repositories
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task<List<Product>> GetTopPriceProductsAsync(int count)
        {
            return await Context.Products.OrderByDescending(x => x.Price).Take(count).ToListAsync();
        }
    }
} 