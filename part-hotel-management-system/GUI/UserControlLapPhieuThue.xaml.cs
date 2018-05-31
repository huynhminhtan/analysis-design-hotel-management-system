using DTO;
using System;
using System.Collections.Generic;
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
    }
}
