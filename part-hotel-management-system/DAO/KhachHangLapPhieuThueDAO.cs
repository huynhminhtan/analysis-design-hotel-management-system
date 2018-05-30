using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangLapPhieuThueDAO
    {

        #region Retrieving

        public static NpgsqlDataAdapter LayDanhSachKhachhang()
        {
            try
            {

                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(SqlDataAccessHelper.ConnectionString());
                //NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; Port = 5432; User Id = admin; Password = 123456; Database = db_qlks;");
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                // quite complex sql statement
                string sql = "SELECT * FROM khachhang";
                // data adapter making request from our connection
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);    

                conn.Close();
                return da;

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
               
                throw;
            }
        }

        #endregion

    }
}
