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
        private int userID = 0;
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



        public void setName(string name)
        {
            this.name = name;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getName()
        {
            return this.name;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public int getUserID()
        {
            return this.getUserID();
        }




    }
}