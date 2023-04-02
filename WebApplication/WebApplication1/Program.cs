using Microsoft.EntityFrameworkCore;
using projectManeger.Data;
using Microsoft.Extensions.Configuration;

namespace projectManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<projectManeger.Data.ProjectManeger>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );


            builder.Services.AddScoped<Project.Repositories.ProjectRepositorie, Project.Repositories.ProjectRepositorie>();
            builder.Services.AddScoped<Task.Repositories.TaskRepositorie, Task.Repositories.TaskRepositorie>();
            builder.Services.AddScoped<User.Repositories.IUserRepositorie, User.Repositories.UserRepositorie>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}


