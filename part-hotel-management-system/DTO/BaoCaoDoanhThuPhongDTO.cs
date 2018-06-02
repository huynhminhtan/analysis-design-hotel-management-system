using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaoCaoDoanhThuPhongDTO
    {

        #region Attributes

        private String maPhong;
        private String tenPhong;
        private Double tongTien;
        private Double tiLe;

        #endregion

        #region Properties

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public double TiLe { get => tiLe; set => tiLe = value; }

        #endregion

    }
}
