using MalshinonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Services
{
    // This class is responsible for login to the system as reporter or manager
    internal class LoginService
    {
        public Reporter Login(string firstName, string lastName, string secretCode)
        {
            return new Reporter(firstName, lastName, secretCode);
        }
    }
}
