using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class ThamGium
    {
        public int MaSach { get; set; }
        public int MaTacGia { get; set; }
        public string VaiTro { get; set; }
        public string Vitri { get; set; }

        public virtual Sach MaSachNavigation { get; set; }
        public virtual TacGium MaTacGiaNavigation { get; set; }
    }
}
