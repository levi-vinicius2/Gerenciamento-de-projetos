using projectManeger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Repositories
{
    [Table("Project")]
    public class ProjectRepositorie
    {
        private readonly ProjectManeger? programDBContext;

        public ProjectRepositorie(ProjectManeger? programDBContext) { this.programDBContext = programDBContext; }

        public async Task<ModelProject.Models.Project> SearchByID(int id)
        { return await this.programDBContext.ProjectDbContext.FirstOrDefaultAsync(x => x.projectID == id); }

        public async Task<List<ModelProject.Models.Project>> SearchAllProjects()
        { return await this.programDBContext.ProjectDbContext.ToListAsync(); }

        public async Task<ModelProject.Models.Project> Add(ModelProject.Models.Project Project)
        {
            await this.programDBContext.ProjectDbContext.AddAsync(Project);
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

            this.programDBContext.ProjectDbContext.Update(ProjectByID);
            this.programDBContext.SaveChanges();

            return ProjectByID;
        }

        public async Task<ModelProject.Models.Project> Delete(ModelProject.Models.Project Project, int id)
        {
            ModelProject.Models.Project ProjectByID = await SearchByID(id);
            if(ProjectByID == null)
            {
                throw new Exception("ID nao encontrado no banco de dados para realizar a exclusao de usuario");
            }

            this.programDBContext.ProjectDbContext.Remove(ProjectByID);
            this.programDBContext.SaveChanges();

            return ProjectByID;
        }
    }
}
