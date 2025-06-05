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
        public User CreateUser(User user)
        {
            string query = "INSERT INTO user (username, password, email,gender, phone, created_at, updated_at) VALUES (@Username, @Password, @Email,@Gender, @Phone, @CreatedAt, @UpdatedAt)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password); // TODO: Remember to hash passwords
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    // 获取新插入的ID
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    cmd.Parameters.Clear();
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    user.Id = newId;
                    return user;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating user: {ex.Message}");
                    return null;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return null;
        }

        // Read a user by ID
        public User GetUserById(int id)
        {
            string query = "SELECT id, username, password, email,gender, phone, created_at, updated_at FROM user WHERE id = @Id";
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
                            Gender = dataReader["gender"].ToString(),
                            Phone = dataReader["phone"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["created_at"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updated_at"])
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
            string query = "SELECT id, username, password, email,gender, phone, created_at, updated_at FROM user";
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
                            Gender = dataReader["gender"].ToString(),
                            Phone = dataReader["phone"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["created_at"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updated_at"])
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
            string query = "UPDATE user SET username = @Username, password = @Password, email = @Email, gender = @Gender, phone = @Phone, updated_at = @UpdatedAt WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password); // Remember to hash if it's a new password
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
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
        
        // Get employees by department ID
        public List<User> GetEmployeesByDepartmentId(int departmentId)
        {
            string query = @"SELECT u.id, u.username, u.email,u.gender, u.phone,u.password,u.created_at, u.updated_at, r.role_name, r.id as role_id
                            FROM user u
                            JOIN user_role ur ON u.id = ur.user_id
                            JOIN role r ON ur.role_id = r.id
                            WHERE r.department_id = @DepartmentId";
            
            List<User> users = new List<User>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        // 使用动态对象存储员工信息
                        var user = new User()
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Username = dataReader["username"].ToString(),
                            Password = dataReader["password"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Gender = dataReader["gender"].ToString(),
                            Phone = dataReader["phone"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["created_at"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updated_at"]),
                        };
                        
                        users.Add(user);
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting employees by department: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return users;
        }


    }
}