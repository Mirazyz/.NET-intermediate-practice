using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T?> FindByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

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

        public void Delete(T entity)
        {
            _context.Remove<T>(entity);
        }
    }
}
