namespace NLayeredArthitecture.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
        
    }
}