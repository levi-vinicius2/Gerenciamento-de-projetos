using Microsoft.AspNetCore.Mvc;
using ModelUser.Models;

namespace UserController.Controllers
{
    [ApiController]
    [Route("{userController}")]
    class UserController : Controller
    {
        private readonly User user;
        private List<User> usersList;

        public UserController(User user)
        {
            this.user = new User(user.getName(), user.getEmail(), user.getPassword());
            if (this.IsUsersListEmpty())
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
            if (this.IsUsersListEmpty())
            {
                this.usersList = new List<User> { user };
            }
            else
            {
                this.usersList.Add(this.user);
            }
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            if (this.IsUsersListEmpty())
            {
                throw new Exception("Nenhum usu�rio cadastrado");
            }
            else
            {
                return this.usersList;
            }

        }

        [HttpPut("{userID}")]
        public void UpdateUser(int userID)
        {
            if (!this.IsUsersListEmpty())
            {
                int count = 0;
                foreach (User user1 in this.usersList)
                {
                    if (this.user.getUserID() == userID)
                    {
                        this.user.setName(user1.getName());
                        this.user.setPassword(user1.getPassword());
                        this.usersList[count] = user1;
                    }
                    count++;
                }
            }

        }

        [HttpDelete("{userID}")]
        public Boolean RemoveUser(int userID)
        {
            if (!this.IsUsersListEmpty())
            {
                foreach (User user1 in usersList)
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

        // if tretur
        private bool IsUsersListEmpty()
        {
            if (this.usersList == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}