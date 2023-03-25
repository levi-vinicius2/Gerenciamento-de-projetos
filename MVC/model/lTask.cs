class Task {
    public string taskName;
    private User? responsableUser;
    private DateTime startDate;
    private DateTime finalDate;
    private Boolean overdueTask;
    private Boolean doneTask;
    private int taskID;
    private static int nextTaskID = 0;
    private string? observation;
    private int projectID;

    public Task(string taskName, Project project){
        this.taskName = taskName;
        this.taskID = nextTaskID++;
        this.projectID = project.getProjectID();
    }

    public Task(){
        this.taskName = "Nome Tarefa 1";
        this.taskID = nextTaskID++;
        this.projectID = 1000;
    }
  
    public string getTaskName(){
        return this.taskName;
    }
    public string getTaskID(){
        return this.taskName;
    }
    public void setTaskName(string taskName){
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
    public void setObservation(string observation){
        this.observation = observation;
    }
    public string getObservation(){
        if (this.observation != null)
        return this.observation;
        else
        throw new Exception("Não existe nenhuma observação");
    }
    public User getResponsableUser(){
        if (this.responsableUser != null)
        return this.responsableUser;
        else
        throw new Exception("Não existe nenhum usuário responsável");
    }
    public void setResposableUser(User user){
        this.responsableUser = user;
    }
}