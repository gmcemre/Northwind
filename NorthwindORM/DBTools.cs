using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindORM
{
    class DBTools
    {
        private static SqlConnection _Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        public static SqlConnection Connection
        {
            get
            {
                return _Connection;
            }
        }

        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();

                return rowAffected > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
    }
}
