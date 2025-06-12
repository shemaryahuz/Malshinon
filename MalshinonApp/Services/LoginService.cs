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
        public bool IsExist { get; set; }
        public string ManagerSecretCode { get; set; }
        private LoginService(DatabaseContext database)
        {
            _personRepo = PersonRepository.GetPersonRepository(database);
            ManagerSecretCode = "ALPHA001";
        }
        public static LoginService GetLoginService(DatabaseContext database)
        {
           if (_instance is null)
           {
                _instance = new LoginService(database);
           }
           return _instance;
        }
        public Person? CheckIfExists(string firstName, string lastName)
        {
            return _personRepo.GetPersonByName(firstName, lastName);
        }
        private string GenerateCode()
        {
            return "";
        }
        public Person CreateUser(string firstName, string lastName)
        {
            string code = GenerateCode();
            string role = "reporter";
            Person user = new Person(firstName, lastName, code, role);
            _personRepo.AddPerson(user);
            return user;
        }
        public Person LoginOrCreatePerson(string firstName, string lastName, string secretCode, string role)
        {
            Person person = _personRepo.GetPersonByCode(secretCode);
            if (person is null)
            {
                person = new Person(firstName, lastName, secretCode, role);
                _personRepo.AddPerson(person);
                IsExist = false;
            }
            return person;
        }
    }
}
