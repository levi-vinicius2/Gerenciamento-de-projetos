class Task {
    private string taskName;
    private User responsableUser;
    private DateTime startDate;
    private DateTime finalDate;
    private Boolean overdueTask;
    private int taskID = 0;
    private string observation;

    public Task(string taskName){
        this.taskName = taskName;
        this.taskID++;
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
}