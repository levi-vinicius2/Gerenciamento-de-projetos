using Microsoft.AspNetCore.Mvc;
using ModelUser.Models;
using ModelProject.Models;

namespace UserController.Controllers
{
    [ApiController]
    [Route("{userController}")]
    class UserController : Controller
    {
        private User user;
        List<User> usersList;
        private List<int>? associatedProjectsID;

        public UserController(User user)
        {
            this.user = new User(user.getName(), user.getEmail(), user.getPassword());
            if (this.usersList == null)
            {
                this.usersList = new List<User> { user };
            }
            else
            {
                this.usersList.Add(user);
            }
        }
        public UserController()
        {
            this.user = new User();
            if (this.usersList == null)
            {
                this.usersList = new List<User> { user };
            }
            else
            {
                this.usersList.Add(user);
            }
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            if (this.usersList != null)
            {
                return this.usersList;
            }
            else
            {
                throw new Exception("Nenhum usu�rio cadastrado");
            }

        }

        [HttpPut("{userID}")]
        public void updateUser(int userID)
        {
            int count = 0;
            foreach (User user1 in this.usersList)
            {
                if (user1.getUserID() == userID) { 
                    user1.setName(user1.getName());
                    user1.setPassword(user1.getPassword());
                    usersList[count] = user1;
                }
                count++;
            }
        }

        [HttpDelete("{userID}")]
        public Boolean removeUser(int userID)
        {
            if (this.usersList != null)
            {
                foreach(User user1 in usersList)
                {
                    if (user1.getUserID() == userID)
                    {
                        this.usersList.Remove(user);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}