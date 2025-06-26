using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class RoleFunc
    {
        private readonly Engine _dbEngine = Engine.Instance;

        public RoleFunc()
        {
            
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

        // Read roles by department ID
        public List<Role> GetRolesByDepartmentId(int departmentId)
        {
            string query = "SELECT id, role_name, description, department_id, created_at, updated_at FROM role WHERE department_id = @DepartmentId";
            List<Role> roles = new List<Role>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
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
                    Console.WriteLine($"Error getting roles by department ID: {ex.Message}");
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

        // Get permissions assigned to a role
        public List<int> GetRolePermissions(int roleId)
        {
            string query = "SELECT permission_id FROM role_permission WHERE role_id = @RoleId";
            List<int> permissionIds = new List<int>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        permissionIds.Add(Convert.ToInt32(dataReader["permission_id"]));
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting role permissions: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return permissionIds;
        }

        // Assign permissions to a role
        public bool AssignPermissionsToRole(int roleId, List<int> permissionIds)
        {
            if (_dbEngine.OpenConnection())
            {
                MySqlTransaction transaction = _dbEngine.GetConnection().BeginTransaction();
                try
                {
                    // First, remove all existing permissions for this role
                    string deleteQuery = "DELETE FROM role_permission WHERE role_id = @RoleId";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, _dbEngine.GetConnection(), transaction);
                    deleteCmd.Parameters.AddWithValue("@RoleId", roleId);
                    deleteCmd.ExecuteNonQuery();

                    // Then, insert new permissions
                    if (permissionIds.Count > 0)
                    {
                        string insertQuery = "INSERT INTO role_permission (role_id, permission_id) VALUES (@RoleId, @PermissionId)";
                        foreach (int permissionId in permissionIds)
                        {
                            MySqlCommand insertCmd = new MySqlCommand(insertQuery, _dbEngine.GetConnection(), transaction);
                            insertCmd.Parameters.AddWithValue("@RoleId", roleId);
                            insertCmd.Parameters.AddWithValue("@PermissionId", permissionId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (MySqlException ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error assigning permissions to role: {ex.Message}");
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