using MalshinonApp.Data;
using MalshinonApp.Models;
using MalshinonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.UI
{
    internal class ManagerMenu
    {
        private ManagerService _service;
        private static ManagerMenu _instance;
        private string _exit;
        private ManagerMenu(DatabaseContext database)
        {
            _service = ManagerService.GetManagerService(database);
            _exit = "5";
        } 
        public static ManagerMenu GetManagerMenu(DatabaseContext database)
        {
            if (_instance is null)
            {
                _instance = new ManagerMenu(database);
            }
            return _instance;
        }
        private void ShowPeople()
        {
            List<Person> people = _service.GetPeople();
            foreach (Person person in people)
            {
                Console.WriteLine(
                    $"Person ID: {person.Id}. " +
                    $"Person Role: {person.Role}. " +
                    $"First name: {person.FirstName}. " +
                    $"Last name: {person.LastName}. " +
                    $"Secret Code: {person.SecretCode}."
                    );
            }
        }
        private string ShowOptions()
        {
            Console.WriteLine(
                $"Options:\n" +
                $"0. Exit.\n" +
                $"1. Show all people.\n" +
                $"2. Show all reports.\n" +
                $"3. Show potential agents (reporters or both - reporter and target, that reported more than 10 reports with average of 100 characters).\n" +
                $"4. Show dangerous targets (targets or both - reporter and target, that have more than 20 reports about them.\n" +
                $"Select:"
                );
            return Console.ReadLine();
        }
        private bool Validate(string choice)
        {
            string[] validated = { "1", "2", "3", "4" };
            return validated.Contains(choice);
        }
        private void ExecuteChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    ShowPeople();
                    break;
                case "2":
                    Console.WriteLine("All reports not ready yet.");
                    break;
                case "3":
                    Console.WriteLine("Potential agents not ready yet.");
                    break;
                case "4":
                    Console.WriteLine("Dangerous targets not ready yet.");
                    break;
            }
        }
        public void Show()
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
                    ExecuteChoice(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
