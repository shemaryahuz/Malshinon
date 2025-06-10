using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalshinonApp.Models;
using MySql.Data.MySqlClient;

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
            if(_instance is null)
            {
                _instance = new PersonRepository(database);
            }
            return _instance;
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
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"SQL error: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return person;
        }
        public Person? GetPersonByLastName(string lastName)
        {
            Person person = null;
            try
            {
                string query =
                    $"SELECT * FROM people " +
                    $"WHERE lastName=@lastName;";
                using var command = new MySqlCommand(query, _db.GetConnection());
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
        public int GetPersonIdByLastName(string lastName)
        {
            int personId = 0;
            try
            {
                string query =
                    $"SELECT personId FROM people " +
                    $"WHERE lastName=@lastName;";
                using var command = new MySqlCommand(query, _db.GetConnection());
                command.Parameters.AddWithValue("@lastName", lastName);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    personId = reader.GetInt32("personId");
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
            return personId;
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
    }
}
