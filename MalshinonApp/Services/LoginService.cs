using MalshinonApp.Data;
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
        private PersonRepository _personRepo;
        private static LoginService _instance;
        private bool _isNew;
        private LoginService(DatabaseContext database)
        {
            _personRepo = PersonRepository.GetPersonRepository(database);
            _isNew = false;
        }
        public static LoginService GetLoginService(DatabaseContext database)
        {
           if (_instance is null)
           {
                _instance = new LoginService(database);
           }
           return _instance;
        }
        public bool IsNew()
        {
            return _isNew;
        }
        public Person LoginOrCreatePerson(string firstName, string lastName, string secretCode, string role)
        {
            Person person = _personRepo.GetPersonByCode(secretCode);
            if (person is null)
            {
                person = new Person(firstName, lastName, secretCode, role);
                _personRepo.AddPerson(person);
                _isNew = true;
            }
            return person;
        }
    }
}
