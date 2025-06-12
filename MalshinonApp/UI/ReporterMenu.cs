using MalshinonApp.Data;
using MalshinonApp.Models;
using MalshinonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.UI
{
    // This class is responsible for the reporter's menu
    internal class ReporterMenu
    {
        private ReportService _reportService;
        private LoginService _loginService;
        private static ReporterMenu _instanc;
        private string _exit;
        private ReporterMenu(DatabaseContext database)
        {
            _reportService = ReportService.GetReportService(database);
            _loginService = LoginService.GetLoginService();
            _exit = "0";
        }
        public static ReporterMenu GetReporterMenu(DatabaseContext database)
        {
            if (_instanc is null)
            {
                _instanc = new ReporterMenu(database);
            }
            return _instanc;
        }
        private string ShowOptions()
        {
            Console.WriteLine(
                $"Options:\n" +
                $"0. Exit.\n" +
                $"1. Submit report.\n" +
                $"Select:"
                );
            return Console.ReadLine();
        }
        private bool Validate(string choice)
        {
            return choice == "1";
        }
        private void SubmitReport(Reporter reporter)
        {
            try
            {
                // Get Target name
                Console.WriteLine("Enter target's first name:");
                string targetFirstName = Console.ReadLine();
                Console.WriteLine("Enter target's last name:");
                string targetLastName = Console.ReadLine();
                // Get Report text
                Console.WriteLine("Enter your report's text:");
                string text = Console.ReadLine();
                // Check if exists
                Person? person = _loginService.CheckIfExists(targetFirstName, targetLastName);
                if (person is null)
                {
                    person = new Person(targetFirstName, targetLastName, _loginService.GetNewCode(), "target");
                }
                else if (person.Role == "reporter")
                {
                    person.Role = "both";
                }
                // Create target
                Target target = new Target(person); // to fix secret code
                bool submited = _reportService.Report(reporter, target, text);
                if (submited)
                {
                    Console.WriteLine("Your report was sended successfuly!");
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Show(Reporter reporter)
        {
            string exit = _exit;
            bool toExit = false;
            while (!toExit)
            {
                string choice = ShowOptions();
                if (choice == exit)
                {
                    toExit = true;
                }
                else if (Validate(choice))
                {
                    SubmitReport(reporter);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
