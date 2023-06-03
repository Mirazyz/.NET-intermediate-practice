using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly TicketingDbContext _context;

        public RepositoryBase(TicketingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<T> FindAll()
        {
            var entities = _context.Set<T>().ToList();

            return entities;
        }

        public T? FindById(int id)
        {
            var entity = _context.Set<T>().Find(id);

            return entity;
        }

        public T Create(T entity)
        {
            _context.Add<T>(entity);

            return entity;
        }

        public void Update(T entity)
        {
            _context.Update<T>(entity);
        }

        public void Delete(int id)
        {
            var entity = FindById(id);

            if (entity != null)
            {
                _context.Remove<T>(entity);
            }
        }
    }
}
