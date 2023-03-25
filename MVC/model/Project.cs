class Project
{
    public userController adminUser = new userController();
    public List<userController>? associatedUsers;
    public string projectName;
    public List<Task>? tasks;
    private int doneTasks = 0;
    private int projectID;
    private static int nextID = 0;

    public Project(User adminUser, string projectName)
    {
        if (adminUser != null)
        {
            this.projectName = projectName;
            this.projectID = nextID++;
            userController auxUser = new userController(adminUser);
            setAdminUser(auxUser);
        }
        else
        {
            throw new ArgumentNullException(nameof(adminUser), "O usuário administrador não pode ser nulo.");
        }
    }

    public Project()
    {
        this.adminUser = new userController();
        this.projectName = "Projeto";
    }

    public User GetAdminUser()
    {
        return this.adminUser;
    }

    private void setAdminUser(userController user)
    {
        this.adminUser = user;
    }

    public int getProjectID()
    {
        return this.projectID;
    }

    public List<userController> getAssociatedUsers()
    {
        if (this.associatedUsers == null)
        {
            throw new ArgumentNullException("Não existem usuários associados a esta tarefa!");
        }
        return this.associatedUsers;
    }

    public string getProjectName()
    {
        return this.projectName;
    }

    public void setProjectName(string projectName)
    {
        this.projectName = projectName;
    }

}