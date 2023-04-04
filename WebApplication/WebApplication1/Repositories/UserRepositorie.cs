using Microsoft.EntityFrameworkCore;
using projectManeger.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Repositories
{
    [Table("Users")]
    public class UserRepositorie : IUserRepositorie
    {
        private readonly ProjectManeger? programDBContext;

        public UserRepositorie(ProjectManeger? programDBContext) { this.programDBContext = programDBContext; }

        public async Task<ModelUser.User> SearchByID(int id)
        {
            if (programDBContext == null)
            {
                throw new Exception("O contexto do banco de dados não foi inicializado.");
            }
            return await programDBContext.UsersDbContext.FirstOrDefaultAsync(x => x.UserID.Equals(id)); 
        }

        public async Task<List<ModelUser.User>> SearchAllUsers()
        {
            if (programDBContext == null)
            {
                throw new Exception("O contexto do banco de dados não foi inicializado.");
            }
            return await programDBContext.UsersDbContext.ToListAsync(); 
        }

        public async Task<ModelUser.User> Add(ModelUser.User user)
        {
            if (programDBContext == null)
            {
                throw new Exception("O contexto do banco de dados não foi inicializado.");
            }
            await programDBContext.UsersDbContext.AddAsync(user);
            programDBContext.SaveChanges();
            return user;
        }

        public async Task<ModelUser.User> Update(ModelUser.User user)
        {
            if (programDBContext == null)
            {
                throw new Exception("O contexto do banco de dados não foi inicializado.");
            }
            ModelUser.User userByID = await SearchByID(user.UserID);

            programDBContext.UsersDbContext.Update(userByID);
            programDBContext.SaveChanges();

            return userByID;
        }

        public async Task<ModelUser.User> Delete(ModelUser.User user)
        {
            if (programDBContext == null)
            {
                throw new Exception("O contexto do banco de dados não foi inicializado.");
            }
            ModelUser.User userByID = await SearchByID(user.UserID);
            if (userByID == null)
            {
                throw new Exception("ID nao encontrado no banco de dados para realizar a exclusao de usuario");
            }

            programDBContext.UsersDbContext.Remove(userByID);
            programDBContext.SaveChanges();

            return userByID;
        }
    }
}
