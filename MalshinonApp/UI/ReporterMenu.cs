using MalshinonApp.Data;
using MalshinonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.UI
{
    // This class is responsible for the reporter's menu
    internal static class ReporterMenu
    {
        private static void Welcome(Reporter reporter)
        {
            Console.WriteLine($"Welcome {reporter.FirstName} {reporter.LastName}!");
        }
        private static string ShowOptions()
        {
            Console.WriteLine(
                $"Select:\n" +
                $"1. Submit report.\n" +
                $"0. Exit.");
            return Console.ReadLine();
        }
        private static void ExecuteQuery()
        {

        }
        public static void Show(Reporter reporter)
        {
            Welcome(reporter);
            string exit = "0";
            bool toExit = false;
            while (!toExit)
            {
                string selection = ShowOptions();

            }
        }
    }
}
