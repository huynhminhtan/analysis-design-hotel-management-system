using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHangLapPhieuThueBUS
    {
        public static NpgsqlDataAdapter LayDanhSachKhachhang()
        {
            return DAO.KhachHangLapPhieuThueDAO.LayDanhSachKhachhang();
        }
    }
}
