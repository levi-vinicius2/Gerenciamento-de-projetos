using projectManeger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Repositories
{
    [Table("Task")]
    public class TaskRepositorie
    {
        private readonly ProjectManeger? programDBContext;

        public TaskRepositorie(ProjectManeger? programDBContext) { this.programDBContext = programDBContext; }

        public async Task<ModelTask.Models.Task> SearchByID(int id)
        {
            if (programDBContext == null)
            {
                throw new Exception("O contexto do banco de dados não foi inicializado.");
            }
            return await this.programDBContext.TasksDbContext.FirstOrDefaultAsync(x => x.projectID == id); 
        }

        public async Task<List<ModelTask.Models.Task>> SearchAllTasks()
        { return await this.programDBContext.TasksDbContext.ToListAsync(); }

        public async Task<ModelTask.Models.Task> AddTask(ModelTask.Models.Task task)
        {
            if (programDBContext == null)
            {
                throw new Exception("O contexto do banco de dados não foi inicializado.");
            }
            await programDBContext.TasksDbContext.AddAsync(task);
            programDBContext.SaveChanges();

            return task;
        }

        public async Task<ModelTask.Models.Task> UpdateTask(ModelTask.Models.Task task, int id)
        {
            if(SearchByID(id) == null)
            {
                throw new Exception("id nao encontrado para atualizar a tarefa");
            }

            ModelTask.Models.Task taskByID = await SearchByID(id);
            programDBContext.TasksDbContext.Update(taskByID);
            programDBContext.SaveChanges();

            return task;
        }

        public async Task<ModelTask.Models.Task> RemoveTask(ModelTask.Models.Task task, int id)
        {
            ModelTask.Models.Task taskByID = await SearchByID(id);
            if(taskByID == null)
            {
                throw new Exception("id nao encontrado para remover a tarefa");
            }

            programDBContext.TasksDbContext.Remove(taskByID);
            programDBContext.SaveChanges();

            return task;
        }
    }
}
