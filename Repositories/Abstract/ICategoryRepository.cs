namespace NLayeredArthitecture.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Categories>
    {
        Task<Categories?> GetCategoryWithProductAsync(int id);

        IQueryable<Categories> GetCategoryWithProduct();

    }
}