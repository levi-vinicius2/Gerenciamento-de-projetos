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

        private Boolean updateAssociatedUsers(User associatedUser)
        {
            int count = 0;
            Boolean foundedUser = false;
            if (this.associatedUsers != null)
            {
                foreach (User user1 in this.associatedUsers)
                {
                    if (associatedUser.getUserID() == this.associatedUsers[count].getUserID())
                    {
                        this.associatedUsers[count] = associatedUser;
                        foundedUser = true;
                        return foundedUser;
                    }
                    count++;
                }
            }
            return foundedUser;
        }


        private void updateProject(Project project)
        {
            this.project.setProjectName(project.getProjectName());
        }

        public List<Project> viewAllProjects()
        {
            return this.projectsList;
        }

        public Boolean removeProject(Project project)
        {
            if (this.projectsList != null && this.projectsList.Contains(project))
            {
                this.projectsList.Remove(project);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void setNewAssociatedUser(User user)
        {
            if (this.associatedUsers != null)
            {
                try
                {
                    this.associatedUsers.Add(user);
                    Console.WriteLine("Usuário adicionado com sucesso.");
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

        private void removeAssociatedUser(User user)
        {
            if (this.associatedUsers != null)
            {
                foreach (User user1 in this.associatedUsers)
                {
                    if (user1.getUserID() == user.getUserID())
                    {
                        try
                        {
                            this.associatedUsers.Remove(user);
                            Console.WriteLine("Usuário removido");
                            Console.WriteLine($"Nome: {user.getName()}");
                            Console.WriteLine($"Email: {user.getEmail()}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Erro ao remover usuário {e.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usuário não encontrado");
                    }
                }
            }
            else
            {
                throw new Exception("Não existem usuários para serem removidos");
            }
        }

        private List<User> getAllAssociatedUsers()
        {
            if (this.associatedUsers != null)
            {
                return this.associatedUsers;
            }
            else
            {
                throw new Exception("Não existem usuários associados a esta tarefa");
            }
        }

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

        private void removeTask(ModelTask.Models.Task task)
        {
            if (this.tasks != null)
            {
                foreach (ModelTask.Models.Task task1 in this.tasks)
                {
                    if (task1.getTaskID() == task.getTaskID())
                    {
                        try
                        {
                            this.tasks.Remove(task);
                            Console.WriteLine("Tarefa removida");
                            Console.WriteLine($"Nome da tarefa: {task.getTaskName()}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Erro ao remover tarefa: {e.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tarefa não encontrada");
                    }
                }
            }
            else
            {
                throw new Exception("Erro: Não existem tarefas para ser removidas");
            }
        }

        public List<ModelTask.Models.Task> getAllTasks()
        {
            if (this.tasks != null)
            {
                return this.tasks;
            }
            else
            {
                throw new Exception("Não existem tarefas para ser apresentadas");
            }
        }

        private Boolean updateTask(ModelTask.Models.Task task)
        {
            int count = 0;
            Boolean foundedTask = false;
            if (this.tasks != null)
            {
                foreach (ModelTask.Models.Task task1 in this.tasks)
                {
                    if (task.getTaskID() == this.tasks[count].getTaskID())
                    {
                        this.tasks[count] = task;
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