﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LapPhieuThueBUS
    {
        public static KhachHangDTO LayKhachHangTheoMaKhachHang(String mkh)
        {
            return KhachHangDAO.LayKhachHangTheoMaKhachHang(mkh);
        }

    }
}
