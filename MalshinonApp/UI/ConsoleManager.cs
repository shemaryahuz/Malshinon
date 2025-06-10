using MalshinonApp.Data;
using MalshinonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalshinonApp.Data;
using MalshinonApp.Models;
using MalshinonApp.Services;

namespace MalshinonApp.UI
{
    internal static class ConsoleManager
    {
        public static void Run()
        {
            // Setup DB connection
            DatabaseContext dbConnection = new DatabaseContext();
            dbConnection.OpenConnection();

            // Welcome
            Console.WriteLine("Welcome to Malshinon!");

            // Get inputs to login
            Console.WriteLine("Enter your First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your Secret Code:");
            string code = Console.ReadLine();

            // Setup login service
            LoginService loginService = LoginService.GetLoginService(dbConnection);

            // Login or create user
            Person user = loginService.LoginOrCreatePerson(firstName, lastName, code, "reporter");
            // Make user a reporter
            Reporter reporter = new Reporter(user);

            // Setup reporter menu (which creates reporter-service obj that creates report-repository obj that uses db)
            ReporterMenu reporterMenu = ReporterMenu.GetReporterMenu(dbConnection);
            reporterMenu.Show(reporter);
            // Close connection
            dbConnection.CloseConnection();
        }
    }
}
