using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    internal class Target: Person
    {
        public int MantionsCount;
        public Target(Person person) : base(person.FirstName, person.LastName, person.SecretCode, "target") { }
    }
}
