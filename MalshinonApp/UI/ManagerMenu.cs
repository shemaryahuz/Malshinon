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
        private ManagerMenu(DatabaseContext database)
        {
            _service = ManagerService.GetManagerService(database);
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
                    $"Person ID: {person.Id}. First name: {person.FirstName}. Last name: {person.LastName}. Secret Cose: {person.SecretCode}.");
            }
        }
        private string ShowOptions()
        {
            Console.WriteLine(
                $"Options:\n" +
                $"1. Show all people.\n" +
                $"2. Show potential agents\n" +
                $"3. Show dangerous targets" +
                $"4. Exit.\n" +
                $"Select:");
            return Console.ReadLine();
        }
        private bool Validate(string choice)
        {
            string[] validated = { "1", "2", "3" };
            return validated.Contains(choice);
        }
        private void ExecuteChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    Console.WriteLine("Not ready yet.");
                    break;
                case "3":
                    Console.WriteLine("Not ready yet.");
                    break;
            }
        }
        public void Show()
        {
            string exit = "4";
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
