using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class MaterialFunc
    {
        private readonly Engine _dbEngine;

        public MaterialFunc(Engine dbEngine)
        {
            _dbEngine = dbEngine;
        }

        /**
         * Create a new material
         */
        public bool CreateMaterial(Material material)
        {
            string query = "INSERT INTO material (material_number, description, material.unit_of_measure, quantity_in_stock, reorder_level, reorder_quantity, last_received_date) VALUES (@MaterialNumber, @Description, @UnitOfMeasure, @QuantityInStock, @ReorderLevel, @ReorderQuantity, @LastReceivedDate)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@MaterialNumber", material.MaterialNumber);
                    cmd.Parameters.AddWithValue("@Description", material.Description);
                    cmd.Parameters.AddWithValue("@UnitOfMeasure", material.UnitOfMeasure);
                    cmd.Parameters.AddWithValue("@QuantityInStock", material.QuantityInStock);
                    cmd.Parameters.AddWithValue("@ReorderLevel", material.ReorderLevel);
                    cmd.Parameters.AddWithValue("@ReorderQuantity", material.ReorderQuantity);
                    cmd.Parameters.AddWithValue("@LastReceivedDate", material.LastReceivedDate);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating material: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a material by ID
        public Material GetMaterialById(int id)
        {
            string query = "SELECT id, material_number, description, unit_of_measure, quantity_in_stock, reorder_level, reorder_quantity, last_received_date FROM material WHERE id = @Id";
            Material material = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        material = new Material
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            MaterialNumber = dataReader["material_number"].ToString(),
                            Description = dataReader["description"].ToString(),
                            UnitOfMeasure = dataReader["unit_of_measure"].ToString(),
                            QuantityInStock = dataReader["quantity_in_stock"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["quantity_in_stock"]),
                            ReorderLevel = dataReader["reorder_level"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["reorder_level"]),
                            ReorderQuantity = dataReader["reorder_quantity"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["reorder_quantity"]),
                            LastReceivedDate = dataReader["last_received_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["last_received_date"])
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting material by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return material;
        }

        // Read all materials
        public List<Material> GetAllMaterials()
        {
            string query = "SELECT id, material_number, description, unit_of_measure, quantity_in_stock, reorder_level, reorder_quantity, last_received_date FROM material";
            List<Material> materials = new List<Material>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        materials.Add(new Material
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            MaterialNumber = dataReader["material_number"].ToString(),
                            Description = dataReader["description"].ToString(),
                            UnitOfMeasure = dataReader["unit_of_measure"].ToString(),
                            QuantityInStock = dataReader["quantity_in_stock"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["quantity_in_stock"]),
                            ReorderLevel = dataReader["reorder_level"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["reorder_level"]),
                            ReorderQuantity = dataReader["reorder_quantity"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["reorder_quantity"]),
                            LastReceivedDate = dataReader["last_received_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["last_received_date"])
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all materials: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return materials;
        }

        // Update an existing material
        public bool UpdateMaterial(Material material)
        {
            string query = "UPDATE material SET material_number = @MaterialNumber, description = @Description, unit_of_measure = @UnitOfMeasure, quantity_in_stock = @QuantityInStock, reorder_level = @ReorderLevel, reorder_quantity = @ReorderQuantity, last_received_date = @LastReceivedDate WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@MaterialNumber", material.MaterialNumber);
                    cmd.Parameters.AddWithValue("@Description", material.Description);
                    cmd.Parameters.AddWithValue("@UnitOfMeasure", material.UnitOfMeasure);
                    cmd.Parameters.AddWithValue("@QuantityInStock", material.QuantityInStock);
                    cmd.Parameters.AddWithValue("@ReorderLevel", material.ReorderLevel);
                    cmd.Parameters.AddWithValue("@ReorderQuantity", material.ReorderQuantity);
                    cmd.Parameters.AddWithValue("@LastReceivedDate", material.LastReceivedDate);
                    cmd.Parameters.AddWithValue("@Id", material.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating material: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a material by ID
        public bool DeleteMaterial(int id)
        {
            string query = "DELETE FROM material WHERE id = @Id";
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
                    Console.WriteLine($"Error deleting material: {ex.Message}");
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