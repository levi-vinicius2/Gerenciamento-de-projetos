using projectManeger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Repositories
{
    public class TaskRepositorie
    {
        private readonly ProjectManeger? programDBContext;

        public TaskRepositorie(ProjectManeger? programDBContext) { this.programDBContext = programDBContext; }

        public async Task<ModelTask.Models.Task> SearchByID(int id)
        { return await this.programDBContext.TasksDBContext.FirstOrDefaultAsync(x => x.projectID.Equals(id)); }

        public async Task<List<ModelTask.Models.Task>> SearchAllTasks()
        { return await this.programDBContext.TasksDBContext.ToListAsync(); }

        public async Task<ModelTask.Models.Task> AddTask(ModelTask.Models.Task task)
        {
            await programDBContext.TasksDBContext.AddAsync(task);
            programDBContext.SaveChanges();

            return task;
        }

        public async Task<ModelTask.Models.Task> UpdateTask(ModelTask.Models.Task task, int id)
        {
            ModelTask.Models.Task taskByID = await SearchByID(id);
            if(SearchByID(id) == null)
            {
                throw new Exception("id nao encontrado para atualizar a tarefa");
            }

            programDBContext.TasksDBContext.Update(taskByID);
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

            programDBContext.TasksDBContext.Remove(taskByID);
            programDBContext.SaveChanges();

            return task;
        }
    }
}
