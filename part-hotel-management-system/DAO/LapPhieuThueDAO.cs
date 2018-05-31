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

                    if (reader[2].ToString() == "true")
                    {
                        phieuthue.TinhTrang = true;
                    }
                    else
                    {
                        phieuthue.TinhTrang = false;
                    }
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

        public static NpgsqlDataAdapter LayDanhSachPhieuThue()
        {
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
                string sql = "SELECT phieuthue.maphieuthue, phieuthue.makhachhang, hoten, manhanvien, ngaylap FROM phieuthue, khachhang WHERE phieuthue.makhachhang = khachhang.makhachhang";
                // data adapter making request from our connection
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

                conn.Close();
                return da;

            }
            catch (Exception msg)
            {
                throw msg;
            }
        }

        public static NpgsqlDataAdapter TimKiemPhieuThue(PhieuThueDTO pt)
        {
            try
            {
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(SqlDataAccessHelper.ConnectionString());
                conn.Open();
                // quite complex sql statement
                string sql = "select phieuthue.maphieuthue, phieuthue.makhachhang, hoten, manhanvien, ngaylap  from phieuthue, khachhang WHERE phieuthue.makhachhang = khachhang.makhachhang AND maphieuthue LIKE '%" + pt.MaPhieuThue + "%' AND phieuthue.makhachhang LIKE '%" + pt.MaKhachHang + "%' AND hoten LIKE '%" + pt.HoTenKhachHang + "%'";

                // data adapter making request from our connection
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

                conn.Close();
                return da;

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                //MessageBox.Show(msg.ToString());
                throw msg;
            }
        }


        public static NpgsqlDataAdapter TimKiemPhieuThueTheoNgayLap(PhieuThueDTO pt)
        {
            try
            {
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(SqlDataAccessHelper.ConnectionString());
                conn.Open();
                // quite complex sql statement
                string sql = "select phieuthue.maphieuthue, phieuthue.makhachhang, hoten, manhanvien, ngaylap  from phieuthue, khachhang WHERE phieuthue.makhachhang = khachhang.makhachhang AND maphieuthue LIKE '%" + pt.MaPhieuThue + "%' AND phieuthue.makhachhang LIKE '%" + pt.MaKhachHang + "%' AND hoten LIKE '%" + pt.HoTenKhachHang + "%' AND ngaylap = '" + pt.NgayLap + "'";

                // data adapter making request from our connection
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

                conn.Close();
                return da;

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                //MessageBox.Show(msg.ToString());
                throw msg;
            }
        }


        #endregion

    }
}
