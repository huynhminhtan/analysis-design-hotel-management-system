using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThueDTO
    {

        #region Attributes

        private String maPhieuThue;
        private String maKhachHang;
        private String maNhanVien;
        private DateTime ngayLap;
        private int soLuongPhong;

        #endregion

        #region Properties
        public string MaPhieuThue { get => maPhieuThue; set => maPhieuThue = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public int SoLuongPhong { get => soLuongPhong; set => soLuongPhong = value; }

        #endregion

    }
}
