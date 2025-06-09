using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MalshinonApp.Data
{
    // This class is responsible for management of SQL connection
    internal class DatabaseContext
    {
        private string _connectionString;
        private MySqlConnection _connection;
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new MySqlConnection(_connectionString);
        }
        public MySqlConnection GetConnection()
        {
            return _connection;
        }
        public void OpenConnection()
        {
            _connection.Open();
        }
        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
