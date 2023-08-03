using AutoMapper;
using BillWebApi.Database.DatabaseConfig;
using BillWebApi.Database.Models.DatabaseModels.Bills;
using BillWebApi.Database.Models.DatabaseModels.Groups;
using BillWebApi.Database.Models.DatabaseModels.Users;
using BillWebApi.Database.Models.Models;
using BillWebApi.Profiles.ResourceManager;
using BillWebApi.Profiles.ResourceManager.ConcreteResourceManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BillWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private MSSQLContext _dbContext;
        private IMapper _mapper;
        public GroupController(MSSQLContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<GroupModel>> GetGroups()
        {
            try
            {
                IManager<Group, GroupModel> manager = (IManager<Group, GroupModel>) new ResourceManager<Group, GroupModel>(_mapper);
                return Ok(manager.MapResource(_dbContext.Groups.ToList()));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{groupID}")]
        public ActionResult<GroupModel> GetGroup(int groupID)
        {
            if(!(groupID >= 1))
            {
                return BadRequest();
            }

            try
            {
                Group dbGroup = _dbContext.Groups.Find(groupID);

                if(!(dbGroup == null))
                {
                    GroupModel group = _mapper.Map<GroupModel>(dbGroup);

                    return Ok(group);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /*
        [HttpGet]
        [Route("{groupID}/bills"]
        public ActionResult<ICollection<Bill>> GetGroupBills(int groupID)
        {
            if()
        }

        
        [HttpGet]
        [Route("{groupID}/users")]
        public ActionResult<ICollection<UserModel>> GetUsersInGroup(int groupID)
        {
            if(!(groupID >= 1))
            {
                return BadRequest();
            }

            Group group = _dbContext.Groups.Find(groupID);

            if (group != null)
            {
                List<User> users = group.Users.ToList();
                List<UserModel> userModels = new();

                foreach(User user in users)
                {
                    userModels.Add(_mapper.Map<UserModel>(user));
                }

                return Ok(userModels);
            }
            else
            {
                return BadRequest();
            }
        }
        */

        [HttpPost]
        public ActionResult<GroupModel> CreateGroup(GroupAddModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                List<User> users = new();
                foreach(UserModel userModel in model.Users)
                {
                    users.Add(_mapper.Map<User>(userModel));
                }

                Group group = new()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Users = users,
                };

                _dbContext.Add<Group>(group);
                _dbContext.SaveChanges();

                return Ok(group);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
