namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        public Task<IEnumerable<T>> FindAllAsync();
        public Task<T?> FindByIdAsync(int id);
        public T Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
