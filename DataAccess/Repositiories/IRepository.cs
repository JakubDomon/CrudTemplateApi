using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using DataAccessLayer.Models.OperationResult;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositiories
{
    public interface IRepository<Entity>
        where Entity : EntityBase
    {
        OperationResult<IEnumerable<Entity>> GetAll();
        OperationResult<Entity> GetById(int id);
        OperationResult<IEnumerable<Entity>> GetManyByCondition(Expression<Func<Entity, bool>> expression);
        OperationResult<Entity> Update(Entity entity);
        OperationResult<Entity> Delete(Entity entity);
        OperationResult<Entity> Add(Entity entity);
    }
}
