using MalshinonApp.Data;
using MalshinonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Services
{
    // This class is responsible for handling with methods of reports
    internal class ReportService
    {
        private ReportRepository _reportRepo;
        private PersonRepository _personRepo;
        private static ReportService _instance;
        private ReportService(DatabaseContext database)
        {
            _reportRepo = ReportRepository.GetReportRepository(database);
            _personRepo = PersonRepository.GetPersonRepository(database);
        }
        public static ReportService GetReportService(DatabaseContext database)
        {
            if (_instance is null)
            {
                _instance = new ReportService(database);
            }
            return _instance;
        }
        private Person? GetPerson(string LastName)
        {
            return _personRepo.GetPersonByLastName(LastName);
        }
        private int GetPersonId(string LastName)
        {
            return _personRepo.GetPersonIdByLastName(LastName);
        }
        private Report CreateReport(int reporterId, int targetId, string text)
        {
            Report report = new Report(reporterId, targetId, text);
            return report;
        }
        private void AddReport(Report report)
        {
            _reportRepo.AddReport(report);
        }
        public void Report(string reporterFirstName, string reporterLastName, string targetFirstName, string targetLastName, string text)
        {
            Reporter reporter = new Reporter(GetPerson(reporterLastName));
            Target target = new Target(GetPerson(targetLastName));
            if (target is null)
            {
                target = new Target(new Person(reporterFirstName, reporterLastName, "", "target")); // to add creation of secret code
                _personRepo.AddPerson(target);
                target = new Target(GetPerson(targetLastName));
            }
            int reporterId = GetPersonId(reporterLastName);
            int targetId = GetPersonId(targetLastName);
            Report report = CreateReport(reporterId, targetId, text);
            AddReport(report);
        }
    }
}
