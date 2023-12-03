using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            Saches = new HashSet<Sach>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
