using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class NhaXuatBan
    {
        public NhaXuatBan()
        {
            Saches = new HashSet<Sach>();
        }

        public int Id { get; set; }
        public string TenNxb { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
