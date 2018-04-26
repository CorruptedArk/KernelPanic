using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KernalPanic
{
    class DataAccess
    {

        ////////////////////////////////// Start Login Data //////////////////////////////////

        // verify user entered correct username and password
        public bool VerifyUsernameAndPassword(string name, string password)
        {
            bool returnValue = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("VerifyUsernameAndPassword", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tempUsername", name);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@tempPassword", password); // set second sp parameter to password
                        cmd.Parameters.Add("@result", MySqlDbType.Int32); // declare third sp param as type int
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare third sp param as return parameter
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                        returnValue = Convert.ToBoolean(cmd.Parameters["@result"].Value); // convert sp result to bool
                        return returnValue;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        // checks if user is an admin or regular user
        public bool CheckAdmin(string name)
        {
            bool returnValue = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("CheckAdmin", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tempUsername", name);  // set first sp parameter to name
                        cmd.Parameters.Add("@result", MySqlDbType.Int32); // declare second sp param as type int
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare second sp param as return parameter
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                        returnValue = Convert.ToBoolean(cmd.Parameters["@result"].Value); // convert sp result to bool
                        return returnValue;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        /////////////////////////////////// End Login Data ///////////////////////////////////

        /////////////////////////////////// Start Item Data ///////////////////////////////////

        // gathers all Items to be displayed
        public List<Items> getItems()
        {
            List<Items> items = new List<Items>();
            Items tmpItems;
            MySqlDataReader reader;
            int num;
            float ftNum;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "select * from ITEM";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmpItems = new Items();
                        int.TryParse(reader["ID"].ToString(), out num);
                        tmpItems.ID = num;
                        tmpItems.Name = (string)reader["Name"];
                        tmpItems.Desc = (string)reader["Description"];
                        tmpItems.Tags = (string)reader["Tags"];
                        float.TryParse(reader["Price"].ToString(), out ftNum);
                        tmpItems.Price = ftNum;
                        tmpItems.Qty = getItemQuantity(tmpItems.ID);
                        int.TryParse(reader["Vendor Code"].ToString(), out num);
                        tmpItems.VenCode = num;
                        items.Add(tmpItems);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) { }

            return items;
        }

        private int getItemQuantity(int row)
        {
            MySqlDataReader reader;
            int totalQuantity = 0, parser;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "select * from ITEM_WAREHOUSE where ItemID = " + row.ToString() + ";";
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    int.TryParse(reader["Ware1"].ToString(), out parser);
                    totalQuantity += parser;
                    int.TryParse(reader["Ware2"].ToString(), out parser);
                    totalQuantity += parser;
                    int.TryParse(reader["Ware3"].ToString(), out parser);
                    totalQuantity += parser;
                    int.TryParse(reader["Ware4"].ToString(), out parser);
                    totalQuantity += parser;
                    int.TryParse(reader["Ware5"].ToString(), out parser);
                    totalQuantity += parser;
                    int.TryParse(reader["Ware6"].ToString(), out parser);
                    totalQuantity += parser;
                    int.TryParse(reader["Ware7"].ToString(), out parser);
                    totalQuantity += parser;
                    reader.Close();
                    connection.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) { }

            return totalQuantity;
        }
        
        public List<OrderItem> getOrderItemsWithItem(Items item)
        {
            List<OrderItem> orderItemList = new List<OrderItem>();
            OrderItem tempOrderItem;
            MySqlDataReader reader;
            using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.AddWithValue("@itemID", item.ID);
                cmd.CommandText = "select * from ORDER_ITEM where ItemID = @itemID";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tempOrderItem = new OrderItem();
                    tempOrderItem.ItemID = item.ID;
                    tempOrderItem.OrderNum = Convert.ToString(reader["OrderNum"]);
                    tempOrderItem.Quantity = Convert.ToInt32(reader["ReqQty"]);
                    orderItemList.Add(tempOrderItem);
                }
                reader.Close();
                connection.Close();
            }
            return orderItemList;
        }

        public List<Order> getOrdersWithItem(Items item)
        {
            List<Order> orderList = new List<Order>();
            MySqlDataReader reader;
            Order tempOrder;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.Parameters.AddWithValue("@itemID", item.ID);
                    cmd.CommandText = "select * from CUSTOMER_ORDER where exists( select * from ORDER_ITEM where ItemID = @itemID AND CUSTOMER_ORDER.OrderNum = ORDER_ITEM.OrderNum)";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tempOrder = new Order();
                        tempOrder.OrderNum = Convert.ToString(reader["OrderNum"]);
                        tempOrder.CustID = Convert.ToInt32(reader["CustomerID"]);
                        tempOrder.CustName = Convert.ToString(reader["CustomerShipName"]);
                        tempOrder.CustStreet = Convert.ToString(reader["CustShipStreet"]);
                        tempOrder.CustState = Convert.ToString(reader["CustShipState"]);
                        tempOrder.CustZip = Convert.ToInt32(reader["CustShipZip"]);
                        tempOrder.OrderDate = Convert.ToString(reader["OrderDate"]);
                        orderList.Add(tempOrder);
                    }
                    connection.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }

            return orderList;
        }

        public void updateRestockDistributions(int itemID, int warehouseID, int percent)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.Parameters.AddWithValue("@itemID", itemID);
                    cmd.Parameters.AddWithValue("@warehouseID", warehouseID);
                    cmd.Parameters.AddWithValue("@percent", percent);
                    cmd.CommandText = "update DISTRIBUTIONS set DistributionPercent = @percent where ItemID = @itemID AND WarehouseID = @warehouseID";
                    cmd.ExecuteReader();
                    connection.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        
        }

        // adds new Items to database
        public int AddItems(string name, string desc, string tags, float price, int vencode, List<int> qty)
        {
            int rows = countItems() + 1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("AddItems", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Item Information
                        cmd.Parameters.AddWithValue("@IDnum", rows);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@itemName", name);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@descr", desc);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@tags", tags);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@cost", price);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@venCode", vencode);  // set first sp parameter to name

                        // Warhouse Item Quantity
                        cmd.Parameters.AddWithValue("@Ware1_Qty", vencode);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@Ware2_Qty", vencode);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@Ware3_Qty", vencode);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@Ware4_Qty", vencode);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@Ware5_Qty", vencode);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@Ware6_Qty", vencode);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@Ware7_Qty", vencode);  // set first sp parameter to name

                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                    }
                }
                return rows;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return -1;
            }
        }

        // remove item from database
        public bool DeleteItem(int ID, string name)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("DeleteItem", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idNum", ID);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@itemName", name);  // set first sp parameter to name
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                    }
                }
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        // counts number of items in database
        private int countItems()
        {
            int returnValue;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("countItems", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@result", MySqlDbType.Int32); // declare second sp param as type int
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare second sp param as return parameter
                        cmd.ExecuteReader(); // execute sp
                        returnValue = Convert.ToInt32(cmd.Parameters["@result"].Value); // convert sp result to int
                        connection.Close();
                        return returnValue;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return 0;
            }
        }

        public string SearchItems(string item)
        {
            string returnValue = "";
            int rows = countItems();
            for (int row = 1; row <= rows; row++)
            {
                returnValue += ",";
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("SearchItems", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@curIndex", row);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@itemToFind", item);  // set first sp parameter to name                    
                        cmd.Parameters.Add("@result", MySqlDbType.Text); // declare third sp param as type int
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare third sp param as return parameter
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                        returnValue += Convert.ToString(cmd.Parameters["@result"].Value); // convert sp result to string
                    }
                }
            }
            return returnValue;
        }

        //////////////////////////////////// End Item Data ////////////////////////////////////

        /////////////////////////////// Start Warehouse Data ///////////////////////////////

        // gathers all warehouses to be displayed
        public List<Warehouses> getWarehouses()
        {
            List<Warehouses> warehouses = new List<Warehouses>();
            Warehouses tmpWarehouses;
            MySqlDataReader reader;
            int num;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "select * from WAREHOUSE";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmpWarehouses = new Warehouses();
                        int.TryParse(reader["ID"].ToString(), out num);
                        tmpWarehouses.ID = num;
                        tmpWarehouses.Name = (string)reader["Name"];
                        tmpWarehouses.Street = (string)reader["Street"];
                        tmpWarehouses.City = (string)reader["City"];
                        tmpWarehouses.State = (string)reader["State"];
                        int.TryParse(reader["ZipCode"].ToString(), out num);
                        tmpWarehouses.Zip = num;
                        warehouses.Add(tmpWarehouses);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) { }

            return warehouses;
        }

        // gathers all warehouses to be displayed
        public List<WarhouseItem> getWarehouseItems(int row)
        {
            string column = "Ware" + row.ToString();
            List<WarhouseItem> warehouseItems = new List<WarhouseItem>();
            WarhouseItem tmpWarehouseItems;
            MySqlDataReader reader;
            int num;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "select ItemID, " + column + " from ITEM_WAREHOUSE";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmpWarehouseItems = new WarhouseItem();
                        int.TryParse(reader["ItemID"].ToString(), out num);
                        tmpWarehouseItems.ID = num;
                        int.TryParse(reader[column].ToString(), out num);
                        if (num != 0)
                        {
                            tmpWarehouseItems.Qty = num;
                            warehouseItems.Add(tmpWarehouseItems);
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) { }

            return warehouseItems;
        }

        // counts number of items in database
        // Kept in case needed in later
        /*private int countWarehouses()
        {
            int returnValue;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("countWarehouses", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@result", MySqlDbType.Int32); // declare second sp param as type int
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare second sp param as return parameter
                        cmd.ExecuteReader(); // execute sp
                        returnValue = Convert.ToInt32(cmd.Parameters["@result"].Value); // convert sp result to int
                        connection.Close();
                        return returnValue;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return 0;
            }
        }*/

        //////////////////////////////// End Warehouse Data ////////////////////////////////

        //////////////////////////////// Start Employee Data ////////////////////////////////

        public List<Employees> getEmployees()
        {
            List<Employees> employees = new List<Employees>();
            Employees tmpEmployee;
            MySqlDataReader reader;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "select * from ACCOUNT";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmpEmployee = new Employees();
                        tmpEmployee.ID = (int)reader["ID"];
                        tmpEmployee.Name = (string)reader["Username"];
                        tmpEmployee.Email = (string)reader["EmailAddr"];
                        tmpEmployee.Admin = (int)reader["IsAdmin"];
                        employees.Add(tmpEmployee);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) { }

            return employees;
        }

        // adds new employee to database
        public bool AddAccount(string user, string pass, int admin)
        {
            int rows = countAccounts() + 1;
            string email = user + "@warehouseinc.com";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("AddAccount", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDnum", rows);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@User", user);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@pass", pass);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@email", email);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@isadmin", admin);  // set first sp parameter to name
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                    }
                }
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        // remove employee from database
        public bool deleteEmployee(string user)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("deleteEmployee", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@User", user);  // set first sp parameter to name
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                    }
                }
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        // counts number of employee accounts
        private int countAccounts()
        {
            int returnValue;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("countAccounts", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@result", MySqlDbType.Int32); // declare second sp param as type int
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare second sp param as return parameter
                        cmd.ExecuteReader(); // execute sp
                        returnValue = Convert.ToInt32(cmd.Parameters["@result"].Value); // convert sp result to int
                        connection.Close();
                        return returnValue;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return 0;
            }
        }
        ///////////////////////////////// End Employee Data /////////////////////////////////

        ///////////////////////////////// Start Batch Data /////////////////////////////////

        public int getLastSequenceNum(string sequenceName)
        {
            int sequenceNum;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("getSequenceNum", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sequenceName", sequenceName);
                        cmd.Parameters.Add("@sequenceNum", MySqlDbType.Int32);
                        cmd.Parameters["@sequenceNum"].Direction = ParameterDirection.Output;
                        cmd.ExecuteReader();
                        sequenceNum = Convert.ToInt32(cmd.Parameters["@sequenceNum"].Value);
                        connection.Close();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                sequenceNum = -1;
            }

            return sequenceNum;
        }

        public bool verifyItem(int itemID)
        {
            bool itemExists;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("verifyItem", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemID", itemID);
                        cmd.Parameters.Add("@itemExists", MySqlDbType.Bit, 1);
                        cmd.Parameters["@itemExists"].Direction = ParameterDirection.Output;
                        cmd.ExecuteReader();
                        itemExists = Convert.ToBoolean(cmd.Parameters["@itemExists"].Value);
                        connection.Close();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                itemExists = false;
            }

            return itemExists;
        }

        public void setSequenceNumber(string sequenceName, int sequenceNumber)
        {
            try
            { 
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("setSequenceNumber", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sequenceName", sequenceName);
                        cmd.Parameters.AddWithValue("@sequenceNumber", sequenceNumber);
                        cmd.ExecuteReader();
                        connection.Close();
                    }
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
               
            }
        }

        public bool vendorOrderExists(int vendorID, int itemID, string date)
        {
            bool verified;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("vendorOrderExists", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vendorID", vendorID);
                        cmd.Parameters.AddWithValue("@itemID", itemID);
                        cmd.Parameters.AddWithValue("@reqDate", date);
                        cmd.Parameters.Add("@verified", MySqlDbType.Bit, 1);
                        cmd.Parameters["@verified"].Direction = ParameterDirection.Output;
                        cmd.ExecuteReader();
                        verified = Convert.ToBoolean(cmd.Parameters["@verified"].Value);
                        connection.Close();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                verified = false;
            }

            return verified;
        }

        public bool vendorShipExists(int vendorID, int itemID, string date)
        {
            bool verified;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("vendorShipExists", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vendorID", vendorID);
                        cmd.Parameters.AddWithValue("@itemID", itemID);
                        cmd.Parameters.AddWithValue("@reqDate", date);
                        cmd.Parameters.Add("@verified", MySqlDbType.Bit, 1);
                        cmd.Parameters["@verified"].Direction = ParameterDirection.Output;
                        cmd.ExecuteReader();
                        verified = Convert.ToBoolean(cmd.Parameters["@verified"].Value);
                        connection.Close();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                verified = false;
            }

            return verified;
        }

        public void insertVendorShipment(int vendorID, int itemID, int quantityReceived, string dateRequested, string dateReceived)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("insertVendorShip", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vendorID", vendorID);
                        cmd.Parameters.AddWithValue("@itemID", itemID);
                        cmd.Parameters.AddWithValue("@receiveQty", quantityReceived);
                        cmd.Parameters.AddWithValue("@reqDate", dateRequested);
                        cmd.Parameters.AddWithValue("@receiveDate", dateReceived);
                        cmd.ExecuteReader();
                        connection.Close();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }

        public List<BackorderItem> getBackorderItems(int itemNum)
        {
            List<BackorderItem> backorderItems = new List<BackorderItem>();
            BackorderItem tempBackOrderItem;
            MySqlDataReader reader;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("getBackorderItems", connection)) // assign new sql command to db connection and stored procedure
                    {
                        
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemID", itemNum);
                        cmd.Parameters.Add("@orderNum", MySqlDbType.VarChar, 6);
                        cmd.Parameters["@orderNum"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@reqQty", MySqlDbType.Int32, 5);
                        cmd.Parameters["@reqQty"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@backorderQty", MySqlDbType.Int32, 5);
                        cmd.Parameters["@backorderQty"].Direction = ParameterDirection.Output;
                        reader = cmd.ExecuteReader();

                        while(reader.Read())
                        {
                            tempBackOrderItem = new BackorderItem();
                            tempBackOrderItem.ItemId = itemNum;
                            tempBackOrderItem.OrderNum = (string) reader["@orderNum"];
                            tempBackOrderItem.ReqQty = (int) reader["@reqQty"];
                            tempBackOrderItem.BackorderQty = (int) reader["@backorderQty"];
                            backorderItems.Add(tempBackOrderItem);
                        }

                        connection.Close();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }

            return backorderItems;
        }

        public void updateBackorderItem(BackorderItem backorderItem)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("updateBackorderItem", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@orderNum", backorderItem.OrderNum);
                        cmd.Parameters.AddWithValue("@itemID", backorderItem.ItemId);
                        cmd.Parameters.AddWithValue("@reqQty", backorderItem.ReqQty);
                        cmd.Parameters.AddWithValue("@backorderQty", backorderItem.BackorderQty);
                        cmd.ExecuteReader();
                        connection.Close();
                    }
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                
            }
        }

        public List<Customer> getCustomersByOrders(List<Order> orders)
        {
            List<Customer> customerList = new List<Customer>();
            MySqlDataReader reader;
            Customer tempCust;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    connection.Open();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        MySqlCommand cmd = connection.CreateCommand();
                        cmd.Parameters.AddWithValue("@custID", orders[i].CustID);
                        cmd.CommandText = "select * from CUSTOMER where ID = @custID";
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            tempCust = new Customer();
                            tempCust.Id = orders[i].CustID;
                            tempCust.Name = Convert.ToString(reader["Name"]);
                            tempCust.Street = Convert.ToString(reader["Street"]);
                            tempCust.City = Convert.ToString(reader["City"]);
                            tempCust.State = Convert.ToString(reader["State"]);
                            tempCust.Zip = Convert.ToInt32(reader["ZipCode"]);
                            tempCust.PriorityOne = Convert.ToInt32(reader["PriorityOne"]);
                            tempCust.PriorityTwo = Convert.ToInt32(reader["PriorityTwo"]);
                            tempCust.PriorityThree = Convert.ToInt32(reader["PriorityThree"]);
                            tempCust.PriorityFour = Convert.ToInt32(reader["PriorityFour"]);
                            tempCust.PriorityFive = Convert.ToInt32(reader["PriorityFive"]);
                            tempCust.PrioritySix = Convert.ToInt32(reader["PrioritySix"]);
                            tempCust.PrioritySeven = Convert.ToInt32(reader["PrioritySeven"]);

                            if (!customerList.Contains(tempCust))
                            {
                                customerList.Add(tempCust);
                            }
                        }
                        reader.Close();
                    }
                    connection.Close();

                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }


            return customerList;
        }



        ///////////////////////////////// End Batch Data /////////////////////////////////
    }
}
