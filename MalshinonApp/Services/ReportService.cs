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
        private Person AddIdToPerson(Person person)
        {
            return _personRepo.AddIdToPerson(person);
        }
        private void AddTarget(Target target)
        {
            _personRepo.AddPerson(target);
        }
        private Report CreateReport(int reporterId, int targetId, string text)
        {
            Report report = new Report(reporterId, targetId, text);
            return report;
        }
        public bool Report(Reporter reporter, Target target, string text)
        {
            bool added = false;
            Person reporterWithId = AddIdToPerson(reporter);
            Person tergetWithId = AddIdToPerson(target);
            if (tergetWithId.Id == 0) // means that he dosn't exist in data base
            {
                AddTarget(target);
                tergetWithId = AddIdToPerson(target);
            }
            Report report = CreateReport(reporterWithId.Id, tergetWithId.Id, text);
            added = _reportRepo.AddReport(report);
            return added;
        }
    }
}
