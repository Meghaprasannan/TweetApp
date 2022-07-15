using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.DAOLayer;
using test.DAOLayer.Entities;

namespace test.ServiceLayer
{
    public class Login
    {
        public bool VerifyUser(string UserId, string pw)
        {
            var db = new TweetDbContext();
            var user = db.Users.FirstOrDefault(u => u.Email == UserId);
            if(user is null)
            {
                Console.WriteLine("User not found");
                return false;
            }
            else if(user.Password != pw)
            {
                Console.WriteLine("Invalid Password !!!");
                return false;
            }
            var userdetails = new UserLogin();
            userdetails.UserId = UserId;
            userdetails.LoginTime = DateTime.Now;
            db.LoginDetails.Add(userdetails);
            db.SaveChanges();
            Console.WriteLine("Login succesful!!");
            return true;
        }
    }
}
