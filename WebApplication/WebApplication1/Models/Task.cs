using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelUser.Models;
using ModelProject.Models;

namespace ModelTask.Models
{
    public class Task
    {
        public string taskName;
        private ModelUser.Models.User? responsableUser;
        private DateTime startDate;
        private DateTime finalDate;
        private Boolean overdueTask;
        private Boolean doneTask;
        private readonly int taskID;
        private static int nextTaskID = 0;
        private string? observation;
        private readonly int projectID;

        public Task(string taskName, int projectID)
        {
            this.taskName = taskName;
            this.taskID = nextTaskID++;
            this.projectID = projectID;
            this.SetStartDate();
        }

        public Task()
        {
            this.taskName = "Nome Tarefa 1";
            this.taskID = nextTaskID++;
            this.projectID = 1000;
            this.SetStartDate();
        }

        public string GetTaskName() { return this.taskName; }
        public int GetTaskID() { return this.taskID; }
        public void SetTaskName(string taskName) { this.taskName = taskName; }
        private void SetFinalDate(DateTime finalDate) { this.finalDate = finalDate; }
        private void SetStartDate() { this.startDate = DateTime.Now; }
        public DateTime GetStartDate() { return this.startDate; }
        public DateTime GetFinalDate() { return this.finalDate; }
        public void SetObservation(string observation) { this.observation = observation; }

        public string GetObservation()
        {
            if(this.observation != null)
                return this.observation;
            else
                throw new Exception("N�o existe nenhuma observa��o");
        }

        public ModelUser.Models.User GetResponsableUser()
        {
            if(this.responsableUser != null)
                return this.responsableUser;
            else
                throw new Exception("N�o existe nenhum usu�rio respons�vel");
        }

        public void SetResposableUser(ModelUser.Models.User user) { this.responsableUser = user; }
    }
}