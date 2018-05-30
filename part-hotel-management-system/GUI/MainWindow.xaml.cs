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
using MahApps.Metro.Controls;
using Npgsql;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnThemPhong_Click(object sender, RoutedEventArgs e)
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

                //while (true) ;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
