using Microsoft.AspNetCore.Mvc;
using ModelUser.Models;
using ModelProject.Models;

namespace UserController.Controllers
{
    [ApiController]
    [Route("[userController]")]
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

        public void updateUser(User user)
        {
            this.user.setEmail(user.getEmail());
            this.user.setName(user.getName());
            this.user.setPassword(user.getPassword());
        }
        public List<User> getAllUsers()
        {
            if (this.usersList != null)
            {
                return this.usersList;
            }
            else
            {
                throw new Exception("Erro: Não existem usuários");
            }
        }

        public Boolean removeUser(User user)
        {
            if (this.usersList != null && this.usersList.Contains(user))
            {
                this.usersList.Remove(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean removeAssociatedProject(Project project)
        {
            Boolean foundedProject = false;
            if (this.associatedProjects != null)
            {
                foreach (Project project1 in this.associatedProjects)
                {
                    if (project.getProjectID() == project.getProjectID())
                    {
                        foundedProject = true;
                        try
                        {
                            this.associatedProjects.Remove(project);
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


        public Boolean updateAssociatedProject(Project project)
        {
            int count = 0;
            Boolean foundedProject = false;
            if (this.associatedProjects != null)
            {
                foreach (Project project1 in associatedProjects)
                {
                    if (project.getProjectID() == this.associatedProjects[count].getProjectID())
                    {
                        foundedProject = true;
                        this.associatedProjects[count] = project;
                        count++;
                        return foundedProject;
                    }
                }
            }
            return foundedProject;
        }
    }
}