using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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
        //private ObservableCollection<ChiTietPhieuThueDTO> dsphieuthue = new ObservableCollection<ChiTietPhieuThueDTO>();
        private List<ChiTietPhieuThueDTO> dschitietphieuthue = new List<ChiTietPhieuThueDTO>();
        private PhongDTO phongDuocChon = null;
        private DataTable dt = new DataTable();
        private NhanVienDTO nhanvien = new NhanVienDTO();

        public UserControlLapPhieuThue()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("pt-BR");
            txtboxNgayLapPhieuThue.Text = DateTime.Today.ToString("d", culture);
            dpkNgayThue.SelectedDate = DateTime.Today;
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


            nhanvien.MaNhanVien = "NV001";
            nhanvien.TenNhanVien = "Ngọc Hiền";

            txtTenNhanVien.Text = nhanvien.TenNhanVien;
            dpkNgayThue.Text = DateTime.Today.ToString("MM/dd/yyyy", culture);

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
            Boolean kt = true;

            // prepare insert phieuthue
            PhieuThueDTO pt = new PhieuThueDTO();
            pt.MaPhieuThue = txtboxMaPhieuThue.Text.ToString();
            pt.MaKhachHang = txtboxMaKhachHangPhieuThue.Text.ToString();
            pt.MaNhanVien = nhanvien.MaNhanVien;
            pt.NgayLap = DateTime.Today;
            //pt.NgayLap = DateTime.ParseExact(Convert.ToDateTime(
            //    txtboxNgayLapPhieuThue.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",
            //                              CultureInfo.InvariantCulture);
            pt.SoLuongPhong = dschitietphieuthue.Count;
            pt.TinhTrang = true;

            //insert phieuthue
            kt = LapPhieuThueBUS.ThemPhieuThue(pt);

            // insert danhsachphieuthue
            kt = LapPhieuThueBUS.ThemDanhSachChiTietPhieuThue(dschitietphieuthue);

            if (kt == false)
            {
                MessageBox.Show("Lập phiếu thuê không thành công");
                // error did'n insert database
            }
            else
            {
                MessageBox.Show("Lập phiếu thuê thành công");
                // dialog
                // Lập phiếu thuê thành công
                // shoe dialog insert success
            }

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

            dtgChiTietPhieuThue.ItemsSource = dt.DefaultView;
        }

        private void btnThemPhong_Click(object sender, RoutedEventArgs e)
        {

            if (phongDuocChon == null ||
                    txtboxMaKhachHangPhieuThue.Text.ToString() == "" ||
                    TxtTenPhong.Text.ToString() == "" ||
                    dpkNgayThue.Text.ToString() == "" ||
                    dpkNgayTra.Text.ToString() == "")
            {
                // dialog
                // thông báo ko cho để trống 
                // note error not empty
                MessageBox.Show("Nhập Đủ Thông Tin Phiếu Thuê");
                return;
            }

            if (phongDuocChon.LoaiTinhTrang)
            {
                // dialog
                // phòng đã được thuê
                // phong not empty
                MessageBox.Show("Phòng Không Trống");
                return;
            }

            // add to main list
            ChiTietPhieuThueDTO ctpt = new ChiTietPhieuThueDTO();
            ctpt.MaPhieuThue = txtboxMaPhieuThue.Text.ToString();
            ctpt.MaPhong = txtMaPhong.Text.ToString();
            ctpt.TenPhong = TxtTenPhong.Text.ToString();
            ctpt.MaLoaiPhong = phongDuocChon.MaLoaiPhong;
            ctpt.DonGia = phongDuocChon.DonGia;
            ctpt.NgayThue = DateTime.ParseExact(Convert.ToDateTime(dpkNgayThue.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture);
            ctpt.NgayTra = DateTime.ParseExact(Convert.ToDateTime(dpkNgayTra.Text).ToString("dd/MM/yyyy"), "dd/MM/yyyy",
                                         CultureInfo.InvariantCulture);

            int numDaysDiff = Math.Abs(ctpt.NgayTra.Subtract(ctpt.NgayThue).Days);
            ctpt.TongTien = numDaysDiff * ctpt.DonGia;
            ctpt.GhiChu = txtGhiChu.Text.ToString();


            // check validate MaPhong, TenPhong
            PhongDTO ktphong = BUS.LapPhieuThueBUS.LayPhongTheoMaPhong(ctpt.MaPhong);
            if (ktphong == null)
            {
                // dialog
                MessageBox.Show("Mã Phòng Không Tồn Tại");
                // mã phòng không có trong hệ thống
                // throw dialog error MaPhong be incorrect
            }

            ktphong = BUS.LapPhieuThueBUS.LayPhongTheoTenPhong(ctpt.TenPhong);
            if (ktphong == null)
            {
                // dialog
                MessageBox.Show("Tên Phòng Không Tồn Tại");
                // tên phòng không có trong hệ thống
                // throw dialog error TenPhong be incorrect
            }

            // check validate NgayDen, NgayTra
            if (ctpt.NgayTra.Subtract(ctpt.NgayThue).Days < 0)
            {
                // dialog
                // ngày thuê > ngày trả 
                MessageBox.Show("Ngày Trả Phải Lớn Hơn Ngày Thuê");
                // 
            }

            // kiểm tra xem phòng đã được thêm vào danh sách hay chưa, nếu rồi thì không được thêm
            if (dschitietphieuthue.Exists(x => x.MaPhong == phongDuocChon.MaPhong))
            {
                // dialog
                // Phòng đã thêm vào danh sách
                Debug.Print("Phòng đã thêm vào danh sách");
                return;
            }

            // add list original
            dschitietphieuthue.Add(ctpt);

            // display datagrid
            HienThiChiTietPhieuThue(ctpt);

            txtGhiChu.Text = "";
            txtMaPhong.Text = "";
            TxtTenPhong.Text = "";
            txtTinhTrangPhong.Text = "";

        }
        private void HienThiChiTietPhieuThue(ChiTietPhieuThueDTO ctpt)
        {
            //dt.Rows.Add("PT0002", "Phòng GOLD", "LP003", 500000);
            dt.Rows.Add(ctpt.MaPhong, ctpt.TenPhong, ctpt.MaLoaiPhong, ctpt.DonGia,
                ctpt.NgayThue, ctpt.NgayTra, ctpt.TongTien, ctpt.GhiChu);
        }

        private void TxtTenPhong_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhongDTO phong = BUS.LapPhieuThueBUS.LayPhongTheoTenPhong(TxtTenPhong.Text.ToString());

            if (phong != null)
            {
                txtMaPhong.Text = phong.MaPhong;

                TxtTenPhong.Text = phong.TenPhong;
                if (phong.LoaiTinhTrang)
                {
                    txtTinhTrangPhong.Text = "Đã thuê";
                }
                else
                {
                    txtTinhTrangPhong.Text = "Trống";
                }

                phongDuocChon = phong;
            }
            else
            {
                txtMaPhong.Text = "";
                txtTinhTrangPhong.Text = "";
                phongDuocChon = null;
            }
        }

        private void txtMaPhong_TextChanged(object sender, TextChangedEventArgs e)
        {
            PhongDTO phong = BUS.LapPhieuThueBUS.LayPhongTheoMaPhong(txtMaPhong.Text.ToString());

            if (phong != null)
            {
                TxtTenPhong.Text = phong.TenPhong;
                if (phong.LoaiTinhTrang)
                {
                    txtTinhTrangPhong.Text = "Đã thuê";
                }
                else
                {
                    txtTinhTrangPhong.Text = "Trống";
                }


                phongDuocChon = phong;
            }
            else
            {
                TxtTenPhong.Text = "";
                txtTinhTrangPhong.Text = "";
                phongDuocChon = null;
            }
        }
    }
}
