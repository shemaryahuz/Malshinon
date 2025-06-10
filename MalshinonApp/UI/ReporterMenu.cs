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
        private void Welcome(Reporter reporter)
        {
            Console.WriteLine($"Welcome {reporter.FirstName} {reporter.LastName}!");
        }
        private string ShowOptions()
        {
            Console.WriteLine(
                $"Select:\n" +
                $"1. Submit report.\n" +
                $"0. Exit.");
            return Console.ReadLine();
        }
        private bool Validate(string choice)
        {
            return choice == "1";
        }
        private string[] GetTargetName()
        {
            Console.WriteLine("Enter The target's Full Name (space between first name and last name):");
            string[] targetFullName = Console.ReadLine().Split(' ');
            return targetFullName;
        }
        private string GetText()
        {
            Console.WriteLine("Enter your Report's text:");
            string text = Console.ReadLine();
            return text;
        }
        private void Report(Reporter reporter)
        {
            try
            {
                // Get Target name
                string[] targetFullName = GetTargetName();
                string targetFirstName = targetFullName[0];
                string targetLastName = targetFullName[1];
                // Get Report text
                string text = GetText();
                _service.Report(reporter.FirstName, reporter.LastName, targetFirstName, targetLastName, text);
                Console.WriteLine("Your report was sended successfuly!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Show(Reporter reporter)
        {
            Welcome(reporter);
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
                    Report(reporter);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
