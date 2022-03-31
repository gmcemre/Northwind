using NorthwindORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindORM.Facade
{
    public class Urunler
    {
        //SELECT Metodu
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("prc_Urunler_Select", DBTools.Connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //INSERT Metodu
        public static bool Insert(Urun u)
        {
            SqlCommand cmd = new SqlCommand("prc_Urunler_Insert", DBTools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@urunAdi", u.UrunAdi);
            cmd.Parameters.AddWithValue("@birimFiyat", u.BirimFiyati);
            cmd.Parameters.AddWithValue("@hedefStokDuzeyi", u.HedefStokDuzeyi);
            cmd.Parameters.AddWithValue("@kId", u.KategoriID);
            cmd.Parameters.AddWithValue("@tId", u.TedarikciID);

            return DBTools.ExecuteNonQuery(cmd);
        }
    }
}
