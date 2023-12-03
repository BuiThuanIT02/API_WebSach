using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int Id { get; set; }
        public string GroupId { get; set; }
        public string TaiKhoan1 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool Status { get; set; }
        public string FullName { get; set; }

        public virtual UserGroup Group { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
