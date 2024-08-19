using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class LOAIMP
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã Loại")]
        public string MALOAI { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Tên Loại")]
        public string TENLOAI { get; set; }
    }
}