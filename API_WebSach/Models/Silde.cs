using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class Silde
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }
    }
}
