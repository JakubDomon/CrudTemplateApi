using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Errors.Errors;

namespace BusinessLayer.Validators.SpecificValidators.Crud
{
    internal interface ICrudValidator<T>
        where T : BusinessModelBase
    {
        IEnumerable<Error> ValidateAdd(T item);
        IEnumerable<Error> ValidateDelete(T item);
        IEnumerable<Error> ValidateUpdate(T item);
        IEnumerable<Error> ValidateGetById(int id);
        IEnumerable<Error> ValidateQuery(T item);
    }
}
