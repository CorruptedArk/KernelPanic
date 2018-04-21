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
        public bool VerifyUsernameAndPassword(string name, string password)
        {
            bool returnValue = false;

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
                    returnValue = Convert.ToBoolean(cmd.Parameters["@result"].Value); // convert sp result to bool
                    return returnValue;
                }
            }
        }
    }
}
