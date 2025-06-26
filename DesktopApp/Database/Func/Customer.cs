using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DesktopApp.Database.Func
{
    public class CustomerFunc
    {
        private readonly Engine _dbEngine = Engine.Instance;


        /**
         * Create a new customer
         */
        public bool CreateCustomer(Customer customer)
        {
            string query = "INSERT INTO customer (name, address, phone) VALUES (@Name, @Address, @Phone)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating customer: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a customer by ID
        public Customer GetCustomerById(int id)
        {
            string query = "SELECT id, name, address, phone FROM customer WHERE id = @Id";
            Customer customer = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        customer = new Customer
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Address = dataReader["address"].ToString(),
                            Phone = dataReader["phone"].ToString()
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting customer by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return customer;
        }

        // Read all customers
        public List<Customer> GetAllCustomers()
        {
            string query = "SELECT id, name, address, phone FROM customer";
            List<Customer> customers = new List<Customer>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Address = dataReader["address"].ToString(),
                            Phone = dataReader["phone"].ToString()
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all customers: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return customers;
        }

        // Update an existing customer
        public bool UpdateCustomer(Customer customer)
        {
            string query = "UPDATE customer SET name = @Name, address = @Address, phone = @Phone WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Id", customer.Id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating customer: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a customer by ID
        public bool DeleteCustomer(int id)
        {
            string query = "DELETE FROM customer WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error deleting customer: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Search customers by name
        public List<Customer> SearchCustomersByName(string name)
        {
            string query = "SELECT id, name, address, phone FROM customer WHERE name LIKE @Name";
            List<Customer> customers = new List<Customer>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", $"%{name}%");
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Address = dataReader["address"].ToString(),
                            Phone = dataReader["phone"].ToString()
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error searching customers by name: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return customers;
        }

        // Search customers by phone
        public Customer GetCustomerByPhone(string phone)
        {
            string query = "SELECT id, name, address, phone FROM customer WHERE phone = @Phone";
            Customer customer = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        customer = new Customer
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Address = dataReader["address"].ToString(),
                            Phone = dataReader["phone"].ToString()
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting customer by phone: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return customer;
        }
    }
}