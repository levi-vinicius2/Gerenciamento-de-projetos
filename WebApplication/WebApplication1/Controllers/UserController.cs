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
        private List<Project>? associatedProjects;

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
                throw new Exception("Nenhum usuário cadastrado");
            }

        }

        [HttpPut("{userID}")]
        public void updateUser(int userID)
        {
            int count = 0;
            foreach (User user1 int this.usersList)
            {
                if (user1.getUserID() == userID) { 
                    user1.setUserID(userID);
                    user1.setUserName(user1.getUserName());
                    user1.setPassword(user1.getPassword());
                    usersList[count] = user1;
                }
                count++;
            }
        }

        [HttpRemove("{userID}")]
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
            else
            {
                return false;
            }
        }

        [HttpRemove("{projectID}")]
        public Boolean removeAssociatedProject(int projectID)
        {
            Boolean foundedProject = false;
            if (this.associatedProjects != null)
            {
                foreach (Project project1 in this.associatedProjects)
                {
                    if (project1.getProjectID() == projectID)
                    {
                        try
                        {
                            this.associatedProjects.Remove(project);
                            foundedProject = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Erro: {e}");
                        }
                        return foundedProject;
                    }
                }
            }
            return foundedProject;
        }

        [HttpGet]
        public List<Project> getAllAssociatedProjects()
        {
            if (this.associatedProjects != null)
            {
                return this.associatedProjects;
            }
            else
            {
                throw new ArgumentNullException("Nao existem projetos associados");
            }
        }

        [HttpPost]
        public void setAssociatedProject(Project project)
        {
            if (this.associatedProjects != null)
            {
                try
                {
                    this.associatedProjects.Add(project);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro" + e);
                }
            }
            else
            {
                User auxUser = new User(this.user.getName(), this.user.getEmail(), this.user.getPassword());
                this.associatedProjects = new List<Project> { project };
            }
        }

        [HttpPut("{projectID}")]
        public Boolean updateAssociatedProject(int projectID)
        {
            int count = 0;
            Boolean foundedProject = false;
            if (this.associatedProjects != null)
            {
                foreach (Project project1 in associatedProjects)
                {
                    if (project1.getProjectID() == projectID)
                    {
                        foundedProject = true;
                        this.associatedProjects[count] = project1;
                        return foundedProject;
                    }
                    count++;
                }
            }
            return foundedProject;
        }
    }
}