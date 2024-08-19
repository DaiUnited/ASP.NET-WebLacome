using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class CHITIETHOADON
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã Hóa Đơn")]
        public string MAHD { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Mã Mỹ Phẩm")]
        public string MAMP { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Số Lượng")]

        public int SOLUONG { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Đơn Gía")]
        public string DONGIA { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Thành Tiền")]
        public string THANHTIEN { get; set; }
    }
}