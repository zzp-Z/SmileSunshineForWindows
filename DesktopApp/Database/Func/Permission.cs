using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class PermissionFunc
    {
        private readonly Engine _dbEngine;

        public PermissionFunc(Engine dbEngine)
        {
            _dbEngine = dbEngine;
        }

        /**
         * Create a new permission
         */
        public bool CreatePermission(Permission permission)
        {
            string query = "INSERT INTO permission (permission_name, api_path, description, created_at, updated_at) VALUES (@PermissionName, @ApiPath, @Description, @CreatedAt, @UpdatedAt)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@PermissionName", permission.PermissionName);
                    cmd.Parameters.AddWithValue("@ApiPath", permission.ApiPath);
                    cmd.Parameters.AddWithValue("@Description", permission.Description);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating permission: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a permission by ID
        public Permission GetPermissionById(int id)
        {
            string query = "SELECT id, permission_name, api_path, description, created_at, updated_at FROM permission WHERE id = @Id";
            Permission permission = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        permission = new Permission
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            PermissionName = dataReader["permissionName"].ToString(),
                            ApiPath = dataReader["apiPath"].ToString(),
                            Description = dataReader["description"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["createdAt"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updatedAt"])
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting permission by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return permission;
        }

        // Read all permissions
        public List<Permission> GetAllPermissions()
        {
            string query = "SELECT id, permission_name, api_path, description, created_at, updated_at FROM permission";
            List<Permission> permissions = new List<Permission>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        permissions.Add(new Permission
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            PermissionName = dataReader["permissionName"].ToString(),
                            ApiPath = dataReader["apiPath"].ToString(),
                            Description = dataReader["description"].ToString(),
                            CreatedAt = Convert.ToDateTime(dataReader["createdAt"]),
                            UpdatedAt = Convert.ToDateTime(dataReader["updatedAt"])
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all permissions: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return permissions;
        }

        // Update an existing permission
        public bool UpdatePermission(Permission permission)
        {
            string query = "UPDATE permission SET permission_name = @PermissionName, api_path = @ApiPath, description = @Description, updated_at = @UpdatedAt WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@PermissionName", permission.PermissionName);
                    cmd.Parameters.AddWithValue("@ApiPath", permission.ApiPath);
                    cmd.Parameters.AddWithValue("@Description", permission.Description);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Id", permission.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating permission: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a permission by ID
        public bool DeletePermission(int id)
        {
            string query = "DELETE FROM permission WHERE id = @Id";
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
                    Console.WriteLine($"Error deleting permission: {ex.Message}");
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