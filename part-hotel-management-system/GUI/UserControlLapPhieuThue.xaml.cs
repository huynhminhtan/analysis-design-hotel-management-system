using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UserControlLapPhieuThue.xaml
    /// </summary>
    public partial class UserControlLapPhieuThue : UserControl
    {
        private String maKhachHang;
        private ObservableCollection<ChiTietPhieuThueDTO> dsphieuthue = new ObservableCollection<ChiTietPhieuThueDTO>();
        private DataTable dt = new DataTable();

        public UserControlLapPhieuThue()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("pt-BR");
            txtboxNgayLapPhieuThue.Text = DateTime.Today.ToString("d", culture);
        }

        public UserControlLapPhieuThue(String mkh)
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("pt-BR");
            txtboxNgayLapPhieuThue.Text = DateTime.Today.ToString("d", culture);

            maKhachHang = mkh;

            // get maKhachHang and tenKhachHang
            KhachHangDTO khachhang = new KhachHangDTO();
            khachhang = BUS.LapPhieuThueBUS.LayKhachHangTheoMaKhachHang(maKhachHang);
            txtboxMaKhachHangPhieuThue.Text = khachhang.MaKhachHang;
            txtboxTenKhachHangPhieuThue.Text = khachhang.HoTen;

            String mpt = BUS.LapPhieuThueBUS.LayPhieuThueMoiNhat().MaPhieuThue;
            txtboxMaPhieuThue.Text = TangMaPhieuThue("PT", mpt);

            TaoBang();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            UserControl usercontrol = new UserControlQuanLyPhieuThue();
            Grid gridmain = ((Grid)this.Parent);
            gridmain.Children.Clear();
            gridmain.Children.Add(usercontrol);
        }

        private string TangMaPhieuThue(String tiento, String ma)
        {
            String maTang = "";

            if (ma == null)
            {
                maTang = tiento + "000";
            }
            else
            {
                maTang = tiento + ((Int32.Parse(ma.Substring(2)) + 1).ToString().PadLeft(3, '0'));
            }

            return maTang;
        }

        private void btnLuuPhieuThue_Click(object sender, RoutedEventArgs e)
        {
            //List<ChiTietPhieuThueDTO> dsphieuthue = new List<ChiTietPhieuThueDTO>();

            //dsphieuthue.Add(new ChiTietPhieuThueDTO(_maphong: "PT0001", _tenphong: "Phòng VIP", _maloaiphong: "LP001", _dongia: 300000, _tongtien: 200000));
            ////dsphieuthue.Add(new ChiTietPhieuThueDTO("PT0002", "Phòng GOLD", "LP003", 500000, 600000));

            //dtgChiTietPhieuThue.ItemsSource = dsphieuthue;
        }

        private void HienThiChiTietPhieuThue()
        {
            dt.Rows.Add("PT0002", "Phòng GOLD", "LP003", 500000);
        }

        private void TaoBang()
        {
            if (!dt.Columns.Contains("Mã phòng"))
            {
                dt.Columns.Add("Mã phòng");
            }
            if (!dt.Columns.Contains("Tên phòng"))
            {
                dt.Columns.Add("Tên phòng");
            }
            if (!dt.Columns.Contains("Loại phòng"))
            {
                dt.Columns.Add("Loại phòng");
            }
            if (!dt.Columns.Contains("Đơn giá"))
            {
                dt.Columns.Add("Đơn giá");
            }
            if (!dt.Columns.Contains("Ngày thuê"))
            {
                dt.Columns.Add("Ngày thuê");
            }
            if (!dt.Columns.Contains("Ngày trả"))
            {
                dt.Columns.Add("Ngày trả");
            }
            if (!dt.Columns.Contains("Tổng tiền"))
            {
                dt.Columns.Add("Tổng tiền");
            }
            if (!dt.Columns.Contains("Ghi chú"))
            {
                dt.Columns.Add("Ghi chú");
            }

            //foreach (var column in dtgChiTietPhieuThue.Columns)
            //{
            //    column.Width = new DataGridLength(0.8, DataGridLengthUnitType.Star);
            //}

            dtgChiTietPhieuThue.ItemsSource = dt.DefaultView;
        }
        private void txtMaPhong_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnThemPhong_Click(object sender, RoutedEventArgs e)
        {
            // add to main list

            // display datagrid
            HienThiChiTietPhieuThue();
        }
    }

    public class PhieuThueBinding
    {

        public String MaPhong
        {
            get;
            set;
        }
        public String TenPhong
        {
            get;
            set;
        }
        public String MaLoaiPhong
        {
            get;
            set;
        }
        public Double DonGia
        {
            get;
            set;
        }
        public Double TongTien
        {
            get;
            set;
        }

    }
}
