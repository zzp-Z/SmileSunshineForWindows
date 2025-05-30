using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class RoleFunc
    {
        private readonly Engine _dbEngine;

        public RoleFunc(Engine dbEngine)
        {
            _dbEngine = dbEngine;
        }

        /**
         * Create a new role
         */
        public bool CreateRole(Role role)
        {
            string query = "INSERT INTO role (role_name, description, department_id, created_at, updated_at) VALUES (@RoleName, @Description, @DepartmentId, @CreatedAt, @UpdatedAt)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                    cmd.Parameters.AddWithValue("@Description", role.Description);
                    cmd.Parameters.AddWithValue("@DepartmentId", role.DepartmentId);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating role: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a role by ID
        public Role GetRoleById(int id)
        {
            string query = "SELECT id, role_name, description,department_id, created_at, updated_at FROM role WHERE id = @Id";
            Role role = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        role = new Role
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            RoleName = dataReader["role_name"].ToString(),
                            DepartmentId = Convert.ToInt32(dataReader["department_id"]),
                            Description = dataReader["description"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["created_at"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updated_at"])
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting role by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return role;
        }

        // Read all roles
        public List<Role> GetAllRoles()
        {
            string query = "SELECT id, role_name, description, department_id, created_at, updated_at FROM role";
            List<Role> roles = new List<Role>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        roles.Add(new Role
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            RoleName = dataReader["role_name"].ToString(),
                            DepartmentId = Convert.ToInt32(dataReader["department_id"]),
                            Description = dataReader["description"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["created_at"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updated_at"])
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all roles: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return roles;
        }

        // Update an existing role
        public bool UpdateRole(Role role)
        {
            string query = "UPDATE role SET role_name = @RoleName, description = @Description,department_id = @DepartmentId, updated_at = @UpdatedAt WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                    cmd.Parameters.AddWithValue("@Description", role.Description);
                    cmd.Parameters.AddWithValue("@DepartmentId", role.DepartmentId);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Id", role.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating role: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a role by ID
        public bool DeleteRole(int id)
        {
            string query = "DELETE FROM role WHERE id = @Id";
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
                    Console.WriteLine($"Error deleting role: {ex.Message}");
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