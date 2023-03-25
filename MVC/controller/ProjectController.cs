using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

class projectController : Project
{
    Project project;
    List<Project> projectsList;

    public projectController(User user)
    {
        this.project = new Project();
        if (this.projectsList == null){
            this.projectsList = new List<Project>{project};
        } else {
            this.projectsList.Add(project);
        }
    }
    public projectController(userController user, Project project)
    {
        this.project = new Project(user, project.getProjectName());
        if (this.projectsList == null){
            this.projectsList = new List<Project>{project};
        } else {
            this.projectsList.Add(project);
        }
    }

    private Boolean updateAssociatedUsers(userController associatedUser)
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

    public List<Project> viewAllProjects(){
        return this.projectsList;
    }

    public Boolean removeProject(Project project){
        if (this.projectsList != null && this.projectsList.Contains(project)){
            this.projectsList.Remove(project);
            return true;
        } else {
            return false;
        }
    }

    private void setNewAssociatedUser(userController user)
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
            this.associatedUsers = new List<userController> { user };
        }
    }

    private void removeAssociatedUser(userController user)
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

    private List<userController> getAllAssociatedUsers()
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

    private void setNewTask(Task task)
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
            this.tasks = new List<Task> { task };
        }
    }

    private void removeTask(Task task)
    {
        if (this.tasks != null)
        {
            foreach (Task task1 in this.tasks)
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

    public List<Task> getAllTasks()
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

    private Boolean updateTask(Task task)
    {
        int count = 0;
        Boolean foundedTask = false;
        if (this.tasks != null)
        {
            foreach (Task task1 in this.tasks)
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