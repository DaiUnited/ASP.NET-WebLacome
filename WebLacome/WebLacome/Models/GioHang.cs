using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebLacome.Models;
using WebLacome.Controllers;

namespace WebLacome.Models
{
    public class GioHang
    {
        public string TENDN { get; set; }
        public string MAMP { get; set; }
        public string TENMP { get; set; }
        public string ANH { get; set; }
        public float GIA { get; set; }
        public int SOLUONG { get; set; }
        public float THANHTIEN { get; set; }
    }
}