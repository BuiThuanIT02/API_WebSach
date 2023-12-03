using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class DanhMucSp
    {
        public DanhMucSp()
        {
            Saches = new HashSet<Sach>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
