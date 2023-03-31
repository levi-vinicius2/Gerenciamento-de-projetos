using projectManeger.Data;
using Microsoft.EntityFrameworkCore;

namespace Project.Repositories
{
    public class ProjectRepositorie
    {
        private readonly ProjectManeger? programDBContext;

        public ProjectRepositorie(ProjectManeger? programDBContext) { this.programDBContext = programDBContext; }

        public async Task<ModelProject.Models.Project> SearchByID(int id)
        { return await programDBContext.Project.FirstOrDefaultAsync(x => x.GetProjectID() == id); }

        public async Task<List<ModelProject.Models.Project>> SearchAllProjects()
        { return await programDBContext.Project.ToListAsync(); }

        public async Task<ModelProject.Models.Project> Add(ModelProject.Models.Project Project)
        {
            programDBContext.Project.AddAsync(Project);
            programDBContext.SaveChanges();
            return Project;
        }

        public async Task<ModelProject.Models.Project> Update(ModelProject.Models.Project Project, int id)
        {
            ModelProject.Models.Project ProjectByID = await SearchByID(id);
            if(ProjectByID == null)
            {
                throw new Exception("ID nao encontrado no banco de dados para atualizar o usuario");
            }

            ProjectByID = Project;

            programDBContext.Project.Update(ProjectByID);
            programDBContext.SaveChanges();

            return ProjectByID;
        }

        public async Task<ModelProject.Models.Project> Delete(ModelProject.Models.Project Project, int id)
        {
            ModelProject.Models.Project ProjectByID = await SearchByID(id);
            if(ProjectByID == null)
            {
                throw new Exception("ID nao encontrado no banco de dados para realizar a exclusao de usuario");
            }

            programDBContext.Project.Remove(ProjectByID);
            programDBContext.SaveChanges();

            return ProjectByID;
        }
    }
}
