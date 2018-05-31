using DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        #region Retrieving

        public static KhachHangDTO LayKhachHangTheoMaKhachHang(String mkh)
        {
            KhachHangDTO khachhang = new KhachHangDTO();

            try
            {

                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(SqlDataAccessHelper.ConnectionString());
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                // quite complex sql statement
                string sql = "SELECT * FROM khachhang Where makhachhang = '" + mkh + "'";
               
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader = command.ExecuteReader();

                String test = "";

                while (reader.Read())
                {
                    khachhang.MaKhachHang = reader[0].ToString();
                    khachhang.HoTen = reader[1].ToString();
                    khachhang.CMND = reader[2].ToString();
                    khachhang.NgaySinh = DateTime.Parse(reader[3].ToString());
                    khachhang.GioiTinh = reader[4].ToString();
                    khachhang.DiaChi = reader[5].ToString();
                    khachhang.Sdt = reader[6].ToString();
                    khachhang.MaLoaiKhachHang = reader[7].ToString();
                }

                conn.Close();
                return khachhang;

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why

                throw msg;
            }
        }

        #endregion
    }
}
