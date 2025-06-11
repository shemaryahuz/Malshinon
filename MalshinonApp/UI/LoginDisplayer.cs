using MalshinonApp.Data;
using MalshinonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalshinonApp.Models;

namespace MalshinonApp.UI
{
    internal class LoginDisplayer
    {
        private LoginService _service;
        private static LoginDisplayer _instance;
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
        private void Welcome(Person person)
        {
            Console.WriteLine($"Welcome {person.FirstName} {person.LastName}!");
            if (_service.IsNew())
            {
                Console.WriteLine(
                    $"Your account has been created successfully.\n" +
                    $"You are a {person.Role} in the Malshinon system.\n" +
                    $"Your Secret code is {person.SecretCode}");
            }
            else
            {
                Console.WriteLine(
                    $"You have successfuly lpgged in.\n" +
                    $"You are a {person.Role} in the Malshinon system.");
            }
        }
        public Person Login()
        {
            string managerCode = "manager1234";
            Person user = null;
            try
            {
                // Get inputs to login
                Console.WriteLine("Enter your first name:");
                string firstName = Console.ReadLine().ToLower();
                Console.WriteLine("Enter your last name:");
                string lastName = Console.ReadLine().ToLower();
                Console.WriteLine("Enter your secret code:");
                string code = Console.ReadLine();
                if (code == managerCode)
                {
                    user = _service.LoginOrCreatePerson(firstName, lastName, code, "manager");
                }
                else
                {
                    user = _service.LoginOrCreatePerson(firstName, lastName, code, "reporter");
                }   
                Welcome(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
