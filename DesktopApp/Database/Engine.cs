using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DesktopApp.Database
{
    public class Engine : IDisposable
    {
        private static Engine _instance;
        private static readonly object _lock = new object();
        private MySqlConnection _connection;
        private string _server;
        private string _port;
        private string _database;
        private string _uid;
        private string _password;

        // Private constructor for singleton
        private Engine()
        {
            Initialize();
        }

        // Singleton instance property
        public static Engine Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Engine();
                        }
                    }
                }
                return _instance;
            }
        }

        //Initialize values
        private void Initialize()
        {
            _server = "localhost";
            _port = "3307";
            _database = "smile_sunshine";
            _uid = "root";
            _password = "123123";
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

        // Static method to get database connection directly
        public static MySqlConnection GetDatabaseConnection()
        {
            return Instance.GetConnection();
        }

        // Static method to open connection
        public static bool OpenDatabaseConnection()
        {
            return Instance.OpenConnection();
        }

        // Static method to close connection
        public static bool CloseDatabaseConnection()
        {
            return Instance.CloseConnection();
        }

        // Dispose method for proper resource cleanup
        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.Dispose();
                _connection = null;
            }
        }

        // Static method to dispose the singleton instance
        public static void DisposeInstance()
        {
            lock (_lock)
            {
                if (_instance != null)
                {
                    _instance.Dispose();
                    _instance = null;
                }
            }
        }
    }
}