using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class KHACHHANG
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã KH")]
        public string MAKH { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Tên KH")]
        public string TENKH { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Địa Chỉ")]
        public string DCHI { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Điện Thoại")]
        public string DTHOAI { get; set; }
    }
}