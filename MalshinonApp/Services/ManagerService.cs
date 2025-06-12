using MalshinonApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalshinonApp.Models;

namespace MalshinonApp.Services
{
    // This class is responsible for handling with the system's manager methods
    internal class ManagerService
    {
        private PersonRepository _personRepo;
        private ReportRepository _reportRepo;
        private static ManagerService _instance;
        private ManagerService(DatabaseContext database)
        {
            _personRepo = PersonRepository.GetPersonRepository(database);
            _reportRepo = ReportRepository.GetReportRepository(database);
        }
        public static ManagerService GetManagerService(DatabaseContext database)
        {
            if (_instance is null)
            {
                _instance = new ManagerService(database);
            }
            return _instance;
        }
        public List<Person> GetPeople()
        {
            return _personRepo.GetPeople();
        }
        public List<Report> GetReports()
        {
            return _reportRepo.GetReports();
        }
        public List<Person> GetPotentialAgents()
        {
            return _personRepo.GetPotentialAgents();
        }
        public List<Person> GetDangerousTargets()
        {
            return _personRepo.GetDangerousTargets();
        }
    }
}
