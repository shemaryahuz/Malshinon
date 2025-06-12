using Google.Protobuf.Compiler;
using MalshinonApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonApp.Data
{
    // This class is responsible to handle with the reports table using the database context (to malshinon_db)
    internal class ReportRepository
    {
        private DatabaseContext _db;
        private static ReportRepository _instance;
        private ReportRepository(DatabaseContext database)
        {
            _db = database;
        }
        public static ReportRepository GetReportRepository(DatabaseContext database)
        {
            if (_instance is null)
            {
                _instance = new ReportRepository(database);
            }
            return _instance;
        }
        public bool AddReport(Report report)
        {
            bool added = false;
            try
            {
                string query =
                    "INSERT INTO intel_reports (reporterId, targetId, text) " +
                    "VALUES (@reporterId, @targetId, @text)";
                using var command = new MySqlCommand(query, _db.GetConnection());
                command.Parameters.AddWithValue("@reporterId", report.ReporterId);
                command.Parameters.AddWithValue("@targetId", report.TargetId);
                command.Parameters.AddWithValue("@text", report.Text);
                command.ExecuteNonQuery();
                added = true;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return added;
        }
        public List<Report> GetReports()
        {
            List<Report> reports = new List<Report>();
            try
            {
                string query =
                    $"SELECT * FROM intel_reports";
                using var command = new MySqlCommand(query, _db.GetConnection());
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Report report = new Report(
                            reader.GetInt32("reporterId"),
                            reader.GetInt32("targetId"),
                            reader.GetString("text")
                        );
                    report.Time = reader.GetDateTime("timestamp");
                    reports.Add(report);
                }
                return reports;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return reports;
        }
        public Report? GetReportById()
        {
            return null;
        }
    }
}
