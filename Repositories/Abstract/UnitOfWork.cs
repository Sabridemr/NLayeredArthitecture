
using Repositories.Context;

namespace NLayeredArthitecture.Repositories
{
    public class UnitOfWork(AppDbContext context): IUnitOfWork
    {
        public Task<int> SaveChangeAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}