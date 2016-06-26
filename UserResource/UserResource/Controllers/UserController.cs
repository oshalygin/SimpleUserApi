using System.Collections.Generic;
using System.Web.Http;
using UserResource.Attributes;
using UserResource.BLL;
using UserResource.DAL;
using UserResource.DAL.Entities;
using UserResource.Models;

namespace UserResource.Controllers
{
    [ApiControllerConfiguration]
    [RoutePrefix("api/v1/user")]
    [Authorize] // Non-public api.
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserBLL _userBll;

        public UserController(IMapper mapper, IUserBLL userBll)
        {
            _mapper = mapper;
            _userBll = userBll;
        }

        [Route("")]
        public IHttpActionResult GetUsers(int page, int pageSize)
        {
            var paging = new Paging
            {
                Page = page,
                PageSize = pageSize
            };
            var users = _userBll.GetUsers(paging);
            var usersModel = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
            return Ok(usersModel);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult UpdateUser([FromBody] UserViewModel user)
        {
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedUser = _mapper.Map<UserViewModel, User>(user);
            var persistedUsed = _userBll.UpdateUser(updatedUser);
            var userViewModel = _mapper.Map<User, UserViewModel>(persistedUsed);
            return Ok(userViewModel);
        }

        [Route("")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int userId)
        {
            var deletedUser = _userBll.DeleteUser(userId);
            var userViewModel = _mapper.Map<User, UserViewModel>(deletedUser);
            return Ok(userViewModel);
        }


        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody] UserViewModel user)
        {
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdUser = _mapper.Map<UserViewModel, User>(user);
            var persistedUsed = _userBll.CreateUser(createdUser);
            var userViewModel = _mapper.Map<User, UserViewModel>(persistedUsed);
            return Ok(userViewModel);
        }
    }
}