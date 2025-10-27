using NLayeredArthitecture.Repositories;
using NLayeredArthitecture.Services;
using Repositories.Entities;

namespace NLayeredArthitecture.Presentation
{
    public static class AppExtensions
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
        
         public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService , ProductService >();
            return services;
        }
    }
}