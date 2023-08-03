using BCrypt.Net;
using BillWebApi.Database.DatabaseConfig;
using BillWebApi.Database.Models.DatabaseModels.Users;
using BillWebApi.Database.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using jwtokens = Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private MSSQLContext _dbContext;
        private IConfiguration _configuration;
        private IMapper _mapper;
        public AuthenticationController(MSSQLContext dbContext, IConfiguration _configuration, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._configuration = _configuration;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public ActionResult<UserModel> Register(UserRegisterModel user)
        {
            // Check user model
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new user
            User newUser = new()
            {
                Name = user.Name,
                Surname = user.Surname,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };

            // Add user to database
            try
            {
                _dbContext.Add<User>(newUser);
                _dbContext.SaveChanges();

                UserModel userModel = _mapper.Map<UserModel>(newUser);

                return Ok(userModel);
            }catch(ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult<AuthenticatedUserModel> Login(UserLoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Split name into two pieces
            string[] nameSurname = user.Login.Split(" ");

            string name = nameSurname[0];
            string surname = nameSurname[1];

            User dbUser = _dbContext.Users.Where(x => x.Name == name && x.Surname == surname).First();

            if(!BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password))
            {
                return Unauthorized(ModelState);
            }

            if (dbUser == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                string issuer = _configuration["Jwt:Issuer"];
                string audience = _configuration["Jwt:Audience"];
                Byte[] key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", dbUser.Id.ToString()),
                        new Claim(jwtokens.JwtRegisteredClaimNames.Sub, dbUser.Name),
                        new Claim(jwtokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                SecurityToken token = handler.CreateToken(tokenDescriptor);
                string jwtToken = handler.WriteToken(token);

                var authenticatedUser = new AuthenticatedUserModel
                {
                    Id = dbUser.Id,
                    Login = dbUser.Name + " " + dbUser.Surname,
                    Token = jwtToken
                };

                return Ok(authenticatedUser);
            }
        }
    }
}
