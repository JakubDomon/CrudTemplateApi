using BCrypt.Net;
using BusinessLayer.BusinessObjects.Communication;
using BusinessLayer.BusinessObjects.Communication.Objects.Security;
using BusinessLayer.BusinessObjects.Communication.Requests.Security;
using DataAccessLayer.DbContexts;
using DataAccessLayer.Models.User;
using jwTokens = Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.BusinessLogic.SpecificBusinessLogics.Security
{
    public class UserAuthenticationBusinessLogic : CrudBusinessLogicBase<BlAuthenticateUserRequest, BlAuthenticateUserResponse, BillAppContext>
    {
        string AuthIssuer { get => _configurationRoot["Jwt:Issuer"] ?? ""; }
        string AuthAudience { get => _configurationRoot["Jwt:Audience"] ?? ""; }
        Byte[] AuthKey { get => Encoding.ASCII.GetBytes(_configurationRoot["Jwt:Key"] ?? ""); }

        public UserAuthenticationBusinessLogic(BillAppContext context) : base(context) { }

        protected override BlAuthenticateUserResponse? ExecuteInternalLogic(BlAuthenticateUserRequest request)
        {
            User? dbUser = _context.Users.FirstOrDefault(x => x.Login == request.Login);

            if (dbUser == null)
            {
                return null;
            }

            if(BCrypt.Net.BCrypt.Verify(request.Password, dbUser.Password))
            {
                SecurityTokenDescriptor securityTokenDescriptor = new()
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", dbUser.Id.ToString()),
                        new Claim(jwTokens.JwtRegisteredClaimNames.Sub, dbUser.Name),
                        new Claim(jwTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10d),
                    Issuer = AuthIssuer,
                    Audience = AuthAudience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(AuthKey), SecurityAlgorithms.HmacSha256Signature),
                };

                JwtSecurityTokenHandler tokenHandler = new();
                SecurityToken jwtToken = tokenHandler.CreateToken(securityTokenDescriptor);

                return new BlAuthenticateUserResponse()
                {
                    Id = dbUser.Id,
                    Name = dbUser.Name,
                    Surname = dbUser.Surname,
                    Token = tokenHandler.WriteToken(jwtToken),
                };
            }
            else
            {
                return null;
            }
        }
    }
}
