class Project{
    private User adminUser;
    private List<User> associatedUsers;
    private string projectName;
    private List<Task> tasks;
    private int doneTasks = 0;

    public User GetAdminUser(){
        return this.adminUser;
    }

    private User setAdminUser(User user){
        this.adminUser = user;
    }

    public List<User> getAssociatedUsers(){
        return this.associatedUsers;
    }

    private void setNewAssociatedUser(User user){
        try{
            this.associatedUsers.Add(user);
            Console.WriteLine("Usuário adicionado com sucesso.");
        } catch(e){
            Console.WriteLine($"Erro: {e}");
        }
    }

    private void removeAssociatedUser(User user){
        foreach (User user1 in this.associatedUsers){
            if (user1.getUserID() == user.getUserID()){
                try {
                    this.associatedUsers.Remove(user);
                    Console.WriteLine("Usuário removido");
                    Console.WriteLine($"Nome: {user.getName()}");
                    Console.WriteLine($"Email: {user.getEmail()}");
                } catch(e){
                    Console.WriteLine($"Erro ao remover usuário {e}");
                }
            } else {
                Console.WriteLine("Usuário não encontrado");
            }
        }
    }

    private void setNewTask(Task task){
        try{
            this.tasks.Add(task);
            Console.WriteLine("Tarefa adicionada ao projeto.");
            Console.WriteLine($"Nome da tarefa: {task.getTaskName()}");
        } catch(e){
            Console.WriteLine($"Erro ao adicionar a tarefa {e}");
        }
    }

    private void removeTask(Task task){
        foreach(Task task1 in task){
            if(task1.getTaskID() == task.getTaskID()){
                try{
                    this.tasks.Remove(task);
                    Console.WriteLine("Tarefa removida");
                    Console.WriteLine($"Nome da tarefa: {task.getTaskName()}");
                } catch (e){
                    Console.WriteLine($"Erro ao remover tarefa: {e}");
                }
            } else {
                Console.WriteLine("Tarefa não encontrada");
            }
        }
    }

    public List<Task> getAllTasks(){
        return this.tasks;
    }

    public string getProjectName(){
        return this.projectName;
    }

    private void setProjectName(string projectName){
        this.projectName = projectName;
    }

}