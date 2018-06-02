using DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BaoCaoDoanhThuPhongDAO
    {

        #region Retrieving

        public static NpgsqlDataAdapter LayDanhSachBaoCaoDoanhThuPhong(DateTime ngayDau, DateTime ngayCuoi)
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
                string sql = "select phong.maphong, tenphong, sum(thanhtienphong) as thanhtienphong " +
                    "from phieuthue, phong, chitietphieuthue " +
                    "where chitietphieuthue.maphong = phong.maphong " +
                        "and chitietphieuthue.maphieuthue = phieuthue.maphieuthue " +
                        "and ((TO_DATE(to_char(ngaylap, 'YYYY-MM-DD'), 'YYYY-MM-DD') >= to_timestamp('" + ngayDau + "', 'MM-DD-YYYY')) " +
                        "and (TO_DATE(to_char(ngaylap, 'YYYY-MM-DD'), 'YYYY-MM-DD') <= to_timestamp('" + ngayCuoi + "', 'MM-DD-YYYY')))" +
                     "group by phong.maphong";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);


                //NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                //NpgsqlDataReader reader = command.ExecuteReader();

                //while (reader.Read())
                //{
                //    bcdt = new BaoCaoDoanhThuPhongDTO();
                //    bcdt.MaPhong = reader[0].ToString();
                //    bcdt.TenPhong = reader[1].ToString();
                //    bcdt.TongTien = Double.Parse(reader[2].ToString());
                //}


                conn.Close();
                return da;

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
