using Microsoft.AspNetCore.Mvc;
using ModelProject.Models;
using ModelTask.Models;
using ModelUser.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[projectController]")]

    public class ProjectController : Controller
    {
        private readonly User user;
        private readonly Project project;
        private List<Project> projectsList;

        public ProjectController(User user)
        {
            this.project = new Project();
            if (this.IsProjectsListEmpty())
            {
                this.projectsList = new List<Project> { project };
            }
            else
            {
                this.projectsList.Add(project);
            }
            this.user = new User(user.getName(), user.getEmail(), user.getPassword());
        }

        public ProjectController(User user, Project project)
        {
            this.project = new Project(user, project.getProjectName());
            if (this.IsProjectsListEmpty())
            {
                this.projectsList = this.AddProject(project);
                this.user = user;
            }
            else
            {
                this.user = user;
                this.projectsList = this.AddProject(project);
            }
            
        }

        [HttpPost]
        public List<Project> AddProject(Project project){
            List<Project> auxProject = this.projectsList;
            if (auxProject != null){
                auxProject.Add(project);
            } else {
                auxProject = new List<Project> { project };
            }
            return auxProject;
        }

        [HttpPut("{projectID}")]
        public Boolean UpdateProject(int projectID)
        {
            int count = 0;
            Boolean foundedProject = false;
            if (this.IsProjectsListEmpty())
            {
                foreach (Project projectsList1 in this.projectsList)
                {
                    if (projectID == this.projectsList[count].getProjectID())
                    {
                        this.projectsList[count] = projectsList1;
                        foundedProject = true;
                        return foundedProject;
                    }
                    count++;
                }
            }
            return foundedProject;
        }

        [HttpGet]
        public List<Project> ViewAllProjects()
        {
            return this.projectsList;
        }

        [HttpDelete("{projectID}")]
        public bool RemoveProject(int projectID)
        {
            if (this.IsProjectsListEmpty())
            {
                foreach(Project project in this.projectsList)
                {
                    if(project.getProjectID() == projectID)
                    {
                        try
                        {
                            this.projectsList.Remove(project);
                        } catch(Exception e)
                        {
                            throw new Exception("Erro: "+e);
                        }
                        return true;
                    }
                }
                
            }
            return false;
        }

        private bool IsProjectsListEmpty()
        {
            if (this.projectsList == null)
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