using Microsoft.AspNetCore.Mvc;
using ModelProject.Models;
using ModelTask.Models;
using ModelUser.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[taskController]")]
    class TaskController : ModelTask.Models.Task
    {
        ModelTask.Models.Task task;
        List<ModelTask.Models.Task> taskList;
        public TaskController(string taskName, int projectID)
        {
            this.task = new ModelTask.Models.Task(taskName, projectID);
            if (this.taskList == null)
            {
                this.taskList = new List<ModelTask.Models.Task> { task };
            }
            else
            {
                this.taskList.Add(task);
            }
        }

        public void removeTask(ModelTask.Models.Task task)
        {
            if (this.taskList != null && this.taskList.Contains(task))
            {
                taskList.Remove(task);
            }
            else
            {
                throw new Exception("Erro: tarefa não encontrada");
            }
        }
        public void updateTask(ModelTask.Models.Task task)
        {
            setTaskName(task.getTaskName());
            setObservation(task.getObservation());
            setResposableUser(task.getResponsableUser());
        }
        public List<ModelTask.Models.Task> viewTask()
        {
            return this.taskList;
        }
    }
}