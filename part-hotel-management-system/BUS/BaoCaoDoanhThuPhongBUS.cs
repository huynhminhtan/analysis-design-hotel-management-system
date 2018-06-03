using DAO;
using DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BaoCaoDoanhThuPhongBUS
    {

        public static List<BaoCaoDoanhThuPhongDTO> LayDanhSachBaoCaoDoanhThuPhong(DateTime ngayDau, DateTime ngayCuoi)
        {

            BaoCaoDoanhThuPhongDTO bcdtp = null;
            List<BaoCaoDoanhThuPhongDTO> dsbcdtp = new List<BaoCaoDoanhThuPhongDTO>();

            NpgsqlDataAdapter da = BaoCaoDoanhThuPhongDAO.LayDanhSachBaoCaoDoanhThuPhong(ngayDau, ngayCuoi);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            try
            {
                da.Fill(ds);
                dt = ds.Tables[0];

                // 
                foreach (DataRow row in dt.Rows)
                {
                    bcdtp = new BaoCaoDoanhThuPhongDTO();
                    bcdtp.MaPhong = row["maphong"].ToString();
                    bcdtp.TenPhong = row["tenphong"].ToString();
                    bcdtp.TongTien = Double.Parse(row["thanhtienphong"].ToString());

                    dsbcdtp.Add(bcdtp);
                }

                return dsbcdtp;
            }
            catch (Exception)
            {

                return null;
                throw;
            }

        }

    }
}
