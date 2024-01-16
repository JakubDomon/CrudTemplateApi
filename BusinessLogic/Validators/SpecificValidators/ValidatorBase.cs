using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.Errors.Errors;
using BusinessLayer.Helpers.ExtensionMethods;
using System.Reflection;

namespace BusinessLayer.Validators.SpecificValidators
{
    internal abstract class ValidatorBase<T>
        where T : class
    {
        protected ValidatorBase() { }

        protected Error CreateError(string errorKey) => new(errorKey, false);

        public IEnumerable<Error> ValidateObjectHasAnyPropertyValues(T item)
        {
            if(item.GetPropertyInfos(BindingFlags.Public | BindingFlags.Instance).All(x => x.GetValue(item) == null))
            {
                yield return CreateError(CommonErrorCodes.ObjectEveryPropertyNull);
            }
        }
    }
}
