using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositiories
{
    public interface IRepository<Entity>
        where Entity : EntityBase
    {
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity?> GetByIdAsync(int id);
        Task<IEnumerable<Entity>> GetManyByConditionAsync(Expression<Func<Entity, bool>> expression);
        void Update(Entity entity);
        void Delete(Entity entity);
        void Add(Entity entity);
        Task<bool> SaveChangesAsync();
    }
}
