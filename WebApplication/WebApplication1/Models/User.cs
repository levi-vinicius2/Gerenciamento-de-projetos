using Microsoft.EntityFrameworkCore;
using User.Controllers;

namespace ModelUser.Models
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int UserID { get; set; }
    }
}