﻿using MalshinonApp.Data;
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
            _exit = "0";
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
            Console.WriteLine("This is the information about all the people:");
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
        private void ShowReports()
        {
            List<Report> reports = _service.GetReports();
            Console.WriteLine("This is the information about all the intel reports:");
            foreach (Report report in reports)
            {
                Console.WriteLine(
                    $"Reporter ID: {report.ReporterId}. " +
                    $"Target ID: {report.TargetId}.\n" +
                    $"Text:\n" +
                    $"{report.Text}" +
                    $"Time: {report.Time}"
                    );
            }
        }
        private void ShowPotentialAgents()
        {
            List<Person> potentialAgents = _service.GetPotentialAgents();
            Console.WriteLine(
                "Those are the potential agents:\n" +
                "(People who reported more than 10 reports with text length of more than 100 characters).");
            foreach (Person person in potentialAgents)
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
        private void ShowDangerousTargets()
        {
            List<Person> dangerousTargets = _service.GetDangerousTargets();
            Console.WriteLine(
                "Those are the dangerous targets:\n" +
                "(People who have more than 20 reports about them).");
            foreach (Person person in dangerousTargets)
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
                $"3. Show potential agents (reporters or both - reporter and target, who reported more than 10 reports with average of 100 characters).\n" +
                $"4. Show dangerous targets (targets or both - reporter and target, who have more than 20 reports about them.\n" +
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
                    ShowReports();
                    break;
                case "3":
                    ShowPotentialAgents();
                    break;
                case "4":
                    ShowDangerousTargets();
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
