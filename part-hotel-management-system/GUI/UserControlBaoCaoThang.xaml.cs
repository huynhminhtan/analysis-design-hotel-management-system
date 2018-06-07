using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GUI
{
    /// <summary>
    /// Interaction logic for UserControlBaoCaoThang.xaml
    /// </summary>
    public partial class UserControlBaoCaoThang : UserControl
    {
        private DataTable dt = new DataTable();
        private Double TongDoanhThu = 0;
        public UserControlBaoCaoThang()
        {
            InitializeComponent();
            dtpNgayBatDau.SelectedDate = DateTime.Today;

            TaoBang();
        }

        private void btnLapBaoCao_Click(object sender, RoutedEventArgs e)
        {

            dt.Rows.Clear();
            // date format theo kiểu MM-DD-YYYY
            // pt.NgayLap = DateTime.ParseExact(Convert.ToDateTime(dpkNgayLap.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",CultureInfo.InvariantCulture);

            if (dtpNgayKetThuc.SelectedDate == null)
            {
                dtpNgayKetThuc.SelectedDate = DateTime.Today;
            }

            DateTime NgayBatDau = DateTime.ParseExact(Convert.ToDateTime(dtpNgayBatDau.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture);
            DateTime NgayKetThuc = dtpNgayKetThuc.SelectedDate == null ? DateTime.Today : DateTime.ParseExact(Convert.ToDateTime(dtpNgayKetThuc.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                             CultureInfo.InvariantCulture);

            if (NgayKetThuc.Subtract(NgayBatDau).Days < 0)
            {
                MessageBox.Show("Ngày Kết Thúc Phải Lớn Hơn Ngày Bắt Đầu");
                // 
                return;
            }

            List<BaoCaoDoanhThuPhongDTO> dsbcdtp =
               BaoCaoDoanhThuPhongBUS.LayDanhSachBaoCaoDoanhThuPhong(NgayBatDau, NgayKetThuc);

            if (dsbcdtp.Count == 0)
            {
                MessageBox.Show("Không có phòng được thuê trong thời gian này");
                return;
            }

            // process here
            TongDoanhThu = 0;
            foreach (BaoCaoDoanhThuPhongDTO bcdtp in dsbcdtp)
            {
                TongDoanhThu += bcdtp.TongTien;
            }

            foreach (BaoCaoDoanhThuPhongDTO bcdtp in dsbcdtp)
            {
                bcdtp.TiLe = bcdtp.TongTien / TongDoanhThu;
                dt.Rows.Add(bcdtp.TenPhong, bcdtp.TongTien, bcdtp.TiLe);
            }

            txtTongDoanhThu.Text = TongDoanhThu.ToString();
        }
        private void TaoBang()
        {
            if (!dt.Columns.Contains("Tên Phòng"))
            {
                dt.Columns.Add("Tên Phòng");
            }
            if (!dt.Columns.Contains("Tổng Doanh Thu Phòng"))
            {
                dt.Columns.Add("Tổng Doanh Thu Phòng");
            }
            if (!dt.Columns.Contains("Tỉ Lệ"))
            {
                dt.Columns.Add("Tỉ Lệ");
            }

            dtgBaoCaoDoanhThuPhong.ItemsSource = dt.DefaultView;
        }

    }
}
