using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DesktopApp.Database.Func
{
    public class OrderFunc
    {
        private readonly Engine _dbEngine = Engine.Instance;
        public OrderFunc(){}

        /**
         * Create a new sales order
         */
        public bool CreateSalesOrder(SalesOrder order)
        {
            string query = "INSERT INTO sales_order (customer_id, order_number, payment_method, order_date, delivery_date, payment_terms, shipping_address, status, product_amount_cents, shipping_cost_cents, tax_amount_cents, total_amount_cents, down_payment_percent, down_payment_date, is_down_payment_paid, is_customized, special_requirements) VALUES (@CustomerId, @OrderNumber, @PaymentMethod, @OrderDate, @DeliveryDate, @PaymentTerms, @ShippingAddress, @Status, @ProductAmountCents, @ShippingCostCents, @TaxAmountCents, @TotalAmountCents, @DownPaymentPercent, @DownPaymentDate, @IsDownPaymentPaid, @IsCustomized, @SpecialRequirements)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    // 生成订单号（如果为空）
                    if (string.IsNullOrEmpty(order.OrderNumber))
                    {
                        order.OrderNumber = GenerateOrderNumber();
                    }

                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    cmd.Parameters.AddWithValue("@PaymentMethod", order.PaymentMethod);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                    cmd.Parameters.AddWithValue("@PaymentTerms", order.PaymentTerms);
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@ProductAmountCents", order.ProductAmountCents);
                    cmd.Parameters.AddWithValue("@ShippingCostCents", order.ShippingCostCents);
                    cmd.Parameters.AddWithValue("@TaxAmountCents", order.TaxAmountCents);
                    cmd.Parameters.AddWithValue("@TotalAmountCents", order.TotalAmountCents);
                    cmd.Parameters.AddWithValue("@DownPaymentPercent", order.DownPaymentPercent);
                    cmd.Parameters.AddWithValue("@DownPaymentDate", order.DownPaymentDate);
                    cmd.Parameters.AddWithValue("@IsDownPaymentPaid", order.IsDownPaymentPaid);
                    cmd.Parameters.AddWithValue("@IsCustomized", order.IsCustomized);
                    cmd.Parameters.AddWithValue("@SpecialRequirements", order.SpecialRequirements);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating sales order: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        /**
         * Create a new sales order and return the order ID (for CreateOrderForm compatibility)
         */
        public int CreateOrder(SalesOrder order)
        {
            string query = "INSERT INTO sales_order (customer_id, order_number, payment_method, order_date, delivery_date, payment_terms, shipping_address, status, product_amount_cents, shipping_cost_cents, tax_amount_cents, total_amount_cents, down_payment_percent, down_payment_date, is_down_payment_paid, is_customized, special_requirements) VALUES (@CustomerId, @OrderNumber, @PaymentMethod, @OrderDate, @DeliveryDate, @PaymentTerms, @ShippingAddress, @Status, @ProductAmountCents, @ShippingCostCents, @TaxAmountCents, @TotalAmountCents, @DownPaymentPercent, @DownPaymentDate, @IsDownPaymentPaid, @IsCustomized, @SpecialRequirements); SELECT LAST_INSERT_ID();";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    // 生成订单号（如果为空）
                    if (string.IsNullOrEmpty(order.OrderNumber))
                    {
                        order.OrderNumber = GenerateOrderNumber();
                    }

                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    cmd.Parameters.AddWithValue("@PaymentMethod", order.PaymentMethod);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                    cmd.Parameters.AddWithValue("@PaymentTerms", order.PaymentTerms);
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@ProductAmountCents", order.ProductAmountCents);
                    cmd.Parameters.AddWithValue("@ShippingCostCents", order.ShippingCostCents);
                    cmd.Parameters.AddWithValue("@TaxAmountCents", order.TaxAmountCents);
                    cmd.Parameters.AddWithValue("@TotalAmountCents", order.TotalAmountCents);
                    cmd.Parameters.AddWithValue("@DownPaymentPercent", order.DownPaymentPercent);
                    cmd.Parameters.AddWithValue("@DownPaymentDate", order.DownPaymentDate);
                    cmd.Parameters.AddWithValue("@IsDownPaymentPaid", order.IsDownPaymentPaid);
                    cmd.Parameters.AddWithValue("@IsCustomized", order.IsCustomized);
                    cmd.Parameters.AddWithValue("@SpecialRequirements", order.SpecialRequirements);
                    
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int orderId))
                    {
                        return orderId;
                    }
                    return 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating sales order: {ex.Message}");
                    return 0;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return 0;
        }

        /**
         * Add order item (alias for CreateOrderItem for CreateOrderForm compatibility)
         */
        public bool AddOrderItem(OrderItem orderItem)
        {
            return CreateOrderItem(orderItem);
        }

        // Create a new order item
        public bool CreateOrderItem(OrderItem orderItem)
        {
            string query = "INSERT INTO order_item (order_id, product_id, quantity, unit_price_cents, total_price_cents) VALUES (@OrderId, @ProductId, @Quantity, @UnitPriceCents, @TotalPriceCents)";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
                    cmd.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPriceCents", orderItem.UnitPriceCents);
                    cmd.Parameters.AddWithValue("@TotalPriceCents", orderItem.TotalPriceCents);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating order item: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Create multiple order items
        public bool CreateOrderItems(List<OrderItem> orderItems)
        {
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    foreach (var item in orderItems)
                    {
                        string query = "INSERT INTO order_item (order_id, product_id, quantity, unit_price_cents, total_price_cents) VALUES (@OrderId, @ProductId, @Quantity, @UnitPriceCents, @TotalPriceCents)";
                        MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                        cmd.Parameters.AddWithValue("@OrderId", item.OrderId);
                        cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@UnitPriceCents", item.UnitPriceCents);
                        cmd.Parameters.AddWithValue("@TotalPriceCents", item.TotalPriceCents);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error creating order items: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read all sales orders
        public List<SalesOrder> GetAllSalesOrders()
        {
            string query = "SELECT id, customer_id, order_number, payment_method, order_date, delivery_date, payment_terms, shipping_address, status, product_amount_cents, shipping_cost_cents, tax_amount_cents, total_amount_cents, down_payment_percent, down_payment_date, is_down_payment_paid, is_customized, special_requirements FROM sales_order ORDER BY order_date DESC";
            List<SalesOrder> orders = new List<SalesOrder>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        orders.Add(new SalesOrder
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            CustomerId = Convert.ToInt32(dataReader["customer_id"]),
                            OrderNumber = dataReader["order_number"].ToString(),
                            PaymentMethod = dataReader["payment_method"].ToString(),
                            OrderDate = dataReader["order_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["order_date"]),
                            DeliveryDate = dataReader["delivery_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["delivery_date"]),
                            PaymentTerms = dataReader["payment_terms"].ToString(),
                            ShippingAddress = dataReader["shipping_address"].ToString(),
                            Status = dataReader["status"].ToString(),
                            ProductAmountCents = dataReader["product_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["product_amount_cents"]),
                            ShippingCostCents = dataReader["shipping_cost_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["shipping_cost_cents"]),
                            TaxAmountCents = dataReader["tax_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["tax_amount_cents"]),
                            TotalAmountCents = dataReader["total_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["total_amount_cents"]),
                            DownPaymentPercent = dataReader["down_payment_percent"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["down_payment_percent"]),
                            DownPaymentDate = dataReader["down_payment_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["down_payment_date"]),
                            IsDownPaymentPaid = dataReader["is_down_payment_paid"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(dataReader["is_down_payment_paid"]),
                            IsCustomized = Convert.ToBoolean(dataReader["is_customized"]),
                            SpecialRequirements = dataReader["special_requirements"].ToString()
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting all sales orders: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return orders;
        }

        // Read a sales order by ID
        public SalesOrder GetSalesOrderById(int id)
        {
            string query = "SELECT id, customer_id, order_number, payment_method, order_date, delivery_date, payment_terms, shipping_address, status, product_amount_cents, shipping_cost_cents, tax_amount_cents, total_amount_cents, down_payment_percent, down_payment_date, is_down_payment_paid, is_customized, special_requirements FROM sales_order WHERE id = @Id";
            SalesOrder order = null;

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        order = new SalesOrder
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            CustomerId = Convert.ToInt32(dataReader["customer_id"]),
                            OrderNumber = dataReader["order_number"].ToString(),
                            PaymentMethod = dataReader["payment_method"].ToString(),
                            OrderDate = dataReader["order_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["order_date"]),
                            DeliveryDate = dataReader["delivery_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["delivery_date"]),
                            PaymentTerms = dataReader["payment_terms"].ToString(),
                            ShippingAddress = dataReader["shipping_address"].ToString(),
                            Status = dataReader["status"].ToString(),
                            ProductAmountCents = dataReader["product_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["product_amount_cents"]),
                            ShippingCostCents = dataReader["shipping_cost_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["shipping_cost_cents"]),
                            TaxAmountCents = dataReader["tax_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["tax_amount_cents"]),
                            TotalAmountCents = dataReader["total_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["total_amount_cents"]),
                            DownPaymentPercent = dataReader["down_payment_percent"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["down_payment_percent"]),
                            DownPaymentDate = dataReader["down_payment_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["down_payment_date"]),
                            IsDownPaymentPaid = dataReader["is_down_payment_paid"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(dataReader["is_down_payment_paid"]),
                            IsCustomized = Convert.ToBoolean(dataReader["is_customized"]),
                            SpecialRequirements = dataReader["special_requirements"].ToString()
                        };
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting sales order by ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return order;
        }

        // Read order items by order ID
        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            string query = "SELECT id, order_id, product_id, quantity, unit_price_cents, total_price_cents FROM order_item WHERE order_id = @OrderId";
            List<OrderItem> orderItems = new List<OrderItem>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        orderItems.Add(new OrderItem
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            OrderId = Convert.ToInt32(dataReader["order_id"]),
                            ProductId = Convert.ToInt32(dataReader["product_id"]),
                            Quantity = dataReader["quantity"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["quantity"]),
                            UnitPriceCents = dataReader["unit_price_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["unit_price_cents"]),
                            TotalPriceCents = dataReader["total_price_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["total_price_cents"])
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting order items by order ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return orderItems;
        }

        // Read sales orders by customer ID
        public List<SalesOrder> GetSalesOrdersByCustomerId(int customerId)
        {
            string query = "SELECT id, customer_id, order_number, payment_method, order_date, delivery_date, payment_terms, shipping_address, status, product_amount_cents, shipping_cost_cents, tax_amount_cents, total_amount_cents, down_payment_percent, down_payment_date, is_down_payment_paid, is_customized, special_requirements FROM sales_order WHERE customer_id = @CustomerId ORDER BY order_date DESC";
            List<SalesOrder> orders = new List<SalesOrder>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        orders.Add(new SalesOrder
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            CustomerId = Convert.ToInt32(dataReader["customer_id"]),
                            OrderNumber = dataReader["order_number"].ToString(),
                            PaymentMethod = dataReader["payment_method"].ToString(),
                            OrderDate = dataReader["order_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["order_date"]),
                            DeliveryDate = dataReader["delivery_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["delivery_date"]),
                            PaymentTerms = dataReader["payment_terms"].ToString(),
                            ShippingAddress = dataReader["shipping_address"].ToString(),
                            Status = dataReader["status"].ToString(),
                            ProductAmountCents = dataReader["product_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["product_amount_cents"]),
                            ShippingCostCents = dataReader["shipping_cost_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["shipping_cost_cents"]),
                            TaxAmountCents = dataReader["tax_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["tax_amount_cents"]),
                            TotalAmountCents = dataReader["total_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["total_amount_cents"]),
                            DownPaymentPercent = dataReader["down_payment_percent"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["down_payment_percent"]),
                            DownPaymentDate = dataReader["down_payment_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["down_payment_date"]),
                            IsDownPaymentPaid = dataReader["is_down_payment_paid"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(dataReader["is_down_payment_paid"]),
                            IsCustomized = Convert.ToBoolean(dataReader["is_customized"]),
                            SpecialRequirements = dataReader["special_requirements"].ToString()
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting sales orders by customer ID: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return orders;
        }

        // Update an existing sales order
        public bool UpdateSalesOrder(SalesOrder order)
        {
            string query = "UPDATE sales_order SET customer_id = @CustomerId, order_number = @OrderNumber, payment_method = @PaymentMethod, order_date = @OrderDate, delivery_date = @DeliveryDate, payment_terms = @PaymentTerms, shipping_address = @ShippingAddress, status = @Status, product_amount_cents = @ProductAmountCents, shipping_cost_cents = @ShippingCostCents, tax_amount_cents = @TaxAmountCents, total_amount_cents = @TotalAmountCents, down_payment_percent = @DownPaymentPercent, down_payment_date = @DownPaymentDate, is_down_payment_paid = @IsDownPaymentPaid, is_customized = @IsCustomized, special_requirements = @SpecialRequirements WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    cmd.Parameters.AddWithValue("@PaymentMethod", order.PaymentMethod);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                    cmd.Parameters.AddWithValue("@PaymentTerms", order.PaymentTerms);
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@ProductAmountCents", order.ProductAmountCents);
                    cmd.Parameters.AddWithValue("@ShippingCostCents", order.ShippingCostCents);
                    cmd.Parameters.AddWithValue("@TaxAmountCents", order.TaxAmountCents);
                    cmd.Parameters.AddWithValue("@TotalAmountCents", order.TotalAmountCents);
                    cmd.Parameters.AddWithValue("@DownPaymentPercent", order.DownPaymentPercent);
                    cmd.Parameters.AddWithValue("@DownPaymentDate", order.DownPaymentDate);
                    cmd.Parameters.AddWithValue("@IsDownPaymentPaid", order.IsDownPaymentPaid);
                    cmd.Parameters.AddWithValue("@IsCustomized", order.IsCustomized);
                    cmd.Parameters.AddWithValue("@SpecialRequirements", order.SpecialRequirements);
                    cmd.Parameters.AddWithValue("@Id", order.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating sales order: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Update an existing order item
        public bool UpdateOrderItem(OrderItem orderItem)
        {
            string query = "UPDATE order_item SET order_id = @OrderId, product_id = @ProductId, quantity = @Quantity, unit_price_cents = @UnitPriceCents, total_price_cents = @TotalPriceCents WHERE id = @Id";
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
                    cmd.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPriceCents", orderItem.UnitPriceCents);
                    cmd.Parameters.AddWithValue("@TotalPriceCents", orderItem.TotalPriceCents);
                    cmd.Parameters.AddWithValue("@Id", orderItem.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error updating order item: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete a sales order by ID (cascade delete order items)
        public bool DeleteSalesOrder(int id)
        {
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    // First delete order items
                    string deleteItemsQuery = "DELETE FROM order_item WHERE order_id = @OrderId";
                    MySqlCommand deleteItemsCmd = new MySqlCommand(deleteItemsQuery, _dbEngine.GetConnection());
                    deleteItemsCmd.Parameters.AddWithValue("@OrderId", id);
                    deleteItemsCmd.ExecuteNonQuery();

                    // Then delete the order
                    string deleteOrderQuery = "DELETE FROM sales_order WHERE id = @Id";
                    MySqlCommand deleteOrderCmd = new MySqlCommand(deleteOrderQuery, _dbEngine.GetConnection());
                    deleteOrderCmd.Parameters.AddWithValue("@Id", id);
                    deleteOrderCmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error deleting sales order: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Delete an order item by ID
        public bool DeleteOrderItem(int id)
        {
            string query = "DELETE FROM order_item WHERE id = @Id";
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
                    Console.WriteLine($"Error deleting order item: {ex.Message}");
                    return false;
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return false;
        }

        // Read sales orders by status
        public List<SalesOrder> GetSalesOrdersByStatus(string status)
        {
            string query = "SELECT id, customer_id, order_number, payment_method, order_date, delivery_date, payment_terms, shipping_address, status, product_amount_cents, shipping_cost_cents, tax_amount_cents, total_amount_cents, down_payment_percent, down_payment_date, is_down_payment_paid, is_customized, special_requirements FROM sales_order WHERE status = @Status ORDER BY order_date DESC";
            List<SalesOrder> orders = new List<SalesOrder>();

            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Status", status);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        orders.Add(new SalesOrder
                        {
                            Id = Convert.ToInt32(dataReader["id"]),
                            CustomerId = Convert.ToInt32(dataReader["customer_id"]),
                            OrderNumber = dataReader["order_number"].ToString(),
                            PaymentMethod = dataReader["payment_method"].ToString(),
                            OrderDate = dataReader["order_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["order_date"]),
                            DeliveryDate = dataReader["delivery_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["delivery_date"]),
                            PaymentTerms = dataReader["payment_terms"].ToString(),
                            ShippingAddress = dataReader["shipping_address"].ToString(),
                            Status = dataReader["status"].ToString(),
                            ProductAmountCents = dataReader["product_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["product_amount_cents"]),
                            ShippingCostCents = dataReader["shipping_cost_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["shipping_cost_cents"]),
                            TaxAmountCents = dataReader["tax_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["tax_amount_cents"]),
                            TotalAmountCents = dataReader["total_amount_cents"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["total_amount_cents"]),
                            DownPaymentPercent = dataReader["down_payment_percent"] == DBNull.Value ? null : (int?)Convert.ToInt32(dataReader["down_payment_percent"]),
                            DownPaymentDate = dataReader["down_payment_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(dataReader["down_payment_date"]),
                            IsDownPaymentPaid = dataReader["is_down_payment_paid"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(dataReader["is_down_payment_paid"]),
                            IsCustomized = Convert.ToBoolean(dataReader["is_customized"]),
                            SpecialRequirements = dataReader["special_requirements"].ToString()
                        });
                    }
                    dataReader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error getting sales orders by status: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            return orders;
        }

        // Generate order number
        private string GenerateOrderNumber()
        {
            var now = DateTime.Now;
            var prefix = $"SO{now:yyyyMMdd}";
            
            string countQuery = "SELECT COUNT(*) FROM sales_order WHERE order_number LIKE @Prefix";
            int todayOrders = 0;
            
            if (_dbEngine.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(countQuery, _dbEngine.GetConnection());
                    cmd.Parameters.AddWithValue("@Prefix", prefix + "%");
                    object result = cmd.ExecuteScalar();
                    todayOrders = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error generating order number: {ex.Message}");
                }
                finally
                {
                    _dbEngine.CloseConnection();
                }
            }
            
            // 生成序号（4位数字，不足补0）
            var sequence = (todayOrders + 1).ToString("D4");
            
            return $"{prefix}{sequence}";
        }
    }
}