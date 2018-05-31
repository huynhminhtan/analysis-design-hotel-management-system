using DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for UserControlChonKhachHangThue.xaml
    /// </summary>
    public partial class UserControlChonKhachHangThue : UserControl
    {
        public UserControlChonKhachHangThue()
        {
            InitializeComponent();

            // change style datagrid view

            HIenThiDanhSachKhachHang();
        }

        private void HIenThiDanhSachKhachHang()
        {
            // test select data 

            NpgsqlDataAdapter da = BUS.KhachHangLapPhieuThueBUS.LayDanhSachKhachhang();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            try
            {
                da.Fill(ds);
                dt = ds.Tables[0];
                dgvDanhSachKhachHang.ItemsSource = dt.DefaultView;



                // create point debug here
                //while (true) ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LayDanhSachKhachHangTimKiem()
        {
            KhachHangDTO khachhang = new KhachHangDTO();
            khachhang.MaKhachHang = txtboxMaKhachHang.Text;
            khachhang.HoTen = txtboxHoTenKhachHang.Text;
            khachhang.CMND = txtboxCMNDKhachHang.Text;
            khachhang.DiaChi = txtboxDiaChiKhachHang.Text;
            khachhang.Sdt = txtboxSDTKhachHang.Text;
            //khachhang.NgaySinh = txtboxNgaySinhKhachHang.Text;

            NpgsqlDataAdapter da = BUS.KhachHangLapPhieuThueBUS.TimKiemKhachHang(khachhang);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
           
            try
            {
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dgvDanhSachKhachHang.ItemsSource = dt.DefaultView;

                // create point debug here
                //while (true) ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            UserControl usercontrol = new UserControlQuanLyPhieuThue();
            Grid gridmain = ((Grid)this.Parent);
            gridmain.Children.Clear();
            gridmain.Children.Add(usercontrol);
        }

        private void btnLapPhieuThue_Click(object sender, RoutedEventArgs e)
        {
            // select makhachhang was selected
            DataRowView dataRow = (DataRowView)dgvDanhSachKhachHang.SelectedItem;
            string makhachhang = dataRow.Row.ItemArray[0].ToString();

            UserControl usercontrol = new UserControlLapPhieuThue(makhachhang);
            Grid gridmain = ((Grid)this.Parent);
            gridmain.Children.Clear();
            gridmain.Children.Add(usercontrol);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtboxMaKhachHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachKhachHangTimKiem();
        }

        private void txtboxHoTenKhachHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachKhachHangTimKiem();
        }

        private void txtboxCMNDKhachHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachKhachHangTimKiem();
        }

        private void txtboxDiaChiKhachHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachKhachHangTimKiem();
        }

        private void txtboxSDTKhachHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayDanhSachKhachHangTimKiem();
        }
    }
}
