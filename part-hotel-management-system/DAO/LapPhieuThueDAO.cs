using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Npgsql;

namespace DAO
{
    public class LapPhieuThueDAO
    {

        #region Retrieving

        public static PhieuThueDTO LayPhieuThueMoiNhat()
        {
            PhieuThueDTO phieuthue = new PhieuThueDTO();

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
                string sql = "SELECT * FROM phieuthue ORDER BY maphieuthue DESC LIMIT 1";

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    phieuthue.MaPhieuThue = reader[0].ToString();
                    phieuthue.MaKhachHang = reader[1].ToString();
                    phieuthue.MaNhanVien = reader[2].ToString();
                    phieuthue.NgayLap = DateTime.Parse(reader[3].ToString());
                    phieuthue.SoLuongPhong = Int32.Parse(reader[4].ToString());
                }

                conn.Close();
                return phieuthue;

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
