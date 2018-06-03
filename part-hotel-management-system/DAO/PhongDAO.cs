using DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhongDAO
    {

        #region Retrieving

        public static PhongDTO LayPhongTheoMaPhong(String mph)
        {
            PhongDTO phong = null;

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
                string sql = "SELECT maphong, tenphong, loaiphong.maloaiphong, tenloaiphong, dongia, tinhtrang FROM phong, loaiphong WHERE phong.maloaiphong = loaiphong.maloaiphong AND maphong = '" + mph + "'";

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    phong = new PhongDTO();
                    phong.MaPhong = reader[0].ToString();
                    phong.TenPhong = reader[1].ToString();
                    phong.MaLoaiPhong = reader[2].ToString();
                    phong.TenLoaiPhong = reader[3].ToString();
                    phong.DonGia = Double.Parse(reader[4].ToString());

                    if (reader[5].ToString() == "True")
                    {
                        phong.LoaiTinhTrang = true;
                    }
                    else
                    {
                        phong.LoaiTinhTrang = false;
                    }
                }

                conn.Close();
                return phong;

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why

                throw msg;
            }
        }


        public static PhongDTO LayPhongTheoTenPhong(String tenphong)
        {
            PhongDTO phong = null;

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
                string sql = "SELECT maphong, tenphong, loaiphong.maloaiphong, tenloaiphong, dongia, tinhtrang FROM phong, loaiphong WHERE phong.maloaiphong = loaiphong.maloaiphong AND tenphong = '" + tenphong + "'";

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    phong = new PhongDTO();
                    phong.MaPhong = reader[0].ToString();
                    phong.TenPhong = reader[1].ToString();
                    phong.MaLoaiPhong = reader[2].ToString();
                    phong.TenLoaiPhong = reader[3].ToString();
                    phong.DonGia = Double.Parse(reader[4].ToString());

                    if (reader[5].ToString() == "true")
                    {
                        phong.LoaiTinhTrang = true;
                    }
                    else
                    {
                        phong.LoaiTinhTrang = false;
                    }
                }

                conn.Close();
                return phong;

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why

                throw msg;
            }
        }
        #endregion

        #region Updating
        public static Boolean CapNhatTinhTrangPhongTheoMaPhong(String maphong)
        {

            try
            {
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(SqlDataAccessHelper.ConnectionString());
                conn.Open();
                // quite complex sql statement

                string sqlPara = "UPDATE phong SET tinhtrang=true WHERE maphong='" + maphong + "';";

                NpgsqlCommand cmd = new NpgsqlCommand(sqlPara, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                //MessageBox.Show("okie");
                return true;

            }
            catch (Exception)
            {
                // something went wrong, and you wanna know why
                //MessageBox.Show(msg.ToString());
                return false;
                throw;
            }
        }
        #endregion
    }
}
