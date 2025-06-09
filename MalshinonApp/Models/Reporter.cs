using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    internal class Reporter: Person
    {
        public Reporter(string firstName, string lastName, string secretCode)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SecretCode = secretCode;
        }
    }
}
