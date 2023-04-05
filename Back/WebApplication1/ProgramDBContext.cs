using Microsoft.EntityFrameworkCore;

namespace projectManeger.Data
{
    public class ProjectManeger : DbContext
    {
        public ProjectManeger(DbContextOptions<ProjectManeger> options) : base(options)
        {
        }
        public DbSet<ModelUser.User> UsersDbContext { get; set; }

        public DbSet<ModelTask.Models.Task> TasksDbContext { get; set; }

        public DbSet<ModelProject.Models.Project> ProjectDbContext { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelUser.User>().ToTable("Users");
            modelBuilder.Entity<ModelProject.Models.Project>().ToTable("Project");
            modelBuilder.Entity<ModelTask.Models.Task>().ToTable("Task");
            modelBuilder.ApplyConfiguration<ModelUser.User>(new UserMap.Map.UserMap());
            modelBuilder.ApplyConfiguration<ModelProject.Models.Project>(new ProjectMap.Map.ProjectMap());
            modelBuilder.ApplyConfiguration<ModelTask.Models.Task>(new TaskMap.Map.TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}