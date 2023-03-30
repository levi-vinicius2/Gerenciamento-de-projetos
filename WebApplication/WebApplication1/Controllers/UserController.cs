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
            this.user = new User(user.GetName(), user.GetEmail(), user.GetPassword());
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
                    if (this.user.GetUserID() == userID)
                    {
                        this.user.SetName(user1.GetName());
                        this.user.SetPassword(user1.GetPassword());
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
                    if (user1.GetUserID() == userID)
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