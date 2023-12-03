using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
