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

            // LayDanhSachKhachHang();
        }

        private void LayDanhSachKhachHang()
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

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            UserControl usercontrol = new UserControlQuanLyPhieuThue();
            Grid gridmain = ((Grid)this.Parent);
            gridmain.Children.Clear();
            gridmain.Children.Add(usercontrol);
        }

        private void btnLapPhieuThue_Click(object sender, RoutedEventArgs e)
        {
            UserControl usercontrol = new UserControlLapPhieuThue();
            Grid gridmain = ((Grid)this.Parent);
            gridmain.Children.Clear();
            gridmain.Children.Add(usercontrol);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
