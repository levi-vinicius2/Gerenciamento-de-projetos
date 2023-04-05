using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ModelUser;

namespace UserC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private User.Repositories.UserRepositorie userRepositorie;

        public UserController(User.Repositories.UserRepositorie userR)
        {
            this.userRepositorie = userR;
        }

        [HttpPost]
        public async Task<ActionResult<ModelUser.User>> AddUser([FromBody]ModelUser.User user)
        {
            ModelUser.User user1 = await this.userRepositorie.Add(user);
            return Ok(user1);
        }

        [HttpGet]
        public async Task<ActionResult<List<ModelUser.User>>> GetAllUsers()
        {
            List<ModelUser.User> users = await this.userRepositorie.SearchAllUsers();
            return Ok(users);
        }

        [HttpGet("{userID}")]
        public async Task<ActionResult<List<ModelUser.User>>> GetUserByID(int id)
        {
            ModelUser.User users = await this.userRepositorie.SearchByID(id);
            return Ok(users);
        }

        [HttpPut("{userID}")]
        public async Task<ActionResult<ModelUser.User>> UpdateUser(ModelUser.User user)
        {
            ModelUser.User user1 = await this.userRepositorie.Update(user);
            return Ok(user1);
        }

        [HttpDelete("{userID}")]
        public async Task<ActionResult<ModelUser.User>> RemoveUser(ModelUser.User user)
        {
            ModelUser.User user1 = await this.userRepositorie.Delete(user);
            return Ok(user1);
        }

    }
}