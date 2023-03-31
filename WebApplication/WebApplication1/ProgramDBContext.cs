using Microsoft.EntityFrameworkCore;
using ModelUser.Models;
using ModelTask.Models;
using ModelProject.Models;

namespace projectManeger.Data
{
    public class ProjectManeger : DbContext
    {
        private ProjectManeger projectManeger;
        public DbSet<ModelUser.Models.User> Users { get; set; }

        public DbSet<ModelTask.Models.Task> Tasks { get; set; }

        public DbSet<Project> Project { get; set; }

        public ProjectManeger(DbContextOptions<ProjectManeger> options) : base(options)
        { this.projectManeger = new ProjectManeger(options); }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder) { base.OnModelCreating(modelBuilder); }
    }
}