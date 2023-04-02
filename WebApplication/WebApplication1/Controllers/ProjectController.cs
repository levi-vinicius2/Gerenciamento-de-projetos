using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private ModelProject.Models.Project project;
        private List<ModelProject.Models.Project> projectsList;
        private Project.Repositories.ProjectRepositorie projectRepositorie;

        public ProjectController(Project.Repositories.ProjectRepositorie projectRepositorie, ModelProject.Models.Project project)
        {
            this.project = project;
            this.projectRepositorie = projectRepositorie;
            this.AddProject(this.project);
        }

        [HttpPost]
        public async Task<ActionResult<ModelProject.Models.Project>> AddProject(
            [FromBody] ModelProject.Models.Project project)
        {
            ModelProject.Models.Project auxProject = await this.projectRepositorie.Add(project);
            return Ok(auxProject);
        }

        [HttpPut("{projectID}")]
        public async Task<ActionResult<ModelProject.Models.Project>> UpdateProject(ModelProject.Models.Project project)
        {
            ModelProject.Models.Project project1 = await this.projectRepositorie.Update(project, project.projectID);
            return Ok(project1);
        }

        [HttpGet]
        public async Task<ActionResult<List<ModelProject.Models.Project>>> GetAllProjects()
        {
            List<ModelProject.Models.Project> projects = await this.projectRepositorie.SearchAllProjects();
            return Ok(projects);
        }

        [HttpGet("{projectID}")]
        public async Task<ActionResult<List<ModelProject.Models.Project>>> GetProjectByID(int id)
        {
            ModelProject.Models.Project projectByID = await this.projectRepositorie.SearchByID(id);
            return Ok(projectByID);
        }

        [HttpDelete("{projectID}")]
        public async Task<ActionResult<ModelProject.Models.Project>> RemoveProject(ModelProject.Models.Project project)
        {
            ModelProject.Models.Project projectDelete = await this.projectRepositorie
                .Delete(project, project.projectID);
            return Ok(projectDelete);
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