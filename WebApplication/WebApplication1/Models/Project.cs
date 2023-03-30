using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelUser.Models;
using ModelTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ModelProject.Models
{
    public class Project : DbContext
    {
        private User adminUser;
        public List<User>? associatedUsers;
        public string projectName;
        public List<ModelTask.Models.Task>? tasks;
        private int doneTasks = 0;
        private readonly int projectID;
        private static int nextID = 0;

        public Project(User adminUser, string projectName)
        {
            if (adminUser != null)
            {
                this.projectName = projectName;
                this.projectID = nextID++;
                this.adminUser = new User(adminUser.GetName(), adminUser.GetEmail(), adminUser.GetPassword());
            }
            else
            {
                throw new ArgumentNullException(nameof(adminUser), "O usu�rio administrador n�o pode ser nulo.");
            }
        }

        public Project()
        {
            this.adminUser = new User();
            this.projectName = "Projeto";
        }

        public User GetAdminUser()
        {
            return this.adminUser;
        }

        private void SetAdminUser(User user)
        {
            this.adminUser = user;
        }

        public int GetProjectID()
        {
            return this.projectID;
        }

        public List<User> GetAssociatedUsers()
        {
            if (this.associatedUsers == null)
            {
                throw new ArgumentNullException("N�o existem usu�rios associados a esta tarefa!");
            }
            return this.associatedUsers;
        }

        public string GetProjectName()
        {
            return this.projectName;
        }

        public void SetProjectName(string projectName)
        {
            this.projectName = projectName;
        }

    }
}