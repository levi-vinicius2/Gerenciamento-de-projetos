using Microsoft.EntityFrameworkCore;
using projectManeger.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace User.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly ProjectManeger? programDBContext;

        public UserRepositorie(ProjectManeger? programDBContext) { this.programDBContext = programDBContext; }

        public async Task<ModelUser.Models.User> SearchByID(int id)
        { return await programDBContext.UsersDBContext.FirstOrDefaultAsync(x => x.UserID == id); }

        public async Task<List<ModelUser.Models.User>> SearchAllUsers()
        { return await programDBContext.UsersDBContext.ToListAsync(); }

        public async Task<ModelUser.Models.User> Add(ModelUser.Models.User user)
        {
            programDBContext.UsersDBContext.AddAsync(user);
            programDBContext.SaveChanges();
            return user;
        }

        public async Task<ModelUser.Models.User> Update(ModelUser.Models.User user)
        {
            ModelUser.Models.User userByID = await SearchByID(user.UserID);

            programDBContext.UsersDBContext.Update(userByID);
            programDBContext.SaveChanges();

            return userByID;
        }

        public async Task<ModelUser.Models.User> Delete(ModelUser.Models.User user)
        {
            ModelUser.Models.User userByID = await SearchByID(user.UserID);
            if (userByID == null)
            {
                throw new Exception("ID nao encontrado no banco de dados para realizar a exclusao de usuario");
            }

            programDBContext.UsersDBContext.Remove(userByID);
            programDBContext.SaveChanges();

            return userByID;
        }
    }
}
