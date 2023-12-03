using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class Sach
    {
        public Sach()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ThamGia = new HashSet<ThamGium>();
        }

        public int Id { get; set; }
        public int? DanhMucId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Sale { get; set; }
        public string MoTa { get; set; }
        public string KichThuoc { get; set; }
        public string TrongLuong { get; set; }
        public int? NhaCungCapId { get; set; }
        public int? SoTrang { get; set; }
        public int? NhaXuatBanId { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public int? SoLuongTon { get; set; }
        public string MetaTitle { get; set; }
        public string MoreImages { get; set; }
        public DateTime? TopHot { get; set; }
        public int? ViewCount { get; set; }
        public bool? Status { get; set; }

        public virtual DanhMucSp DanhMuc { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<ThamGium> ThamGia { get; set; }
    }
}
