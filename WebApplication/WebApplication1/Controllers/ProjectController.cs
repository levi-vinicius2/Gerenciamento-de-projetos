using Microsoft.AspNetCore.Mvc;
using ModelProject.Models;
using ModelTask.Models;
using ModelUser.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[projectController]")]

    class ProjectController : Controller
    {
        private User user;
        Project project;
        List<Project> projectsList;

        public ProjectController(User user)
        {
            this.project = new Project();
            if (this.projectsList == null)
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
            if (this.projectsList != null)
            {
                this.projectsList = this.addProject(user, project);
                this.user = user;
            }
            else
            {
                this.user = user;
                this.projectsList = this.addProject(this.user, project);
            }
            
        }

        [HttpPost]
        private List<Project> addProject(User user, Project project){
            List<Project> auxProject = this.projectsList;
            if (auxProject != null){
                auxProject.Add(project);
            } else {
                auxProject = new List<Project> { project };
            }
            return auxProject;
        }

        [HttpPut("{projectID}")]
        private Boolean updateProject(int projectID)
        {
            int count = 0;
            Boolean foundedProject = false;
            if (this.projectsList != null)
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
        public List<Project> viewAllProjects()
        {
            return this.projectsList;
        }

        [HttpDelete("{projectID}")]
        public Boolean removeProject(int projectID)
        {
            if (this.projectsList != null && this.projectsList.Contains(project))
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
        }
    }