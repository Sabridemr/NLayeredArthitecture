using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;

namespace NLayeredArthitecture.Repositories
{
    public class CategoryRepository(AppDbContext context) : GenericRepository<Categories>(context), ICategoryRepository
    {
        public Task<Categories?> GetCategoryWithProductAsync(int id)
        {
            return context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.CategoryId == id);

        }

        public IQueryable<Categories> GetCategoryWithProduct()
        {
            return context.Categories.Include(x => x.Products).AsQueryable();
        }
    }

}