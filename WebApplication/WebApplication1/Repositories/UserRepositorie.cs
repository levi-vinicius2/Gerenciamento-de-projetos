using projectManeger.Data;
using Microsoft.EntityFrameworkCore;
using ModelUser.Models;

namespace User.Repositories
{
    public class UserRepositorie
    {
        private readonly ProjectManeger? programDBContext;

        public UserRepositorie(ProjectManeger? programDBContext) { this.programDBContext = programDBContext; }

        public async Task<ModelUser.Models.User> SearchByID(int id)
        { return await programDBContext.Users.FirstOrDefaultAsync(x => x.GetUserID().Equals(id)); }

        public async Task<List<ModelUser.Models.User>> SearchAllUsers()
        { return await programDBContext.Users.ToListAsync(); }

        public async Task<ModelUser.Models.User> Add(ModelUser.Models.User user)
        {
            programDBContext.Users.AddAsync(user);
            programDBContext.SaveChanges();
            return user;
        }

        public async Task<ModelUser.Models.User> Update(ModelUser.Models.User user, int id)
        {
            ModelUser.Models.User userByID = await SearchByID(id);
            if(userByID == null)
            {
                throw new Exception("ID nao encontrado no banco de dados");
            }

            userByID.SetName(user.GetName());
            userByID.SetEmail(user.GetEmail());
            userByID.SetPassword(user.GetPassword());

            programDBContext.Users.Update(userByID);
            programDBContext.SaveChanges();

            return userByID;
        }

        public async Task<ModelUser.Models.User> Delete(ModelUser.Models.User user, int id)
        {
            ModelUser.Models.User userByID = await SearchByID(id);
            if(userByID == null)
            {
                throw new Exception("ID nao encontrado no banco de dados para realizar a exclusao de usuario");
            }

            userByID.SetEmail(user.GetEmail());
            userByID.SetName(user.GetName());
            userByID.SetPassword(user.GetPassword());

            programDBContext.Users.Remove(userByID);
            programDBContext.SaveChanges();

            return userByID;
        }
    }
}
