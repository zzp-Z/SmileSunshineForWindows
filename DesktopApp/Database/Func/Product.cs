using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class ProductFunc
    {
        private readonly Engine _dbEngine = Engine.Instance;

        public ProductFunc()
        {
        }

        /**
         * Create a new product
         */
        public bool CreateProduct(Product product)
        {
            string query = "INSERT INTO product (name, description, price_cents, image_url, safety_certification, create_date, is_public, design_id, quantity_in_stock) VALUES (@Name, @Description, @PriceCents, @ImageUrl, @SafetyCertification, @CreateDate, @IsPublic, @DesignId, @QuantityInStock)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@PriceCents", product.PriceCents);
                    cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                    cmd.Parameters.AddWithValue("@SafetyCertification", product.SafetyCertification);
                    cmd.Parameters.AddWithValue("@CreateDate", product.CreateDate ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@IsPublic", product.IsPublic);
                    cmd.Parameters.AddWithValue("@DesignId", product.DesignId);
                    cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating product: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read a product by ID
        public Product GetProductById(int id)
        {
            string query = "SELECT id, name, description, price_cents, image_url, safety_certification, create_date, is_public, design_id, quantity_in_stock FROM product WHERE id = @Id";
            Product product = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        product = new Product
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Description = dataReader["description"].ToString(),
                            PriceCents = dataReader["price_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["price_cents"]),
                            ImageUrl = dataReader["image_url"].ToString(),
                            SafetyCertification = dataReader["safety_certification"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(dataReader["safety_certification"]),
                            CreateDate = dataReader["create_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["create_date"]),
                            IsPublic = Convert.ToBoolean(dataReader["is_public"]),
                            DesignId = Convert.ToInt32(dataReader["design_id"]),
                            QuantityInStock = Convert.ToInt32(dataReader["quantity_in_stock"])
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting product by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return product;
        }

        // Read all products
        public List<Product> GetAllProducts()
        {
            string query = "SELECT id, name, description, price_cents, image_url, safety_certification, create_date, is_public, design_id, quantity_in_stock FROM product";
            List<Product> products = new List<Product>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            Name = dataReader["name"].ToString(),
                            Description = dataReader["description"].ToString(),
                            PriceCents = dataReader["price_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["price_cents"]),
                            ImageUrl = dataReader["image_url"].ToString(),
                            SafetyCertification = dataReader["safety_certification"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(dataReader["safety_certification"]),
                            CreateDate = dataReader["create_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["create_date"]),
                            IsPublic = Convert.ToBoolean(dataReader["is_public"]),
                            DesignId = Convert.ToInt32(dataReader["design_id"]),
                            QuantityInStock = Convert.ToInt32(dataReader["quantity_in_stock"])
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all products: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return products;
        }

        // Update an existing product
        public bool UpdateProduct(Product product)
        {
            string query = "UPDATE product SET name = @Name, description = @Description, price_cents = @PriceCents, image_url = @ImageUrl, safety_certification = @SafetyCertification, is_public = @IsPublic, design_id = @DesignId, quantity_in_stock = @QuantityInStock WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@PriceCents", product.PriceCents);
                    cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                    cmd.Parameters.AddWithValue("@SafetyCertification", product.SafetyCertification);
                    cmd.Parameters.AddWithValue("@IsPublic", product.IsPublic);
                    cmd.Parameters.AddWithValue("@DesignId", product.DesignId);
                    cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@Id", product.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating product: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a product by ID
        public bool DeleteProduct(int id)
        {
            string query = "DELETE FROM product WHERE id = @Id";
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
                    Console.WriteLine($"Error deleting product: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Reduce product stock quantity
        public bool ReduceProductStock(int productId, int quantity)
        {
            string query = "UPDATE product SET quantity_in_stock = quantity_in_stock - @Quantity WHERE id = @ProductId AND quantity_in_stock >= @Quantity";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // 返回true表示成功减少库存，false表示库存不足或产品不存在
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error reducing product stock: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Check if product has sufficient stock
        public bool CheckProductStock(int productId, int requiredQuantity)
        {
            string query = "SELECT quantity_in_stock FROM product WHERE id = @ProductId";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int currentStock = Convert.ToInt32(result);
                        return currentStock >= requiredQuantity;
                    }
                    return false;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error checking product stock: {ex.Message}");
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