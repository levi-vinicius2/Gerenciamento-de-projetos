using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ModelUser.Models;

namespace User.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ModelUser.Models.User user;
        private List<ModelUser.Models.User> usersList;
        private User.Repositories.UserRepositorie userRepositorie;

        public UserController(ModelUser.Models.User user, User.Repositories.UserRepositorie userR)
        {
            this.userRepositorie = userR;
            this.AddUser(user);
        }

        [HttpPost]
        public async Task<ActionResult<ModelUser.Models.User>> AddUser([FromBody]ModelUser.Models.User user)
        {
            ModelUser.Models.User user1 = await this.userRepositorie.Add(user);
            return Ok(user1);
        }

        [HttpGet]
        public async Task<ActionResult<List<ModelUser.Models.User>>> GetAllUsers()
        {
            List<ModelUser.Models.User> users = await this.userRepositorie.SearchAllUsers();
            return Ok(users);
        }

        [HttpGet("{userID}")]
        public async Task<ActionResult<List<ModelUser.Models.User>>> GetUserByID(int id)
        {
            ModelUser.Models.User users = await this.userRepositorie.SearchByID(id);
            return Ok(users);
        }

        [HttpPut("{userID}")]
        public async Task<ActionResult<ModelUser.Models.User>> UpdateUser(ModelUser.Models.User user)
        {
            ModelUser.Models.User user1 = await this.userRepositorie.Update(user);
            return Ok(user1);
        }

        [HttpDelete("{userID}")]
        public async Task<ActionResult<ModelUser.Models.User>> RemoveUser(ModelUser.Models.User user)
        {
            ModelUser.Models.User user1 = await this.userRepositorie.Delete(user);
            return Ok(user1);
        }

        // if tretur
        private bool IsUsersListEmpty()
        {
            if(this.usersList == null)
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}