using Repositories.Entities;

namespace NLayeredArthitecture.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count);

    } 
}