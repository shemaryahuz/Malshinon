using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Models
{
    internal class Manager: Person
    {
        public Manager(Person person) : base(person.FirstName, person.LastName, person.SecretCode, "manager") { }
    }
}
