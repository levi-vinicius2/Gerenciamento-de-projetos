using Microsoft.AspNetCore.Mvc;
using ModelProject.Models;
using ModelTask.Models;
using ModelUser.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[taskController]")]
    class TaskController : Controller
    {
        private readonly ModelTask.Models.Task task;
        private List<ModelTask.Models.Task> taskList;

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

        [HttpDelete("{taskID}")]
        public void RemoveTask(int taskID)
        {
            if (!this.IsTaskListEmpty())
            {
                foreach(ModelTask.Models.Task task1 in this.taskList)
                {
                    if (taskID == task1.getTaskID())
                    {
                        try
                        {
                            this.taskList.Remove(task1);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e+"Erro");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Erro: tarefa n�o encontrada");
            }
        }

        [HttpPut("{taskID}")]
        public void UpdateTask(int taskID)
        {
            if (!this.IsTaskListEmpty()) 
            { 
                foreach (ModelTask.Models.Task task1 in this.taskList)
                {
                    if (taskID == task1.getTaskID())
                    {
                        this.taskList[taskID] = task1;
                    }
                }
            }
        }

        [HttpGet]
        public List<ModelTask.Models.Task> ViewTask()
        {
            return this.taskList;
        }

        private bool IsTaskListEmpty()
        {
            if (this.taskList == null)
            { return true;} 
            else 
            { return false; }
        }
    }
}