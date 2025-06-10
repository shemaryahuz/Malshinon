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
        public Person Login()
        {
            Person user = null;
            try
            {
                // Get inputs to login
                Console.WriteLine("Enter your First Name:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter your Last Name:");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your Secret Code:");
                string code = Console.ReadLine();
                user = _service.LoginOrCreatePerson(firstName, lastName, code, "reporter");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
