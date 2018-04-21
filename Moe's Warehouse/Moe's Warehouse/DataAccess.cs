using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace KernalPanic
{
    class DataAccess
    {
        // verify user entered correct username
        public bool VerifyUsername(string name)
        {
            bool returnValue = false;

            using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB")))  // establish new db connection
            {
                using (MySqlCommand cmd = new MySqlCommand("VerifyUsername", connection)) // assign new sql command to db connection and stored procedure
                {
                    connection.Open(); // open connection
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tempUsername", name); // set first sp parameter to name
                    cmd.Parameters.Add("@result", MySqlDbType.Int32); // declare second stored procedure param as type int
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare sp param 'result' as return parameter
                    cmd.ExecuteReader(); // execute sp
                    returnValue = Convert.ToBoolean(cmd.Parameters["@result"].Value);  // convert sp result to bool
                    return returnValue;
                }
            }
        }

        public bool VerifyPassword(string password)
        {
            bool returnValue = false;

            using (MySqlConnection connection = new MySqlConnection(Helper.ConnectVal("WarehouseDB"))) // establish new db connection
            {
                using (MySqlCommand cmd = new MySqlCommand("VerifyPassword", connection))  // assign new sql command to db connection and stored procedure
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tempPassword", password); // set first sp parameter to password
                    cmd.Parameters.Add("@result", MySqlDbType.Int32);  // declare second sp parameter as type int
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output; // declare sp param 'result' as outgoing parameter
                    cmd.ExecuteReader(); // execute sp             
                    returnValue = Convert.ToBoolean(cmd.Parameters["@result"].Value);  // convert sp result to bool
                    return returnValue;
                }
            }
        }
    }
}
