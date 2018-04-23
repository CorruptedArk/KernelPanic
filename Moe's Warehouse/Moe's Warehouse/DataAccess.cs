using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
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
            catch(MySql.Data.MySqlClient.MySqlException ex)
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
            catch(MySql.Data.MySqlClient.MySqlException ex)
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
        public bool AddItems(string name, string desc, string tags, int price, int qty, int vencode)
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

        // counts number of employee accounts
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
                        MessageBox.Show(returnValue.ToString());
                        return returnValue;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return 0;
            }
        }

        //////////////////////////////////// End Item Data ////////////////////////////////////

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
    }
}
