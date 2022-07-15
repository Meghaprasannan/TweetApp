using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.DAOLayer;

namespace test.ServiceLayer
{
    public class ForgotPassword
    {
        public void passwordChange(string uid)
        {
            var db = new TweetDbContext();
            var user = db.Users.FirstOrDefault(u => u.Email == uid);
            if (user != null)
            {
                Console.WriteLine(user.securityQuestion);
                var ans = Console.ReadLine();
                if (ans == user.Answer)
                {
                    Console.WriteLine("Enter new password");
                    user.Password = Console.ReadLine();
                    try
                    {
                        db.Users.Update(user);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid answer for security question");

                }
            }
            else
            {
                Console.WriteLine("User Not Found, Please try again with valid userID");
            }
            }

        }
}
