using BUS;
using DTO;
using Npgsql;
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
    /// Interaction logic for UserControlQuanLyPhieuThue.xaml
    /// </summary>
    public partial class UserControlQuanLyPhieuThue : UserControl
    {
        public UserControlQuanLyPhieuThue()
        {
            InitializeComponent();

            HienThiDanhSachPhieuThue();
        }

        private void HienThiDanhSachPhieuThue()
        {
            // test select data 

            NpgsqlDataAdapter da = BUS.LapPhieuThueBUS.LayDanhSachPhieuThue();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            try
            {
                da.Fill(ds);
                dt = ds.Tables[0];
                dgvDanhSachPhieuThue.ItemsSource = dt.DefaultView;

                // create point debug here
                //while (true) ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnLapPhieuThue_Click(object sender, RoutedEventArgs e)
        {
            UserControl usercontrol = new UserControlChonKhachHangThue();
            Grid gridmain = ((Grid)this.Parent);
            gridmain.Children.Clear();
            gridmain.Children.Add(usercontrol);
        }

        private void LayDanhSachPhieuThueTimKiem()
        {
            PhieuThueDTO pt = new PhieuThueDTO();

            pt.MaPhieuThue = txtboxMaPhieuThue.Text;
            pt.MaKhachHang = txtboxMaKhachHangPhieuThue.Text;
            pt.HoTenKhachHang = txtboxTenKhachHangPhieuThue.Text;
            //pt.NgayLap = DateTime.Parse(txtboxNgayLapPhieuThue.Text);
            //DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
            //                           System.Globalization.CultureInfo.InvariantCulture);

            //pt.NgayLap = DateTime.ParseExact(txtboxNgayLapPhieuThue.Text, "d", null);

            NpgsqlDataAdapter da = BUS.LapPhieuThueBUS.TimKiemPhieuThue(pt);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dgvDanhSachPhieuThue.ItemsSource = dt.DefaultView;

                // create point debug here
                //while (true) ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LayDanhSachPhieuThueTimKiemTheoNgayLap()
        {
            PhieuThueDTO pt = new PhieuThueDTO();

            pt.MaPhieuThue = txtboxMaPhieuThue.Text;
            pt.MaKhachHang = txtboxMaKhachHangPhieuThue.Text;
            pt.HoTenKhachHang = txtboxTenKhachHangPhieuThue.Text;
            //pt.NgayLap = DateTime.Parse(txtboxNgayLapPhieuThue.Text);
            //DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
            //                           System.Globalization.CultureInfo.InvariantCulture);

            //pt.NgayLap = DateTime.ParseExact(txtboxNgayLapPhieuThue.Text, "d", null);
            String s = dpkNgayLap.SelectedDate.ToString();
            pt.NgayLap = DateTime.ParseExact(Convert.ToDateTime(dpkNgayLap.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture);

            NpgsqlDataAdapter da = BUS.LapPhieuThueBUS.TimKiemPhieuThueTheoNgayLap(pt);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dgvDanhSachPhieuThue.ItemsSource = dt.DefaultView;

                // create point debug here
                //while (true) ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtboxMaPhieuThue_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachPhieuThueTimKiem();
        }

        private void txtboxMaKhachHangPhieuThue_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachPhieuThueTimKiem();
        }

        private void txtboxTenKhachHangPhieuThue_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachPhieuThueTimKiem();
        }

        private void txtboxNgayLapPhieuThue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dpkNgayLap_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpkNgayLap.Text.ToString() != "")
            {
                LayDanhSachPhieuThueTimKiemTheoNgayLap();
            }
            else
            {
                LayDanhSachPhieuThueTimKiem();
            }
        }

        private void btnCapNhatPhieuThue_Click(object sender, RoutedEventArgs e)
        {
            // date format theo kiểu MM-DD-YYYY
            // pt.NgayLap = DateTime.ParseExact(Convert.ToDateTime(dpkNgayLap.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",CultureInfo.InvariantCulture);

            DateTime test = DateTime.ParseExact(Convert.ToDateTime(dpkNgayLap.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture);

            List<BaoCaoDoanhThuPhongDTO> dsbcdtp =
               BaoCaoDoanhThuPhongBUS.LayDanhSachBaoCaoDoanhThuPhong(test, test);

            if (dsbcdtp == null)
            {
                // không có phòng được thuê trong thời gian đó
                return;
            }

            // process here


        }
    }
}
