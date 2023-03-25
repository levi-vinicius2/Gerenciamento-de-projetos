class taskController : Task
{
    Task task;
    List<Task> taskList;
    public taskController(string taskName)
    {
        this.task = new Task(taskName);
        if (this.taskList == null){
            this.taskList = new List<Task> {task};
        } else {
            this.taskList.Add(task);
        }
    }

    public void removeTask(Task task){
        if (this.taskList != null && this.taskList.Contains(task)){
            taskList.Remove(task);
        } else {
            throw new Exception("Erro: tarefa não encontrada");
        }
    }
    public void updateTask(Task task)
    {
        setTaskName(task.getTaskName());
        setObservation(task.getObservation());
        setResposableUser(task.getResponsableUser());
    }
    public List<Task> viewTask(){
        return this.taskList;
    }
}