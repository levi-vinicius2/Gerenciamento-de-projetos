using Microsoft.AspNetCore.Mvc;
using projectManeger.Data;

namespace Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ModelTask.Models.Task tasks;
        private List<ModelTask.Models.Task> TasksList;
        private readonly Task.Repositories.TaskRepositorie taskRepositorie;

        public TaskController(Task.Repositories.TaskRepositorie taskRepositorie, ModelTask.Models.Task task)
        {
            this.tasks = new ModelTask.Models.Task();
            this.taskRepositorie = taskRepositorie;
            this.AddTask(task);
        }

        [HttpPost]
        public async Task<ActionResult<ModelTask.Models.Task>> AddTask(
            [FromBody] ModelTask.Models.Task task)
        {
            List<ModelTask.Models.Task> auxTask = this.TasksList;
            await this.taskRepositorie.AddTask(task);

            return Ok(task);
        }

        [HttpPut("{taskID}")]
        public async Task<ActionResult<ModelTask.Models.Task>> UpdateTask(ModelTask.Models.Task task)
        {
            ModelTask.Models.Task task1 = await this.taskRepositorie.UpdateTask(task, task.taskID);
            return Ok(task1);
        }

        [HttpGet]
        public async Task<ActionResult<List<ModelTask.Models.Task>>> ViewAllTasks()
        {
            List<ModelTask.Models.Task> tasks = await this.taskRepositorie.SearchAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{taskID}")]
        public async Task<ActionResult<List<ModelTask.Models.Task>>> GetTaskByID(int id)
        {
            ModelTask.Models.Task taskByID = await this.taskRepositorie.SearchByID(id);
            return Ok(taskByID);
        }

        [HttpDelete("{projectID}")]
        public async Task<ActionResult<ModelTask.Models.Task>> RemoveTask(ModelTask.Models.Task task)
        {
            ModelTask.Models.Task taskDeleted = await this.taskRepositorie
                .RemoveTask(task, task.taskID);
            return Ok(taskDeleted);
        }

        private bool IsProjectsListEmpty()
        {
            if (this.TasksList == null)
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