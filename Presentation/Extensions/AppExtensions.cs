using NLayeredArthitecture.Repositories;
using NLayeredArthitecture.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

namespace NLayeredArthitecture.Presentation
{
    public static class AppExtensions
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.Load("NLayeredArthitecture.Services"));
            services.AddAutoMapper(Assembly.Load("NLayeredArthitecture.Services"));
            services.AddExceptionHandler<CriticalExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            return services;
        }
    }
}