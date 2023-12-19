using Dal = DataAccessLayer.Models;
using DataAccessLayer.Repositiories;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.BusinessObjects.Security.Login;
using BusinessLayer.Validators.SpecificValidators.Security;
using AutoMapper;
using Am = BusinessLayer.Converters.AutoMapper;
using BusinessLayer.BusinessObjects.Errors.Errors;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper.Internal.Mappers;
using BusinessLayer.Helpers.MapperObjectFiller;
using BusinessLayer.Helpers.MapperObjectFiller.SpecificObjectFillers;
using BusinessLayer.BusinessObjects.Communication.API;
using BusinessLayer.BusinessObjects.Communication.Repository;

namespace BusinessLayer.BusinessLogic.Security
{
    internal class SecurityBusinessLogic : BusinessLogicBase, ISecurityBusinessLogic
    {
        private IRepository<Dal.Users.User> Repository { get; }
        private ISecurityValidator SecurityValidator { get; }
        private IMapper Mapper { get; }
        private IConfiguration Configuration { get; }
        private IMapperObjectFiller<User> UserObjectFiller { get; }

        public SecurityBusinessLogic(IRepository<Dal.Users.User> repository, ISecurityValidator validator, IConfiguration configuration, IMapperObjectFiller<User> userObjectFiller)
        {
            Repository = repository;
            SecurityValidator = validator;
            Mapper = Am.AutoMapper.Mapper;
            Configuration = configuration;
            UserObjectFiller = userObjectFiller;
        }

        public ErrorableResponse<User> RegisterUser(User user)
        {
            IEnumerable<Error> errors = SecurityValidator.ValidateUserRegister(user);
            if (errors.Any())
            {
                return CreateErrorResponse<User>(errors);
            }
            user = UserObjectFiller.Fill(user);

            try
            {
                if(user != null && user?.Password != null)
                {
                    user.Password = EncryptPassword(user.Password);

                    Repository.Add(Mapper.Map<Dal.Users.User>(user));
                    if (Repository.SaveChanges()) 
                    {
                        return CreateSuccessEmptyResponse<User>();
                    };

                    return CreateDatabaseErrorResponse<User>();
                }
                else
                {
                    return CreateErrorResponseException<User>();
                }
            }
            catch (Exception ex)
            {
                return CreateErrorResponseException<User>();
            }
        }

        public ErrorableResponse<User> UpdateUser(User user)
        {
            IEnumerable<Error> errors = SecurityValidator.ValidateUserUpdate(user);
            if (errors.Any())
            {
                return CreateErrorResponse<User>(errors);
            }

            try
            {
                var result = Mapper.Map<OperationResult<User>>(Repository.Update(Mapper.Map<Dal.Users.User>(user)));
                
                return CreateResponseFromOperationResult(result);
            }
            catch(Exception ex)
            {
                return CreateErrorResponseException<User>();
            }
        }

        public ErrorableResponse<User> DeleteUser(User user)
        {
            IEnumerable<Error> errors = SecurityValidator.ValidateUserDelete(user);
            if (errors.Any())
            {
                return CreateErrorResponse<User>(errors);
            }

            try
            {
                Repository.Delete(Mapper.Map<Dal.Users.User>(user));
                if (Repository.SaveChanges())
                {
                    return CreateSuccessEmptyResponse<User>();
                };

                return CreateDatabaseErrorResponse<User>();
            }
            catch
            {
                return CreateErrorResponseException<User>();
            }
        }

        public ErrorableResponse<LoginResponse> LoginUser(LoginRequest userLoginRequest)
        {
            IEnumerable<Error> errors = SecurityValidator.ValidateUserLogin(userLoginRequest);
            if(errors.Any())
            {
                return CreateErrorResponse<LoginResponse>(errors);
            }

            try
            {
                User user = Mapper.Map<User>(Repository.GetManyByCondition(x => x.Login == userLoginRequest.Login).ToList()[0]);

                if(VerifyUserPassword(user, userLoginRequest))
                {
                    IConfigurationSection jwtConfigSection = Configuration.GetSection("JWT") ?? throw new ArgumentNullException();

                    byte[] key = Encoding.ASCII.GetBytes(jwtConfigSection["Key"] ?? throw new ArgumentNullException());

                    SecurityTokenDescriptor tokenDescriptor = new()
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                            new Claim(ClaimTypes.GivenName, user.Name),
                            new Claim(ClaimTypes.Surname, user.Surname),
                            new Claim(JwtRegisteredClaimNames.Aud, jwtConfigSection["Audience"] ?? throw new ArgumentNullException()),
                            new Claim(JwtRegisteredClaimNames.Aud, jwtConfigSection["Issuer"] ?? throw new ArgumentNullException())
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    JwtSecurityTokenHandler tokenHandler = new();

                    return CreateSuccessResponse(new LoginResponse()
                    {
                        Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
                        User = user,
                    });
                }

                // Change this code to HTTP status enum
                return CreateErrorResponseException<LoginResponse>();
            }
            catch(Exception ex)
            {
                return CreateErrorResponseException<LoginResponse>();
            }
        }

        private string EncryptPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        private bool VerifyUserPassword(User? user, LoginRequest loginRequest)
        {
            if(user == null)
            {
                return false;
            }

            if(BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                return true;
            }

            return false;
        }
    }
}
