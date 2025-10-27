using NLayeredArthitecture.Repositories;
using Repositories.Entities;

namespace NLayeredArthitecture.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        
    }
} 