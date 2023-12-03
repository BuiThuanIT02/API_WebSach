using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class ChiTietDonHang
    {
        public int MaDonHang { get; set; }
        public int MaSach { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }

        public virtual DonHang MaDonHangNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
    }
}
