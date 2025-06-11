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
            Person user = loginDisplayer.Login();
            // Check what is the user's role
            if (user.Role == "reporter")
            {
                // Make user a reporter
                Reporter reporter = new Reporter(user);
                // Setup reporter menu (which creates reporter-service obj that creates report-repository obj that uses db)
                ReporterMenu reporterMenu = ReporterMenu.GetReporterMenu(dbConnection);
                reporterMenu.Show(reporter);
            }
            else if (user.Role == "manager")
            {
                Console.WriteLine("The nanager dashboard is not ready yet.");
            }
            // Close connection
            dbConnection.CloseConnection();
            // Bybye
            Console.WriteLine("Thank you for using Malshinon System! We hope to see you again.");
        }
    }
}
