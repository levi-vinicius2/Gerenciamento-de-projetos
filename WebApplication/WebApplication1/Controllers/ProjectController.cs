using Microsoft.AspNetCore.Mvc;
using ModelProject.Models;
using ModelTask.Models;
using ModelUser.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[projectController]")]

    class ProjectController : Project
    {
        Project project;
        List<Project> projectsList;

        public ProjectController(User user)
        {
            this.project = new Project();
            if (this.projectsList == null)
            {
                this.projectsList = new List<Project> { project };
            }
            else
            {
                this.projectsList.Add(project);
            }
        }

        public ProjectController(User user, Project project)
        {
            this.project = new Project(user, project.getProjectName());
            if (this.projectsList == null)
            {
                this.projectsList = new List<Project> { project };
            }
            else
            {
                this.projectsList.Add(project);
            }
        }

        [HttpPut("{UserID}")]
        private Boolean updateAssociatedUsers(int userID)
        {
            int count = 0;
            Boolean foundedUser = false;
            if (this.associatedUsers != null)
            {
                foreach (User user1 in this.associatedUsers)
                {
                    if (userID == this.associatedUsers[count].getUserID())
                    {
                        this.associatedUsers[count] = user1;
                        foundedUser = true;
                        return foundedUser;
                    }
                    count++;
                }
            }
            return foundedUser;
        }

        [HttpPut("{projectID}")]
        private Boolean updateProject(int projectID)
        {
            int count = 0;
            Boolean foundedProject = false;
            if (this.projectsList != null)
            {
                foreach (Project projectsList1 in this.projectsList)
                {
                    if (projectID == this.projectsList[count].getProjectID())
                    {
                        this.projectsList[count] = projectsList1;
                        foundedProject = true;
                        return foundedProject;
                    }
                    count++;
                }
            }
            return foundedProject;
        }

        [HttpGet]
        public List<Project> viewAllProjects()
        {
            return this.projectsList;
        }

        [HttpDelete("{projectID}")]
        public Boolean removeProject(int projectID)
        {
            if (this.projectsList != null && this.projectsList.Contains(project))
            {
                foreach(Project project in this.projectsList)
                {
                    if(project.getProjectID() == projectID)
                    {
                        try
                        {
                            this.projectsList.Remove(project);
                        } catch(Exception e)
                        {
                            throw new Exception("Erro: "+e);
                        }
                        return true;
                    }
                }
                
            }
            return false;
        }

        [HttpPost]
        private void setNewAssociatedUser(User user)
        {
            if (this.associatedUsers != null)
            {
                try
                {
                    this.associatedUsers.Add(user);
                    Console.WriteLine("Usu�rio adicionado com sucesso.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
            }
            else
            {
                this.associatedUsers = new List<User> { user };
            }
        }

        [HttpDelete("{userID}")]
        private void removeAssociatedUser(int userID)
        {
            if (this.associatedUsers != null)
            {
                foreach (User user1 in this.associatedUsers)
                {
                    if (user1.getUserID() == userID)
                    {
                        try
                        {
                            this.associatedUsers.Remove(user1);
                            Console.WriteLine("Usu�rio removido");
                            Console.WriteLine($"Nome: {user1.getName()}");
                            Console.WriteLine($"Email: {user1.getEmail()}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Erro ao remover usu�rio {e.Message}");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("N�o existem usu�rios para serem removidos");
            }
        }

        [HttpGet]
        private List<User> getAllAssociatedUsers()
        {
            if (this.associatedUsers != null)
            {
                return this.associatedUsers;
            }
            else
            {
                throw new Exception("N�o existem usu�rios associados a esta tarefa");
            }
        }

        [HttpPost]
        private void setNewTask(ModelTask.Models.Task task)
        {
            if (this.tasks != null)
            {
                try
                {
                    this.tasks.Add(task);
                    Console.WriteLine("Tarefa adicionada ao projeto.");
                    Console.WriteLine($"Nome da tarefa: {task.getTaskName()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao adicionar a tarefa {e.Message}");
                }
            }
            else
            {
                this.tasks = new List<ModelTask.Models.Task> { task };
            }
        }

        [HttpDelete("{taskID}")]
        private void removeTask(int taskID)
        {
            if (this.tasks != null)
            {
                foreach (ModelTask.Models.Task task1 in this.tasks)
                {
                    if (task1.getTaskID() == taskID)
                    {
                        try
                        {
                            this.tasks.Remove(task1);
                            Console.WriteLine("Tarefa removida");
                            Console.WriteLine($"Nome da tarefa: {task1.getTaskName()}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Erro ao remover tarefa: {e.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tarefa n�o encontrada");
                    }
                }
            }
            else
            {
                throw new Exception("Erro: N�o existem tarefas para ser removidas");
            }
        }

        [HttpGet]
        public List<ModelTask.Models.Task> getAllTasks()
        {
            if (this.tasks != null)
            {
                return this.tasks;
            }
            else
            {
                throw new Exception("N�o existem tarefas para ser apresentadas");
            }
        }

        [HttpPut("{taskID}")]
        private Boolean updateTask(int taskID)
        {
            int count = 0;
            Boolean foundedTask = false;
            if (this.tasks != null)
            {
                foreach (ModelTask.Models.Task task1 in this.tasks)
                {
                    if (taskID == this.tasks[count].getTaskID())
                    {
                        this.tasks[count] = task1;
                        foundedTask = true;
                        return foundedTask;
                    }
                    count++;
                }
            }
            return foundedTask;
        }
    }
}