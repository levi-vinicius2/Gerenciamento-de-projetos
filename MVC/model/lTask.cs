class Task {
    private string taskName;
    private User responsableUser;
    private DateTime startDate;
    private DateTime finalDate;
    private Boolean overdueTask;
    private Boolean donaTask;
    private int taskID = 0;
    private string observation;

    public Task(string taskName){
        this.taskName = taskName;
        this.taskID++;
    }
    private void updateTask(Task task){
        setTaskName(task.getTaskName());
        setObservation(task.getObservation());
        setResposableUser(task.getResponsableUser());
    }
    public string getTaskName(){
        return this.taskName;
    }
    public string getTaskID(){
        return this.taskName;
    }
    private void setTaskName(string taskName){
        this.taskName = taskName;
    }
    private void setFinalDate(DateTime finalDate){
        this.finalDate = finalDate;
    }
    private void setStartDate(){
        this.startDate = DateTime.Now;
    }
    public DateTime getStartDate(){
        return this.startDate;
    }
    public DateTime getFinalDate(){
        return this.finalDate;
    }
    private void setObservation(string observation){
        this.observation = observation;
    }
    public string getObservation(){
        return this.observation;
    }
    public User getResponsableUser(){
        return this.responsableUser;
    }
    private void setResposableUser(User user){
        this.responsableUser = user;
    }
}