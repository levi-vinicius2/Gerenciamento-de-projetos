class userController : User
{
    User user;

    public userController(User user)
    {
        this.user = new User(user.getName(), user.getEmail(), user.getPassword());
    }
    public userController()
    {
        this.user = new User();
    }
    public void updateUser(User user)
    {
        this.user.setEmail(user.getEmail());
        this.user.setName(user.getName());
        this.user.setPassword(user.getPassword());
    }
    public User getUser()
    {
        return this.user;
    }

    public Boolean removeAssociatedProject(projectController project)
    {
        Boolean foundedProject = false;
        if (this.associatedProjects != null)
        {
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
        }
        return foundedProject;
    }

    public List<projectController> getAllAssociatedProjects()
    {
        if (this.associatedProjects != null)
        {
            return this.associatedProjects;
        }
        else
        {
            throw new ArgumentNullException("Nao existem projetos associados");
        }
    }

    public void setAssociatedProject(projectController project)
    {
        if (this.associatedProjects != null)
        {
            try
            {
                this.associatedProjects.Add(project);
            }
            catch (Exception e)
            {
                throw new Exception("Erro" + e);
            }
        }
        else
        {
            userController auxUser = new userController(this.user);
            this.associatedProjects = new List<projectController> { project };
        }
    }


    public Boolean updateAssociatedProject(projectController project)
    {
        int count = 0;
        Boolean foundedProject = false;
        if (this.associatedProjects != null)
        {
            foreach (projectController project1 in associatedProjects)
            {
                if (project.getProjectID() == this.associatedProjects[count].getProjectID())
                {
                    foundedProject = true;
                    this.associatedProjects[count] = project;
                    count++;
                    return foundedProject;
                }
            }
        }
        return foundedProject;
    }
}