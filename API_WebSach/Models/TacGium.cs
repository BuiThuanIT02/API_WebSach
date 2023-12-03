using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class TacGium
    {
        public TacGium()
        {
            ThamGia = new HashSet<ThamGium>();
        }

        public int Id { get; set; }
        public string TenTacGia { get; set; }
        public string Address { get; set; }
        public string TieuSu { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<ThamGium> ThamGia { get; set; }
    }
}
