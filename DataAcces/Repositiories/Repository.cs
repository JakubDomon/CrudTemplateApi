using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositiories
{
    public class Repository<Entity> : IRepository<Entity>
        where Entity : EntityBase
    {
        private readonly DbContextBase _context;
        private readonly DbSet<Entity> _table;

        public Repository(DbContextBase dbContext)
        {
            _context = dbContext;
            _table = dbContext.Set<Entity>();
        }

        public void Add(Entity entity) => _table.Add(entity);

        public async Task<IEnumerable<Entity>> GetManyByConditionAsync(Expression<Func<Entity, bool>> expression) => await _table.Where(expression).ToListAsync();

        public async Task<IEnumerable<Entity>> GetAllAsync() => await _table.OrderBy(x => x.Id).ToListAsync();

        public async Task<Entity?> GetByIdAsync(int id) => await _table.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync().ConfigureAwait(false) > 0;

        public void Update(Entity entity) => _table.Update(entity);

        public void Delete(Entity entity) => _table.Remove(entity);
    }
}
