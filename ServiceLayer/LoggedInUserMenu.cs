using System;
using System.Collections.Generic;
using System.Linq;
using test.DAOLayer;
using test.DAOLayer.Entities;

namespace test.ServiceLayer
{
    public class LoggedInUserMenu
    {
        bool flag = true;

        TweetDbContext db = new TweetDbContext();
        public void DisplayMenu(string userId)
        {

            while (flag)
            {
                Console.WriteLine("Choose an Option \n 1.Post a tweet \n 2.View my tweets \n 3.View all tweets \n 4.Search tweets from users \n 5. Reset Password \n 6.Logout \n 7.Delete all Tweets");

                var option = Console.ReadLine();
                if (option == "6")
                {
                    var user = db.LoginDetails.OrderByDescending(u => u.LoginTime).FirstOrDefault(u => u.UserId == userId);
                    user.LogoutTime = DateTime.Now;
                    db.LoginDetails.Update(user);
                    db.SaveChanges();
                    Console.WriteLine("Logging out");
                    flag = false;
                }
                if (option == "1")
                {
                    var tweet = new Tweet();
                    tweet.UserId = userId;
                    Console.WriteLine("Enter the Tweet Message : ");
                    tweet.Body = Console.ReadLine();
                    tweet.postedDate = DateTime.Now;
                    try
                    {
                        db.Tweets.Add(tweet);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    continue;
                }
                if (option == "2")
                {
                    var userPosts = db.Tweets.Where(u => u.UserId == userId);
                    if (userPosts.Count() == 0)
                    {
                        Console.WriteLine("User has No Posts");
                        continue;
                    }
                    foreach (var item in userPosts)
                    {
                        Console.WriteLine($"{item.UserId} posted {item.Body} on {item.postedDate} \n");
                    }
                }
                if (option == "3")
                {
                    var userPosts = db.Tweets.ToList<Tweet>();
                    foreach (var item in userPosts)
                    {
                        Console.WriteLine($"{item.UserId} posted {item.Body} on {item.postedDate} \n");
                    }
                    continue;
                }
                if (option == "4")
                {
                    Console.WriteLine("Please enter User ID");
                    var uid = Console.ReadLine();
                    var userPosts = db.Tweets.Where(u => u.UserId == uid);
                    var userDetails = db.Users.FirstOrDefault(u => u.Email == uid);
                    if (userDetails is null)
                    {
                        Console.WriteLine("No User Found!!!");
                    }
                    if (userPosts.Count() == 0)
                    {
                        Console.WriteLine("User has No Posts");
                        continue;
                    }
                    foreach (var item in userPosts)
                    {
                        Console.WriteLine($"{item.UserId} posted {item.Body} on {item.postedDate} \n");
                    }
                    continue;
                }
                if (option == "5")
                {
                    var user = db.Users.FirstOrDefault(u => u.Email == userId);
                    Console.WriteLine("Please enter your Old Password");
                    var oldpassword = Console.ReadLine();
                    if (oldpassword == user.Password)
                    {
                        try
                        {
                            Console.WriteLine("Enter your new password");
                            user.Password = Console.ReadLine();
                            db.Update(user);
                            db.SaveChanges();
                            Console.WriteLine("Password updated successfully");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }

    }
}
