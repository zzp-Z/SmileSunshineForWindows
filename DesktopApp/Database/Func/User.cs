using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class UserFunc
    {
        private readonly Engine _dbEngine;

        public UserFunc(Engine dbEngine)
        {
            _dbEngine = dbEngine;
        }

        /**
         * Create a new user
         */
        public bool CreateUser(User user)
        {
            string query = "INSERT INTO user (username, password, email, phone, created_at, updated_at) VALUES (@Username, @Password, @Email, @Phone, @CreatedAt, @UpdatedAt)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password); // TODO: Remember to hash passwords
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating user: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a user by ID
        public User GetUserById(int id)
        {
            string query = "SELECT id, username, password, email, phone, created_at, updated_at FROM user WHERE id = @Id";
            User user = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        user = new User
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Username = dataReader["username"].ToString(),
                            Password = dataReader["password"].ToString(), // Be cautious with returning hashed passwords
                            Email = dataReader["email"].ToString(),
                            Phone = dataReader["phone"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["createdAt"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updatedAt"])
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting user by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return user;
        }

        // Read all users
        public List<User> GetAllUsers()
        {
            string query = "SELECT id, username, password, email, phone, created_at, updated_at FROM user";
            List<User> users = new List<User>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        users.Add(new User
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Username = dataReader["username"].ToString(),
                            Password = dataReader["password"].ToString(), // Be cautious
                            Email = dataReader["email"].ToString(),
                            Phone = dataReader["phone"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["createdAt"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updatedAt"])
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all users: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return users;
        }

        // Update an existing user
        public bool UpdateUser(User user)
        {
            string query = "UPDATE user SET username = @Username, password = @Password, email = @Email, phone = @Phone, updated_at = @UpdatedAt WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password); // Remember to hash if it's a new password
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating user: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a user by ID
        public bool DeleteUser(int id)
        {
            string query = "DELETE FROM user WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error deleting user: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }
        
        // Validate user credentials
        public bool ValidateUser(string username, string password)
        {
            string query = "SELECT COUNT(1) FROM user WHERE username = @Username AND password = @Password";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    return result != null && Convert.ToInt32(result) > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error validating user: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }
    }
}