using Azure.Core;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.Validators.SpecificValidators.Crud.UserGroups;
using DataAccessLayer.Models;
using Dal = DataAccessLayer.Models;
using DataAccessLayer.Repositiories;
using BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.Validators.SpecificValidators.Crud
{
    internal class CrudValidatorFactory
    {
        public static ICrudValidator<Model> CreateValidator<Model, Entity>(IRepository<Entity> repository)
            where Model : BusinessModelBase
            where Entity : EntityBase
        {
            return typeof(Model) switch
            {
                Type type when type == typeof(Bo.UserGroups.UserGroup) => (ICrudValidator<Model>) new UserGroupValidator((IRepository<Dal.UserGroups.UserGroup>) repository),
                _ => throw new ArgumentException()
            };
        }
    }
}
