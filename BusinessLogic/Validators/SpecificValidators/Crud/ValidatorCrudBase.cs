using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.Errors.Errors;
using DataAccessLayer.Models;
using DataAccessLayer.Repositiories;

namespace BusinessLayer.Validators.SpecificValidators.Crud
{
    internal abstract class ValidatorCrudBase<T, K> : ValidatorBase<T>, ICrudValidator<T>
        where T : BusinessModelBase
        where K : EntityBase
    {
        protected IRepository<K> Repository { get; }
        protected ValidatorCrudBase(IRepository<K> repository)
        {
            Repository = repository;
        }

        public abstract IEnumerable<Error> ValidateAdd(T Item);

        public virtual IEnumerable<Error> ValidateDelete(T Item)
        {
            if(Item.Id == null || Item.Id == 0)
            {
                yield return CreateError(CommonErrorCodes.ObjectIdRequired);
            }
        }

        public virtual IEnumerable<Error> ValidateGetById(int id)
        {
            if (id == 0)
            {
                yield return CreateError(CommonErrorCodes.ObjectIdRequired);
            }
        }

        public virtual IEnumerable<Error> ValidateUpdate(T Item)
        {
            if (Item.Id == null || Item.Id == 0)
            {
                yield return CreateError(CommonErrorCodes.ObjectIdRequired);
            }
            foreach(Error error in ValidateObjectHasAnyPropertyValues(Item))
            {
                yield return error;
            }
        }

        public virtual IEnumerable<Error> ValidateQuery(T item)
        {
            foreach(Error error in ValidateObjectHasAnyPropertyValues(item))
            {
                yield return error;
            }
        }
    }
}
