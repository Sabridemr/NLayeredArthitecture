using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayeredArthitecture.Repositories;
using Repositories.Entities;

namespace Repositories.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<Categories> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        
    }
}