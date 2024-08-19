using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebLacome.Areas.Admin.Models
{
    public class TaiKhoan
    {
        [Required(ErrorMessage = "Username cant be blank")]
        public string TENDN { get; set; }

        public string VAITRO { get; set; }
        [Required(ErrorMessage = "Email cant be blank")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "HoTen cant be blank")]
        public string HOTEN { get; set; }
        public string NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public string SDT { get; set; }
        [Required(ErrorMessage = "Password cant be blank")]
        public string MATKHAU { get; set; }
        [Required(ErrorMessage = "Confirm Password cant be blank")]
        [Compare("MATKHAU", ErrorMessage = "Confirm password do not match")]
        public string XACNHANMK { get; set; }
        public string ANHBIAUSER { get; set; }
    }
}