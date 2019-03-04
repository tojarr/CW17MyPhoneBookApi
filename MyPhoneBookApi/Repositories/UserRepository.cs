using MyPhoneBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhoneBookApi.Repositories
{
    public class UserRepository
    {
        private List<User> userList = new List<User>
        {
            new User
            {
                Login = "garry",
                Password = "potter"
            },
            new User
            {
                Login = "lady",
                Password = "fox"
            }
        };

        public User Get(string login, string password)
        {
            User user = userList.SingleOrDefault(u => u.Login == login && u.Password == password);
            return user;
        }
    }
}