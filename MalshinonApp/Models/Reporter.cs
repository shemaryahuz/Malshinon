using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    internal class Reporter: Person
    {
        public int ReportsCount;
        public Reporter(Person person) : base(person.FirstName, person.LastName, person.SecretCode, "reporter") { }
    }
}
