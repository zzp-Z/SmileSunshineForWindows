using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class SupplierFunc
    {
        private readonly Engine _dbEngine;

        public SupplierFunc(Engine dbEngine)
        {
            _dbEngine = dbEngine;
        }

        /**
         * Create a new supplier
         */
        public bool CreateSupplier(Supplier supplier)
        {
            string query = "INSERT INTO supplier (name, reliability_rating, contact_name, phone, address, email) VALUES (@Name, @ReliabilityRating, @ContactName, @Phone, @Address, @Email)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@ReliabilityRating", supplier.ReliabilityRating);
                    cmd.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                    cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                    cmd.Parameters.AddWithValue("@Address", supplier.Address);
                    cmd.Parameters.AddWithValue("@Email", supplier.Email);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating supplier: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a supplier by ID
        public Supplier GetSupplierById(int id)
        {
            string query = "SELECT id, name, reliability_rating, contact_name, phone, address, email FROM supplier WHERE id = @Id";
            Supplier supplier = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        supplier = new Supplier
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            ReliabilityRating = dataReader["reliability_rating"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["reliability_rating"]),
                            ContactName = dataReader["contact_name"].ToString(),
                            Phone = dataReader["phone"].ToString(),
                            Address = dataReader["address"].ToString(),
                            Email = dataReader["email"].ToString()
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting supplier by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return supplier;
        }

        // Read all suppliers
        public List<Supplier> GetAllSuppliers()
        {
            string query = "SELECT id, name, reliability_rating, contact_name, phone, address, email FROM supplier";
            List<Supplier> suppliers = new List<Supplier>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        suppliers.Add(new Supplier
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            ReliabilityRating = dataReader["reliability_rating"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["reliability_rating"]),
                            ContactName = dataReader["contact_name"].ToString(),
                            Phone = dataReader["phone"].ToString(),
                            Address = dataReader["address"].ToString(),
                            Email = dataReader["email"].ToString()
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all suppliers: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return suppliers;
        }

        // Update an existing supplier
        public bool UpdateSupplier(Supplier supplier)
        {
            string query = "UPDATE supplier SET name = @Name, reliability_rating = @ReliabilityRating, contact_name = @ContactName, phone = @Phone, address = @Address, email = @Email WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@ReliabilityRating", supplier.ReliabilityRating);
                    cmd.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                    cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                    cmd.Parameters.AddWithValue("@Address", supplier.Address);
                    cmd.Parameters.AddWithValue("@Email", supplier.Email);
                    cmd.Parameters.AddWithValue("@Id", supplier.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating supplier: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a supplier by ID
        public bool DeleteSupplier(int id)
        {
            string query = "DELETE FROM supplier WHERE id = @Id";
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
                    Console.WriteLine($"Error deleting supplier: {ex.Message}");
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