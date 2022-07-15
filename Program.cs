using System;
using test.ServiceLayer;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("TWEET APP\nChoose an Option :  \n  1.User Registration \n  2.Login  \n  3.Forgot Password");
                var option = Console.ReadLine();
                if (option == "1")
                {
                    var userReg = new UserReg();
                    userReg.UserRegistration();
                }
                else if(option=="2")
                {
                    var uId = "";
                    var password = "";
                    Console.WriteLine("Enter Email id / UserId");
                    uId = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    password = Console.ReadLine();
                    var login = new Login();
                    if(!login.VerifyUser(uId, password))
                    {
                        continue;
                    }
                    else
                    {
                        var userMenu = new LoggedInUserMenu();
                        userMenu.DisplayMenu(uId);
                    }
                    
                }
                else if(option == "3"){
                    var forgotPass = new ForgotPassword();
                    Console.WriteLine("Enter User Id");
                    var uid = Console.ReadLine();
                    forgotPass.passwordChange(uid);
                }
                else
                {
                    continue;
                }
            }
            
        }
    }
}
