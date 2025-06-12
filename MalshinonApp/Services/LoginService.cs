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
            Random random = new Random();
            StringBuilder code = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                char letter = (char)random.Next('A', 'Z' + 1);
                code.Append(letter);
            }
            for (int i = 0; i < 4; i++)
            {
                int number = random.Next(0, 10);
                code.Append(number);
            }
            return code.ToString();
        }
        public string GetNewCode()
        {
            string generatedCode = GenerateCode();
            // Check if code already exists
            bool isExists = _personRepo.CodeIsExists(generatedCode);
            while (isExists)
            {
                generatedCode = GenerateCode();
            }
            return generatedCode;
        }
        public Person CreateUser(string firstName, string lastName)
        {
            string code = GetNewCode();
            string role = "reporter";
            Person user = new Person(firstName, lastName, code, role);
            _personRepo.AddPerson(user);
            return user;
        }
    }
}
