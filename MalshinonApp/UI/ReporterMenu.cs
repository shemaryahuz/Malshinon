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
        private ReportService _service;
        private static ReporterMenu _instanc;
        private ReporterMenu(DatabaseContext database)
        {
            _service = ReportService.GetReportService(database);
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
                $"1. Submit report.\n" +
                $"0. Exit.\n" +
                $"Select:");
            return Console.ReadLine();
        }
        private bool Validate(string choice)
        {
            return choice == "1";
        }
        private string GetText()
        {
            Console.WriteLine("Enter your report's text:");
            string text = Console.ReadLine();
            return text;
        }
        private void SubmitReport(Reporter reporter)
        {
            try
            {
                // Get Target name
                Console.WriteLine("Enter target's first name:");
                string targetFirstName = Console.ReadLine().ToLower();
                Console.WriteLine("Enter target's last name:");
                string targetLastName = Console.ReadLine().ToLower();
                // Get Report text
                string text = GetText();
                bool submited = _service.Report(reporter, targetFirstName, targetLastName, text);
                if (submited)
                {
                    Console.WriteLine("Your report was sended successfuly!");
                }
                else
                {
                    Console.WriteLine("Somthing went wrong.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Show(Reporter reporter)
        {
            string exit = "0";
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
