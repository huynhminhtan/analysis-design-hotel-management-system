using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class KhachHangDTO
    {
        KhachHangDTO()
        {
            //maKhachHang = "";
        }

        #region Attributes

        private String maKhachHang;
        private String hoTen;
        private String cMND;
        private DateTime ngaySinh;
        private String gioiTinh;
        private String diaChi;
        private String sdt;
        private String maLoaiKhachHang;

        #endregion

        #region Properties

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string MaLoaiKhachHang { get => maLoaiKhachHang; set => maLoaiKhachHang = value; }

        #endregion
    }
}
