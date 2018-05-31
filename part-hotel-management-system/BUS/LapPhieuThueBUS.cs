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
    }
}
