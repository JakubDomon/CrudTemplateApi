using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

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

        public void Add(Entity entity)
        {
            entity.AddDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            Table.Add(entity);
        }

        public void Update(Entity entity)
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
        }

        public IEnumerable<Entity> GetManyByCondition(Expression<Func<Entity, bool>> expression) => Table.Where(expression).ToList();
        public IEnumerable<Entity> GetAll() => Table.OrderBy(x => x.Id).ToList();
        public Entity? GetById(int id) => Table.SingleOrDefault(x => x.Id == id);
        public void Delete(Entity entity) => Table.Remove(Table.Find(entity.Id) ?? throw new ArgumentException($"Entity with ID: {entity.Id} not found in database"));
        public bool SaveChanges() => Context.SaveChanges() > 0;
    }
}
