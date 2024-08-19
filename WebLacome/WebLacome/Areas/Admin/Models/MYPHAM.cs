using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class MYPHAM
    {
        [Required(ErrorMessage = "Bắt buộc nhập Mã Mỹ Phẩm")]
        public string MAMP { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Tên Mỹ Phẩm")]
        public string TENMP { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập chọn ảnh")]
        public string ANH { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Ngày Sản Xuất")]
        public string NGAYSX { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Thời Gian Bảo Hành")]

        public string TGBH { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Mã Loại")]

        public string MALOAI { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Nhà Sản Xuất")]
        public string NSX { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Đơn Vị Tính")]
        public string DVT { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập Giá")]
        public int GIA { get; set; }
    }
}