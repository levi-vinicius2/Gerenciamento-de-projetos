class Project{
    public User adminUser;
    public List<User> associatedUsers;
    public string projectName;
    public List<Task> tasks;
    private int doneTasks = 0;
    private int projectID = 0;

    public Project(User adminUser, string projectName){
        if (adminUser != null){
            this.projectName = projectName;
            this.projectID++;
            setAdminUser(adminUser);
        } else {
            Console.Write("Erro! Usuário adm não existe");
        }
    }

    public Project(){
        this.adminUser = new User();
    }

    public User GetAdminUser(){
        return this.adminUser;
    }

    private void setAdminUser(User user){
        this.adminUser = user;
    }

    public int getProjectID(){
        return this.projectID;
    }

    public List<User> getAssociatedUsers(){
        return this.associatedUsers;
    }

    public string getProjectName(){
        return this.projectName;
    }

    public void setProjectName(string projectName){
        this.projectName = projectName;
    }

}