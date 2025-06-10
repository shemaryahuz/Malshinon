using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    // This class represents a person in the malshinon system
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecretCode { get; set; }
        public string Role { get; set; } // "reporter", "manager", etc.
        public int ReportsCount { get; set; }
        public int MantionsCount { get; set; }
        public Person(string firstName, string lastName, string secretCode, string role)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SecretCode = secretCode;
            this.Role = role;
        }
    }
}
