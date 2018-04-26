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
        public string getItems()
        {
            string returnValue = "";
            int rows = countItems();
            try
            {
                for (int row = 1; row <= rows; row++)
                {
                    returnValue += ",";
                    using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                    {
                        using (MySqlCommand cmd = new MySqlCommand("getItems", connection)) // assign new sql command to db connection and stored procedure
                        {
                            connection.Open(); // open connection
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@curIndex", row);  // set first sp parameter to name
                            cmd.Parameters.Add("@result", MySqlDbType.Text); // declare second sp param as type int
                            cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare second sp param as return parameter
                            cmd.ExecuteReader(); // execute sp
                            connection.Close();
                            returnValue += Convert.ToString(cmd.Parameters["@result"].Value); // convert sp result to string
                        }
                    }
                }
                //MessageBox.Show(returnValue);
                return returnValue;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return "";
            }
        }

        // adds new Items to database
        public bool AddItems(string name, string desc, string tags, float price, int qty, int vencode)
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
                        cmd.Parameters.AddWithValue("@IDnum", rows);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@itemName", name);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@descr", desc);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@tags", tags);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@cost", price);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@qty", qty);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@venCode", vencode);  // set first sp parameter to name
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
                UpdateItemID(ID);
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

        public void UpdateItemID(int currentRow)
        {
            int rows = countItems();
            for (int row = currentRow; row <= rows; row++)
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("UpdateItemID", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDnum", row + 1);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@newID", row);  // set first sp parameter to name
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                    }
                }
            }
        }

        //////////////////////////////////// End Item Data ////////////////////////////////////

        /////////////////////////////// Start Warehouse Data ///////////////////////////////

        // gathers all Warehouses to be displayed
        public string getWarehouses()
        {
            string returnValue = "";
            int rows = countWarehouses();
            try
            {
                for (int row = 1; row <= rows; row++)
                {
                    returnValue += "|";
                    using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                    {
                        using (MySqlCommand cmd = new MySqlCommand("getWarehouses", connection)) // assign new sql command to db connection and stored procedure
                        {
                            connection.Open(); // open connection
                            cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@curIndex", row);  // set first sp parameter to name
                            cmd.Parameters.Add("@result", MySqlDbType.MediumText); // declare second sp param as type int
                            cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare second sp param as return parameter
                            cmd.ExecuteReader(); // execute sp
                            connection.Close();
                            returnValue += Convert.ToString(cmd.Parameters["@result"].Value); // convert sp result to string
                        }
                    }
                }
                return returnValue;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return "";
            }
        }

        // counts number of items in database
        private int countWarehouses()
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
        }

        //////////////////////////////// End Warehouse Data ////////////////////////////////

        //////////////////////////////// Start Employee Data ////////////////////////////////

        // gathers all employees to be displayed
        public string getEmployees()
        {
            string returnValue = "";
            int rows = countAccounts();
            try
            {
                for (int row = 1; row <= rows; row++)
                {
                    returnValue += ",";
                    using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                    {
                        using (MySqlCommand cmd = new MySqlCommand("getEmployees", connection)) // assign new sql command to db connection and stored procedure
                        {
                            connection.Open(); // open connection
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@curIndex", row);  // set first sp parameter to name
                            cmd.Parameters.Add("@result", MySqlDbType.Text); // declare second sp param as type int
                            cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare second sp param as return parameter
                            cmd.ExecuteReader(); // execute sp
                            connection.Close();
                            returnValue += Convert.ToString(cmd.Parameters["@result"].Value); // convert sp result to string
                        }
                    }
                }
                return returnValue;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return "";
            }
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
        public bool deleteEmployee(string user, int ID)
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
                UpdateEmployeeID(ID);
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        public void UpdateEmployeeID(int currentRow)
        {
            int rows = countAccounts();
            for (int row = currentRow; row <= rows; row++)
            {
                using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
                {
                    using (MySqlCommand cmd = new MySqlCommand("UpdateEmployeeID", connection)) // assign new sql command to db connection and stored procedure
                    {
                        connection.Open(); // open connection
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDnum", row + 1);  // set first sp parameter to name
                        cmd.Parameters.AddWithValue("@newID", row);  // set first sp parameter to name
                        cmd.ExecuteReader(); // execute sp
                        connection.Close();
                    }
                }
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
                    using (MySqlCommand cmd = new MySqlCommand("verifyItem", connection)) // assign new sql command to db connection and stored procedure
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

<<<<<<< HEAD
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
        
=======
        ///////////////////////////////// End Batch Data /////////////////////////////////
>>>>>>> 2d0b940d6ea4de3f892597e382e3cde981cae964
    }
}
