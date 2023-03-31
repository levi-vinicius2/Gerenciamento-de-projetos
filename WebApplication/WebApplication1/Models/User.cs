using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelProject.Models;
using ModelTask.Models;

namespace ModelUser.Models
{
    public class User
    {
        public string name;
        public string email;
        private string password;
        private readonly int userID = 0;
        private static int nextUserID = 0;
        public List<Project>? associatedProjects;

        public User()
        {
            this.name = "First user";
            this.email = "levi.vinicius@outlook.com";
            this.password = "123456";
        }

        public User(string userName, string userMail, string userPassword)
        {
            this.name = userName;
            this.email = userMail;
            this.password = userPassword;
            this.userID = nextUserID++;
        }

        public void SetName(string name) { this.name = name; }

        public string GetPassword() { return this.password; }

        public string GetName() { return this.name; }

        public void SetEmail(string email) { this.email = email; }

        public string GetEmail() { return this.email; }

        public void SetPassword(string password) { this.password = password; }

        public int GetUserID() { return this.GetUserID(); }
    }
}