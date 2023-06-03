namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        public IEnumerable<T> FindAll();
        public T? FindById(int id);
        public T Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
