﻿using System;
using System.Collections.Generic;

#nullable disable

namespace API_WebSach.Models
{
    public partial class TinTuc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
