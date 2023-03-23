class taskController : Task
{
    Task task;
    public taskController(string taskName)
    {
        this.task = new Task(taskName);
    }

    //public void removeTask(){
    //    this.task
   // }
    public void updateTask(Task task)
    {
        setTaskName(task.getTaskName());
        setObservation(task.getObservation());
        setResposableUser(task.getResponsableUser());
    }
    public Task viewTask(){
        return this.task;
    }
}