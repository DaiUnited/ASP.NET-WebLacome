using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLacome.Areas.Admin.Models;
using WebLacome.Models;
namespace WebLacome.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan tkdk)
        {
            UserDB db = new UserDB();
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Check exist
            if (db.isExisted(tkdk.TENDN, tkdk.EMAIL))
            {
                ViewBag.AccountExistedError = "This account already exists";
                return View();
            }
            bool success = db.CreateTaiKhoan(tkdk);
            if (success == true)
                return RedirectToAction("Home", "MyPham");
            return View();

        }
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(TaiKhoan loginInfo)
        {
            UserDB userDB = new UserDB();
           
            var userLogin = userDB.GetTaiKhoans().Find(user => user.TENDN.Equals(loginInfo.TENDN) && user.MATKHAU.Equals(loginInfo.MATKHAU));
            Session["User"] = userLogin.TENDN;
            if (userLogin == null)
            {
                ViewBag.Notification = "Wrong email or password";
                return View();
            }

            if (userLogin.VAITRO == "Admin")
                return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });

            // Admin login
            return RedirectToAction("Home", "MyPham");
            
        }
        //GIOHANG
        public ActionResult DangXuat()
        {
            Session.Abandon(); // Xóa toàn bộ session data, hoặc bạn có thể xóa các phần tử cụ thể khỏi session

            return RedirectToAction("DangNhap", "User");
        }
    }
}