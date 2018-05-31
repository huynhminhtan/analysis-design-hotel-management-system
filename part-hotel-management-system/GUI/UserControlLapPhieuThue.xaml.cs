﻿using System;
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
        public UserControlLapPhieuThue()
        {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("pt-BR");
            txtboxNgayLapPhieuThue.Text = DateTime.Today.ToString("d", culture);
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            UserControl usercontrol = new UserControlQuanLyPhieuThue();
            Grid gridmain = ((Grid)this.Parent);
            gridmain.Children.Clear();
            gridmain.Children.Add(usercontrol);
        }
    }
}