using System.Threading.Tasks;

namespace User.Repositories
{
    public interface IUserRepositorie
    {
        Task<ModelUser.User> SearchByID(int id);
        Task<List<ModelUser.User>> SearchAllUsers();
        Task<ModelUser.User> Add(ModelUser.User user);
        Task<ModelUser.User> Update(ModelUser.User user);
        Task<ModelUser.User> Delete(ModelUser.User user);
    }
}