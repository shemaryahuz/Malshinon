using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalshinonApp.Models;
using MySql.Data.MySqlClient;

namespace MalshinonApp.Data
{
    internal class PersonRepository
    {
        private DatabaseContext _db;
        public PersonRepository(DatabaseContext database)
        {
            _db = database;
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
