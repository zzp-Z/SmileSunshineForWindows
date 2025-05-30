using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class DepartmentFunc
    {
        private readonly Engine _dbEngine;

        public DepartmentFunc(Engine dbEngine)
        {
            _dbEngine = dbEngine;
        }

        /**
         * Create a new department
         */
        public bool CreateDepartment(Department department)
        {
            string query = "INSERT INTO department (name, description, created_at, updated_at) VALUES (@Name, @Description, @CreatedAt, @UpdatedAt)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", department.Name);
                    cmd.Parameters.AddWithValue("@Description", department.Description);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating department: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a department by ID
        public Department GetDepartmentById(int id)
        {
            string query = "SELECT id, name, description, created_at, updated_at FROM department WHERE id = @Id";
            Department department = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        department = new Department
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Description = dataReader["description"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["created_at"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updated_at"])
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting department by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return department;
        }

        // Read all departments
        public List<Department> GetAllDepartments()
        {
            string query = "SELECT id, name, description, created_at, updated_at FROM department";
            List<Department> departments = new List<Department>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        departments.Add(new Department
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Description = dataReader["description"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["created_at"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updated_at"])
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all departments: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return departments;
        }

        // Update an existing department
        public bool UpdateDepartment(Department department)
        {
            string query = "UPDATE department SET name = @Name, description = @Description, updated_at = @UpdatedAt WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", department.Name);
                    cmd.Parameters.AddWithValue("@Description", department.Description);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Id", department.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating department: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a department by ID
        public bool DeleteDepartment(int id)
        {
            string query = "DELETE FROM department WHERE id = @Id";
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
                    Console.WriteLine($"Error deleting department: {ex.Message}");
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