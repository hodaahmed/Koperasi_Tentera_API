namespace Koperasi_Tentera_API.Infrastructures.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> FindAsync(Func<T, bool> predicate);
        Task AddAsync(T entity);
        Task SaveChangesAsync();
    }
}
