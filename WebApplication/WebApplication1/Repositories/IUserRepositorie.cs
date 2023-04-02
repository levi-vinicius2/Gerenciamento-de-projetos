using System.Threading.Tasks;

namespace User.Repositories
{
    public interface IUserRepositorie
    {
        Task<ModelUser.Models.User> SearchByID(int id);
        Task<List<ModelUser.Models.User>> SearchAllUsers();
        Task<ModelUser.Models.User> Add(ModelUser.Models.User user);
        Task<ModelUser.Models.User> Update(ModelUser.Models.User user);
        Task<ModelUser.Models.User> Delete(ModelUser.Models.User user);
    }
}