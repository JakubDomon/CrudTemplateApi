using Azure.Core;
using BusinessLayer.BusinessObjects.Communication.Objects.User.Add;
using BusinessLayer.BusinessObjects.Errors.Errors;
using BusinessLayer.Validators;
using DataAccessLayer.DbContexts;
using DataAccessLayer.Models.User;

namespace BusinessLayer.BusinessLogic.SpecificBusinessLogics.UserManagement
{
    public class UserAddBusinessLogic : CrudBusinessLogicBase<BlAddUserRequest, BlAddUserResponse, BillAppContext>
    {
        public UserAddBusinessLogic(BillAppContext context) : base(context) { }

        protected override BlAddUserResponse? ExecuteInternalLogic(BlAddUserRequest request)
        {
            try
            {
                User dbUser = new()
                {
                    Login = request.Login,
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
                };
                _context.Add(dbUser);
                _context.SaveChanges();

                return new BlAddUserResponse()
                {
                    Id = dbUser.Id,
                    Login = dbUser.Login,
                    Name = dbUser.Name,
                    Surname = dbUser.Surname,
                    Email = dbUser.Email,
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception with message {ex.Message} occured during code execution");
            }
        }
    }
}
