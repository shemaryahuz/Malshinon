using MalshinonApp.Data;
using MalshinonApp.Models;
using MalshinonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MalshinonApp.UI
{
    internal class LoginDisplayer
    {
        private LoginService _service;
        private static LoginDisplayer _instance;
        private string _exit = "0";
        private LoginDisplayer(DatabaseContext database)
        {
            _service = LoginService.GetLoginService(database);
        }
        public static LoginDisplayer GetLoginDisplayer(DatabaseContext database)
        {
            if (_instance is null)
            {
                _instance = new LoginDisplayer(database);
            }
            return _instance;
        }
        private bool Login(Person user)
        {
            bool isCorrect = false;
            string exit = _exit;
            Console.WriteLine(
                $"Welcome! you are in the system.\n" +
                $"Enter your secret code (Enter '{_exit}' to exit):");
            while (!isCorrect)
            {
                string code = Console.ReadLine();
                if (code == exit)
                {
                    return isCorrect;
                }
                else if (user.SecretCode == code)
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Wrong code! try again:");
                }
            }
            return isCorrect;
        }
        public Person? LoginOrCreateUser()
        {
            Person? user = null;
            Console.WriteLine($"Login or create user (at any step of input enter '{_exit}' to exit):");
            string exit = _exit;
            bool toExit = false;
            while (!toExit)
            {
                Console.WriteLine(
                    "Enter your info\n" +
                    "(if you will put wrong name it will generate new user, so if you are doing a mistake, enter '0' and login again).");
                Console.WriteLine("Enter your first name:");
                // Get full name
                string firstName = Console.ReadLine();
                if (firstName == exit)
                {
                    toExit = true;
                    continue;
                }
                Console.WriteLine("Enter your last name:");
                string lastName = Console.ReadLine();
                if (lastName == exit)
                {
                    toExit = true;
                    continue;
                }
                // Check if user exists
                user = _service.CheckIfExists(firstName, lastName);
                // if he doesn't exists create and show secret code
                if (user is null)
                {
                    user = _service.CreateUser(firstName, lastName);
                    Console.WriteLine($"You have created user account. Your Secret code is: {user.SecretCode}");
                    toExit = true;
                }
                // if he is only target updated role to both
                else if (user.Role == "target")
                {
                    user.Role = "both";
                    Console.WriteLine($"You have became a reporter. Your Secret code is: {user.SecretCode}");
                    toExit = true;
                }
                else
                {
                    bool loggedIn = Login(user);
                    if (!loggedIn)
                    {
                        user = null;
                    }
                    toExit = true;
                }
            }
            return user;
        }
    }
}
