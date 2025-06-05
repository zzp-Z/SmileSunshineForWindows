using MySql.Data.MySqlClient;
using System;

namespace DesktopApp.Database
{
    public class Engine
    {
        private MySqlConnection _connection;
        private string _server;
        private string _port;
        private string _database;
        private string _uid;
        private string _password;

        // Constructor
        public Engine()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            _server = "localhost";
            _port = "3306";
            _database = "smile_sunshine";
            _uid = "root";
            _password = "";
            var connectionString = "SERVER=" + _server + ";" +
                                   "PORT=" + _port + ";" +
                                   "DATABASE=" + _database + ";" +
                                   "UID=" + _uid + ";" +
                                   "PASSWORD=" + _password + ";";

            _connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Cannot open connection: {ex.Message}");
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Cannot close connection: {ex.Message}");
                return false;
            }
        }
        
        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}