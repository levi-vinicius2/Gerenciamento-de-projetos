using Microsoft.EntityFrameworkCore;

namespace projectManeger.Data
{
    public class ProjectManeger : DbContext
    {
        public DbSet<ModelUser.Models.User> UsersDBContext { get; set; }

        public DbSet<ModelTask.Models.Task> TasksDBContext { get; set; }

        public DbSet<ModelProject.Models.Project> ProjectDBContext { get; set; }

        public ProjectManeger(DbContextOptions<ProjectManeger> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ModelUser.Models.User>(new UserMap.Map.UserMap());
            modelBuilder.ApplyConfiguration<ModelProject.Models.Project>(new ProjectMap.Map.ProjectMap());
            modelBuilder.ApplyConfiguration<ModelTask.Models.Task>(new TaskMap.Map.TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}