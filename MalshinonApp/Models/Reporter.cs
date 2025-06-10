using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    internal class Reporter: Person
    {
        public Reporter(string firstName, string lastName, string secretCode) : base( firstName, lastName, secretCode, "reporter") { }
    }
}
