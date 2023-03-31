using projectManeger.Data;
using Microsoft.EntityFrameworkCore;

namespace Task.Repositories
{
    public class TaskRespositorie
    {
        private readonly ProjectManeger? programDBContext;

        public TaskRespositorie(ProjectManeger? programDBContext)
        {
            this.programDBContext = programDBContext;
        }

        public async Task<ModelTask.Models.Task> SearchByID(int id)
        {
            return await this.programDBContext.Tasks.FirstOrDefaultAsync(x => x.GetTaskID().Equals(id));
        }

        public async Task<List<ModelTask.Models.Task>> SearchAllTasks()
        {
            return await this.programDBContext.Tasks.ToListAsync();
        }

        public async Task<ModelTask.Models.Task> AddTask(ModelTask.Models.Task task)
        {
            programDBContext.Tasks.AddAsync(task);
            programDBContext.SaveChanges();

            return task;
        }

        public async Task<ModelTask.Models.Task> UpdateTask(ModelTask.Models.Task task, int id)
        {
            ModelTask.Models.Task taskByID = await SearchByID(id);
            if (SearchByID(id) == null)
            {
                throw new Exception("id nao encontrado para atualizar a tarefa");
            }

            programDBContext.Tasks.Update(taskByID);
            programDBContext.SaveChanges();

            return task;
        }

        public async Task<ModelTask.Models.Task> RemoveTask(ModelTask.Models.Task task, int id)
        {
            ModelTask.Models.Task taskByID = await SearchByID(id);
            if (SearchByID(id) == null)
            {
                throw new Exception("id nao encontrado para remover a tarefa");
            }

            programDBContext.Tasks.Remove(taskByID);
            programDBContext.SaveChanges();

            return task;
        }
    }
}
