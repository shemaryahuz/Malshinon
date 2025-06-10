using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    internal class Target: Person
    {
        public Target(string firstName, string lastName, string secretCode) : base(firstName, lastName, secretCode, "target") { }
    }
}
