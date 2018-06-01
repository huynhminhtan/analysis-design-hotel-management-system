using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO
    {
        #region Attributes

        private String maPhong;
        private String tenPhong;
        private String maLoaiPhong;
        private String tenLoaiPhong;
        private String loaiTinhTrang;
        private Double donGia;

        #endregion

        #region Properties
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string MaLoaiPhong { get => maLoaiPhong; set => maLoaiPhong = value; }
        public string LoaiTinhTrang { get => loaiTinhTrang; set => loaiTinhTrang = value; }
        public string TenLoaiPhong { get => tenLoaiPhong; set => tenLoaiPhong = value; }
        public double DonGia { get => donGia; set => donGia = value; }

        #endregion
    }
}
