using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.Errors.Errors;
using Dal = DataAccessLayer.Models;
using DataAccessLayer.Repositiories;

namespace BusinessLayer.Validators.SpecificValidators.Crud.UserGroups
{
    internal class UserGroupValidator : ValidatorCrudBase<Bo.UserGroups.UserGroup, Dal.UserGroups.UserGroup>, ICrudValidator<Bo.UserGroups.UserGroup>
    {
        public UserGroupValidator(IRepository<Dal.UserGroups.UserGroup> repository) : base(repository) { }

        public override IEnumerable<Error> ValidateAdd(Bo.UserGroups.UserGroup Item)
        {
            if(Item.Users == null || !Item.Users.Any())
            {
                yield return CreateError(UserGroupErrorCodes.UsersRequired);
            }
            else
            {
                foreach (var (user, index) in Item.Users.Select((value, i) => (value, i)))
                {
                    foreach(Error error in ValidateUserObject(user, index))
                    {
                        yield return error;
                    }
                }
            }
        }

        private IEnumerable<Error> ValidateUserObject(User user, int index)
        {
            if(user.Id == null || user.Id == 0)
            {
                yield return CreateError(string.Format(UserGroupErrorCodes.GroupUserIdRequired, index));
            }
        }
    }
}
