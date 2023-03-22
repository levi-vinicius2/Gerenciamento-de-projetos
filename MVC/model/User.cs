class User
{
    string name;
    string email;
    string password;
    int userID = 0;
    List<Project> associatedProjects;

    public User (){
        this.name = "First user";
        this.email= "levi.vinicius@outlook.com";
        this.password = "123456";
        this.userID = 1;
    }

    public User(string name, string email, string password){
        this.name = name;
        this.email = email;
        this.password = password;
        this.userID++;
    }

    private void updateUser(User user){
        setEmail(user.getEmail());
        setName(user.getName());
        setPassword(user.getPassword());
    }

    private void setName(string name){
        this.name = name;
    }

    private string getPassword(){
        return this.password;
    }

    public string getName(){
        return this.name;
    }

    private void setEmail(string email){
        this.email = email;
    }

    public string getEmail(){
        return this.email;
    }

    private void setPassword(string password){
        this.password = password;
    }

    public int getUserID(){
        return this.getUserID();
    }

    public List<Project> getAllAssociatedProjects(){
        return this.associatedProjects;
    }

    public void setAssociatedProject(Project project){
        this.associatedProjects.Add(project);
    }

    public Boolean removeAssociatedProject(Project project){
        Boolean foundedProject = false;
        int count = 0;
        foreach(Project project1 in this.associatedProjects){
            if(project.getProjectID() == project.getProjectID()){
                foundedProject = true;
                this.associatedProjects[count].updateProject(project);
                return foundedProject;
            }
            count++;
        }
        return foundedProject;
    }
}