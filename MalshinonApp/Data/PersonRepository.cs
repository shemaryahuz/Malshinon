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
    // This class is responsible to handle with the people table using the database context (to malshinon_db)
    internal class PersonRepository
    {
        private DatabaseContext _db;
        private static PersonRepository _instance;
        private PersonRepository(DatabaseContext database)
        {
            _db = database;
        }
        public static PersonRepository GetPersonRepository(DatabaseContext database)
        {
            if (_instance is null)
            {
                _instance = new PersonRepository(database);
            }
            return _instance;
        }
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            try
            {
                string query =
                    $"SELECT * FROM people";
                using var command = new MySqlCommand(query, _db.GetConnection());
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person(
                            reader.GetString("firstName"),
                            reader.GetString("lastName"),
                            reader.GetString("secretCode"),
                            reader.GetString("role")
                        );
                    person.Id = reader.GetInt32("id");
                    people.Add(person);
                }
                return people;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return people;
        }
        public Person? GetPersonByName(string firstName, string lastName)
        {
            Person person = null;
            try
            {
                string query =
                    $"SELECT * FROM people " +
                    $"WHERE firstName=@firstName AND lastName=@lastName;";
                using var command = new MySqlCommand(query, _db.GetConnection());
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    person = new Person
                    (
                        reader.GetString("firstName"),
                        reader.GetString("lastName"),
                        reader.GetString("secretCode"),
                        reader.GetString("role")
                    );
                }
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return person;
        }
        public Person? GetPersonByCode(string code)
        {
            Person person = null;
            try
            {
                string query =
                    $"SELECT * FROM people " +
                    $"WHERE secretCode=@secretCode;";
                using var command = new MySqlCommand(query, _db.GetConnection());
                command.Parameters.AddWithValue("@secretCode", code);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    person = new Person
                    (
                        reader.GetString("firstName"),
                        reader.GetString("lastName"),
                        reader.GetString("secretCode"),
                        reader.GetString("role")
                    );
                }
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return person;
        }
        public Person? AddIdToPerson(Person person)
        {
            try
            {
                string query =
                    $"SELECT * FROM people " +
                    $"WHERE lastName=@lastName;";
                using var command = new MySqlCommand(query, _db.GetConnection());
                command.Parameters.AddWithValue("@lastName", person.LastName);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    person.Id = reader.GetInt32("id");
                }
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return person;
        }
        public void AddPerson(Person person)
        {
            try
            {
                string query =
                    "INSERT INTO people (firstName, lastName, secretCode, role) " +
                    "VALUES (@firstName, @lastName, @secretCode, @role)";
                using var command = new MySqlCommand(query, _db.GetConnection());
                command.Parameters.AddWithValue("@firstName", person.FirstName);
                command.Parameters.AddWithValue("@lastName", person.LastName);
                command.Parameters.AddWithValue("@secretCode", person.SecretCode);
                command.Parameters.AddWithValue("@role", person.Role);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public bool CodeIsExists(string code)
        {
            bool isExists = false;
            try
            {
                string query =
                    $"SELECT secretCode FROM people " +
                    $"WHERE secretCode=@secretCode;";
                using var command = new MySqlCommand(query, _db.GetConnection());
                command.Parameters.AddWithValue("@secretCode", code);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isExists = true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return isExists;
        }
        public List<Person> GetPotentialAgents()
        {
            List<Person> potentialAgents = new List<Person>();
            try
            {
                string query =
                    $"SELECT p.*  " +
                    $"FROM people p " +
                    $"INNER JOIN (" +
                    $"SELECT reporterId " +
                    $"FROM intel_reports " +
                    $"GROUP BY reporterId " +
                    $"HAVING COUNT(*) > 10 " +
                    $"AND AVG(LENGTH(text)) > 100 " +
                    $") r ON p.id = reporterId";
                using var command = new MySqlCommand(query, _db.GetConnection());
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person(
                            reader.GetString("firstName"),
                            reader.GetString("lastName"),
                            reader.GetString("secretCode"),
                            reader.GetString("role")
                        );
                    person.Id = reader.GetInt32("id");
                    potentialAgents.Add(person);
                }
                return potentialAgents;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return potentialAgents;
        }
        public List<Person> GetDangerousTargets()
        {
            List<Person> dangerousTargets = new List<Person>();
            try
            {
                string query =
                    $"SELECT * FROM people " +
                    $"WHERE mantionsCount > 20";
                using var command = new MySqlCommand(query, _db.GetConnection());
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person(
                            reader.GetString("firstName"),
                            reader.GetString("lastName"),
                            reader.GetString("secretCode"),
                            reader.GetString("role")
                        );
                    person.Id = reader.GetInt32("id");
                    dangerousTargets.Add(person);
                }
                return dangerousTargets;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return dangerousTargets;
        }
    }
}
