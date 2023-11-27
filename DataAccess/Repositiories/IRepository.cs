using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositiories
{
    public interface IRepository<Entity>
        where Entity : EntityBase
    {
        IEnumerable<Entity> GetAll();
        Entity? GetById(int id);
        IEnumerable<Entity> GetManyByCondition(Expression<Func<Entity, bool>> expression);
        void Update(Entity entity);
        void Delete(Entity entity);
        void Add(Entity entity);
        bool SaveChanges();
    }
}
