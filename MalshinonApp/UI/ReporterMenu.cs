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
        public ReporterMenu(DatabaseContext database)
        {
            _service = new ReportService(database);
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
        private void Report()
        {

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
                    Report();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
