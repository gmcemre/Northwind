using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindORM.Entity;

namespace NorthwindORM.Facade
{
    public class Kategoriler
    {
        //SELECT Metodu
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("prc_Kategoriler_Select", DBTools.Connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        //INSERT Metodu

        public static bool Insert(Kategori k)
        {
            SqlCommand cmd = new SqlCommand("prc_Kategoriler_Insert", DBTools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kategoriAdi", k.KategoriAdi);
            cmd.Parameters.AddWithValue("@tanimi", k.Tanimi);

            return DBTools.ExecuteNonQuery(cmd);
        }
        //UPDATE Metodu
        //DELETE Metodu
    }
}
