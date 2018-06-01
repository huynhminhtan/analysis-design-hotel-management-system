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

        public ChiTietPhieuThueDTO(string maPhong, string tenPhong, string maLoaiPhong, double donGia, DateTime ngayThue, DateTime ngayTra, double tongTien, string ghiChu, string maPhieuThue)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.maLoaiPhong = maLoaiPhong;
            this.donGia = donGia;
            this.ngayThue = ngayThue;
            this.ngayTra = ngayTra;
            this.tongTien = tongTien;
            this.ghiChu = ghiChu;
            this.maPhieuThue = maPhieuThue;
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
        private String maPhieuThue;

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
        public string MaPhieuThue { get => maPhieuThue; set => maPhieuThue = value; }

        #endregion

    }
}
