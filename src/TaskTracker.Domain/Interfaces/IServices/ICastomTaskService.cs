namespace TaskTracker.Domain.Interfaces.IServices
{
    public interface ICastomTaskService<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task<bool> UpdateAsync(int id, T task);
        Task<bool> CreateAsync(T task);
        Task<bool> DeleteAsync(int id);
    }
}