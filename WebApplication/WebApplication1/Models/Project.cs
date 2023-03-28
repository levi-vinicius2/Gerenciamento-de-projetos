using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelUser.Models;
using ModelTask.Models;

namespace ModelProject.Models
{
    class Project
    {
        private User adminUser;
        public List<User>? associatedUsers;
        public string projectName;
        public List<ModelTask.Models.Task>? tasks;
        private int doneTasks = 0;
        private int projectID;
        private static int nextID = 0;

        public Project(User adminUser, string projectName)
        {
            if (adminUser != null)
            {
                this.projectName = projectName;
                this.projectID = nextID++;
                this.adminUser = new User(adminUser.getName(), adminUser.getEmail(), adminUser.getPassword());
            }
            else
            {
                throw new ArgumentNullException(nameof(adminUser), "O usuário administrador não pode ser nulo.");
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

        private void setAdminUser(User user)
        {
            this.adminUser = user;
        }

        public int getProjectID()
        {
            return this.projectID;
        }

        public List<User> getAssociatedUsers()
        {
            if (this.associatedUsers == null)
            {
                throw new ArgumentNullException("Não existem usuários associados a esta tarefa!");
            }
            return this.associatedUsers;
        }

        public string getProjectName()
        {
            return this.projectName;
        }

        public void setProjectName(string projectName)
        {
            this.projectName = projectName;
        }

    }
}