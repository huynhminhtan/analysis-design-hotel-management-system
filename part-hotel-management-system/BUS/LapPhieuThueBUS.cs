using DAO;
using DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LapPhieuThueBUS
    {
        public static KhachHangDTO LayKhachHangTheoMaKhachHang(String mkh)
        {
            return KhachHangDAO.LayKhachHangTheoMaKhachHang(mkh);
        }

        public static PhieuThueDTO LayPhieuThueMoiNhat()
        {
            return LapPhieuThueDAO.LayPhieuThueMoiNhat();
        }

        public static NpgsqlDataAdapter LayDanhSachPhieuThue()
        {
            return LapPhieuThueDAO.LayDanhSachPhieuThue();
        }

        public static NpgsqlDataAdapter TimKiemPhieuThue(PhieuThueDTO pt)
        {
            return LapPhieuThueDAO.TimKiemPhieuThue(pt);
        }

        public static NpgsqlDataAdapter TimKiemPhieuThueTheoNgayLap(PhieuThueDTO pt)
        {
            return LapPhieuThueDAO.TimKiemPhieuThueTheoNgayLap(pt);
        }

        public static PhongDTO LayPhongTheoMaPhong(String mph)
        {
            return PhongDAO.LayPhongTheoMaPhong(mph);
        }

        public static PhongDTO LayPhongTheoTenPhong(String tenphong)
        {
            return PhongDAO.LayPhongTheoTenPhong(tenphong);

        }
    }
}