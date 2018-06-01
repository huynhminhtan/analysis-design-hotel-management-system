using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuThueDTO
    {

        #region Init

        public ChiTietPhieuThueDTO()
        {

        }

        public ChiTietPhieuThueDTO(String _maphong, String _tenphong, String _maloaiphong, double _dongia, double _tongtien)
        {
            this.maPhong = _maphong;
            this.tenPhong = _tenphong;
            this.maLoaiPhong = _maloaiphong;
            this.donGia = _dongia;
            this.tongTien = _tongtien;
        }

        public ChiTietPhieuThueDTO(string maPhong, string tenPhong, string maLoaiPhong, double donGia, DateTime ngayThue, DateTime ngayTra, double tongTien)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.maLoaiPhong = maLoaiPhong;
            this.donGia = donGia;
            this.ngayThue = ngayThue;
            this.ngayTra = ngayTra;
            this.tongTien = tongTien;
        }


        #endregion

        #region Attributes

        private String maPhong;
        private String tenPhong;
        private String maLoaiPhong;
        private Double donGia;
        private DateTime ngayThue;
        private DateTime ngayTra;
        private Double tongTien;
        private String ghiChu;

        #endregion

        #region Properties
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string MaLoaiPhong { get => maLoaiPhong; set => maLoaiPhong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public DateTime NgayThue { get => ngayThue; set => ngayThue = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        #endregion

    }
}
