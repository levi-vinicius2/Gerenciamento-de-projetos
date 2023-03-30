using Microsoft.EntityFrameworkCore;
using ModelUser.Models;
using ModelTask.Models;
using ModelProject.Models;

namespace projectManeger.Data
{
    public class ProjectManeger : DbContext
    {
        public ProjectManeger(DbContextOptions<ProjectManeger> options) : base(options)
        {
            
        }


        public DbSet<User> users { get; set; }

        public DbSet<ModelTask.Models.Task> task { get; set; }

        public DbSet<Project> project { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}