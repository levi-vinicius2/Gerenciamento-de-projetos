class userController : User
{
    User user;

    public userController(User user){
        this.user = new User(user.getName(), user.getEmail(), user.getPassword());
    }
    public userController(){
        this.user = new User();
    }
    public void updateUser(User user)
    {
        this.user.setEmail(user.getEmail());
        this.user.setName(user.getName());
        this.user.setPassword(user.getPassword());
    }
    public User getUser(){
        return this.user;
    }

    public Boolean removeAssociatedProject(Project project)
    {
        Boolean foundedProject = false;
        foreach (Project project1 in this.associatedProjects)
        {
            if (project.getProjectID() == project.getProjectID())
            {
                foundedProject = true;
                try
                {
                    this.associatedProjects.Remove(project);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro: {e}");
                }
                return foundedProject;
            }
        }
        return foundedProject;
    }

    public List<Project> getAllAssociatedProjects()
    {
        return this.associatedProjects;
    }

    public void setAssociatedProject(Project project)
    {
        this.associatedProjects.Add(project);
    }

    public Boolean updateAssociatedProject(Project project){
        int count = 0;
        Boolean foundedProject = false;
        foreach(Project project1 in associatedProjects){
            if (project.getProjectID() == this.associatedProjects[count].getProjectID()){
                foundedProject = true;
                this.associatedProjects[count] = project;
                count ++;
                return foundedProject;
            }
        }
        return foundedProject;
    }
}