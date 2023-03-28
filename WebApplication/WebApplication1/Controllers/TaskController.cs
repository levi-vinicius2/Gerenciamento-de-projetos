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

        [HttpRemove("{taskID}")]
        public void removeTask(int taskID)
        {
            if (this.taskList != null && this.taskList.Contains(task))
            {
                foreach(ModelTask.Models.Task task1 in this.taskList)
                {
                    if (taskID = task1.getTaskID()
                    {
                        try
                        {
                            this.taskList.Remove(task1);
                        }
                        catch
                        {
                            throw new Exception(e)
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Erro: tarefa não encontrada");
            }
        }

        [HttpPut("{taskID}")]
        public void updateTask(int taskID)
        {
            foreach (ModelTask.Models.task task1 in this.taskList)
            {
                if (taskID = task1.getTaskID())
                {
                    setTaskName(task.getTaskName());
                    setObservation(task.getObservation());
                    setResposableUser(task.getResponsableUser());
                }
            }
        }

        [HttpGet]
        public List<ModelTask.Models.Task> viewTask()
        {
            return this.taskList;
        }
    }
}