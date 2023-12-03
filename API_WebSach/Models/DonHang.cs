using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public int Id { get; set; }
        public decimal? TongTien { get; set; }
        public int? DaThanhToan { get; set; }
        public DateTime? NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public int? MaKh { get; set; }
        public int? Status { get; set; }
        public string TenKh { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Moblie { get; set; }

        public virtual TaiKhoan MaKhNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
