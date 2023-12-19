using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using OpRes = DataAccessLayer.Models.OperationResult;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using DataAccessLayer.Models.OperationResult;

namespace DataAccessLayer.Repositiories
{
    public class Repository<Entity, Database> : IRepository<Entity>
        where Entity : EntityBase
        where Database : DbContextBase
    {
        private readonly Database Context;
        private readonly DbSet<Entity> Table;

        public Repository(Database dbContext)
        {
            Context = dbContext;
            Table = dbContext.Set<Entity>();
        }

        public OpRes.OperationResult<Entity> Add(Entity entity)
        {
            entity.AddDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            Table.Add(entity);

            return new OperationResult<Entity>()
            {
                Object = entity,
                Status = SaveChanges()
                    ? OpRes.Enums.OperationStatus.Success
                    : OpRes.Enums.OperationStatus.Fail
            };
        }

        public OpRes.OperationResult<Entity> Update(Entity entity)
        {
            Entity existingEntity = Table.FirstOrDefault(x => x.Id == entity.Id) ?? throw new ArgumentException($"Entity with {entity.Id} not exists");
            existingEntity.UpdateDate = DateTime.Now;

            PropertyInfo[] newEntityProperties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] oldEntityProperties = existingEntity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach(PropertyInfo newProp in newEntityProperties)
            {
                if(newProp.GetValue(entity) != null && !newProp.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    var oldProp = oldEntityProperties.First(x => x.Name == newProp.Name && x.PropertyType == newProp.PropertyType);
                    oldProp.SetValue(existingEntity, newProp.GetValue(entity));
                }
            }
            Table.Update(existingEntity);

            return new OperationResult<Entity>()
            {
                Object = existingEntity,
                Status = SaveChanges()
                    ? OpRes.Enums.OperationStatus.Success
                    : OpRes.Enums.OperationStatus.Fail
            };
        }

        public OpRes.OperationResult<IEnumerable<Entity>> GetManyByCondition(Expression<Func<Entity, bool>> expression)
        {
            var items =Table.Where(expression).ToList();

            return new OperationResult<IEnumerable<Entity>>()
            {
                Object = items,
                Status = items.Count > 0
                    ? OpRes.Enums.OperationStatus.Success
                    : OpRes.Enums.OperationStatus.NotFound
            };

        }

        public OpRes.OperationResult<IEnumerable<Entity>> GetAll()
        {
            var items = Table.OrderBy(x => x.Id).ToList();

            return new OperationResult<IEnumerable<Entity>>()
            {
                Object = items,
                Status = items.Count > 0
                    ? OpRes.Enums.OperationStatus.Success
                    : OpRes.Enums.OperationStatus.NotFound
            };
        }

        public OpRes.OperationResult<Entity> GetById(int id)
        {
            var item = Table.SingleOrDefault(x => x.Id == id);

            return new OperationResult<Entity>()
            {
                Object = item,
                Status = item != null
                    ? OpRes.Enums.OperationStatus.Success
                    : OpRes.Enums.OperationStatus.NotFound
            };
        }

        public OpRes.OperationResult<Entity> Delete(Entity entity)
        {
            Table.Remove(Table.Find(entity.Id) ?? throw new ArgumentException($"Entity with ID: {entity.Id} not found in database"));

            return new OperationResult<Entity>()
            {
                Object = null,
                Status = Table.Find(entity.Id) == null
                    ? OpRes.Enums.OperationStatus.Success
                    : OpRes.Enums.OperationStatus.Fail
            };
        }

        private bool SaveChanges() => Context.SaveChanges() > 0;

        private OpRes.OperationResult<Entity> CreateOperationStatus(OpRes.Enums.OperationStatus status, Entity? entity)
        {
            return new OpRes.OperationResult<Entity>()
            {
                Object = entity,
                Status = status
            };
        }
    }
}
