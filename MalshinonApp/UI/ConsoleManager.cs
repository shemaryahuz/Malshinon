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
            // Welcome
            Console.WriteLine("Welcome to Malshinon System!");
            // Setup DB connection
            DatabaseContext dbConnection = new DatabaseContext();
            dbConnection.OpenConnection();
            // Setup login displayer
            LoginDisplayer loginDisplayer = LoginDisplayer.GetLoginDisplayer(dbConnection);
            // Login or create user
            Person? user = loginDisplayer.LoginOrCreateUser();
            // Check if didn't logged in
            if (user != null)
            {
                // Check what is the user's role
                if (user.Role == "reporter" || user.Role == "both")
                {
                    // Make user a reporter
                    Reporter reporter = new Reporter(user);
                    // Setup reporter menu (which creates reporter-service obj that creates report-repository obj that uses db)
                    ReporterMenu reporterMenu = ReporterMenu.GetReporterMenu(dbConnection);
                    // Show reporter menu
                    reporterMenu.Show(reporter);
                }
                else if (user.Role == "manager")
                {
                    // Make user a manager
                    Manager manager = new Manager(user);
                    // Setup manager menu
                    ManagerMenu managerMenu = ManagerMenu.GetManagerMenu(dbConnection);
                    // Show manger menu
                    managerMenu.Show();
                }
            }
            // Close connection
            dbConnection.CloseConnection();
            // Bybye
            Console.WriteLine("Thank you for using Malshinon System! We hope to see you again.");
        }
    }
}
