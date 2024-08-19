using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class HOADON
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã Hóa Đơn")]
        public string MAHD { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Mã Ngày Hoá Đơn")]

        public string NGAYHD { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Mã Khách Hàng")]
        public string MAKH { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Trị Gía")]
        public string TRIGIA { get; set; }
    }
}