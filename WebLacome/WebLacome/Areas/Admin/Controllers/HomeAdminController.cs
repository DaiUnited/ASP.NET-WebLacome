using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebLacome.Areas.Admin.Models;
namespace WebLacome.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        ConnectProduct cn = new ConnectProduct();
        List<MYPHAM> listProduct = new List<MYPHAM>();

        ConnectLoaiMP cnmp = new ConnectLoaiMP();
        List<LOAIMP> listLoaiMP = new List<LOAIMP>();

        ConnectHoaDon cnhd = new ConnectHoaDon();
        List<HOADON> listHoaDon = new List<HOADON>();

        ConnectKhachHang cnkh = new ConnectKhachHang();
        List<KHACHHANG> listKH = new List<KHACHHANG>();

        ConnectCTHD cthd = new ConnectCTHD();
        List<CHITIETHOADON> listCTHD = new List<CHITIETHOADON>();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ShowProduct(string search = "")
        {
            List<MYPHAM> products = cn.getData().Where(product => product.TENMP.ToLower().Contains(search.ToLower()) || product.MALOAI.ToLower().Contains(search.ToLower())).ToList();
            ViewBag.search = search;
            return View(products);
        }
        public ActionResult Edit(string id)
        {

            List<MYPHAM> mp = cn.getData();

            var editedEmployee = mp.Find(emp => emp.MAMP.Trim() == id.Trim());


            return View(editedEmployee);
        }

        [HttpPost]
        public ActionResult Edit(string id, MYPHAM mp)
        {
            if (ModelState.IsValid)
            {

                bool response = cn.UpdateEmployee(mp);

                if (response)
                {
                    TempData["message"] = "Data has been updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("ShowProduct");
                }
            }

            return View();
        }
        public ActionResult DeleteProduct(string MaMyPham)
        {
            int rs = cn.DelectProduct(MaMyPham);
            ViewBag.KiemTraXoa = rs;
            return RedirectToAction("ShowProduct");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MYPHAM mp)
        {
            bool response = cn.AddMyPham(mp);

            if (response)
            {
                TempData["message"] = "Data has been inserted successfully";
                ModelState.Clear();
                return RedirectToAction("ShowProduct");
            }
            return View();
        }

        public ActionResult Details(string id)
        {

            List<MYPHAM> mp = cn.getData();

            var detail = mp.Find(emp => emp.MAMP.Trim() == id.Trim());


            return View(detail);
        }


        //loai
        public ActionResult ShowLoaiMP(string search = "")
        {
            List<LOAIMP> loai = cnmp.getData().Where(product => product.MALOAI.ToLower().Contains(search.ToLower())).ToList();
            ViewBag.search = search;
            return View(loai);
        }

        public ActionResult CreateLoai()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLoai(LOAIMP Loai)
        {
            bool response = cnmp.AddLoai(Loai);

            if (response)
            {
                TempData["message"] = "Data has been inserted successfully";
                ModelState.Clear();
                return RedirectToAction("ShowLoaiMP");
            }
            return View();
        }
        public ActionResult EditLoai(string id)
        {

            List<LOAIMP> mp = cnmp.getData();

            var editedEmployee = mp.Find(emp => emp.MALOAI.Trim() == id.Trim());


            return View(editedEmployee);
        }

        [HttpPost]
        public ActionResult EditLoai(string id, LOAIMP loai)
        {
            if (ModelState.IsValid)
            {

                bool response = cnmp.UpdateLoaiMP(loai);

                if (response)
                {
                    TempData["message"] = "Data has been updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("ShowLoaiMP");
                }
            }

            return View();
        }

        public ActionResult DeleteLoaiMP(string MaLoaiMP)
        {
            int rs = cnmp.DelectLoai(MaLoaiMP);

            ViewBag.KiemTraXoa = rs;
            return RedirectToAction("ShowLoaiMP");
        }


        //hoadon
        public ActionResult ShowHoaDon(string search = "")
        {
            List<HOADON> hoadon = cnhd.getData().Where(product => product.MAHD.ToLower().Contains(search.ToLower())).ToList();
            ViewBag.search = search;
            return View(hoadon);
        }

        public ActionResult CreateHD()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHD(HOADON hd)
        {
            bool response = cnhd.AddHoaDon(hd);

            if (response)
            {
                TempData["message"] = "Data has been inserted successfully";
                ModelState.Clear();
                return RedirectToAction("ShowHoaDon");
            }
            return View();
        }


        public ActionResult EditHD(string id)
        {

            List<HOADON> mp = cnhd.getData();

            var editedEmployee = mp.Find(emp => emp.MAHD.Trim() == id.Trim());


            return View(editedEmployee);
        }

        [HttpPost]
        public ActionResult EditHD(string id, HOADON hd)
        {
            if (ModelState.IsValid)
            {

                bool response = cnhd.UpdateHD(hd);

                if (response)
                {
                    TempData["message"] = "Data has been updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("ShowHoaDon");
                }
            }

            return View();
        }

        public ActionResult DeleteHD(string MaHD)
        {
            int rs = cnhd.DelectHD(MaHD);

            ViewBag.KiemTraXoa = rs;
            return RedirectToAction("ShowHoaDon");
        }

        //khachhang
        public ActionResult ShowKhachHang(string search = "")
        {
            List<KHACHHANG> khachhang = cnkh.getData().Where(product => product.MAKH.ToLower().Contains(search.ToLower())).ToList();
            ViewBag.search = search;
            return View(khachhang);
        }
        public ActionResult CreateKH()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateKH(KHACHHANG kh)
        {
            bool response = cnkh.AddKhachHang(kh);

            if (response)
            {
                TempData["message"] = "Data has been inserted successfully";
                ModelState.Clear();
                return RedirectToAction("ShowKhachHang");
            }
            return View();
        }


        public ActionResult EditKH(string id)
        {

            List<KHACHHANG> mp = cnkh.getData();

            var editedEmployee = mp.Find(emp => emp.MAKH.Trim() == id.Trim());


            return View(editedEmployee);
        }

        [HttpPost]
        public ActionResult EditKH(string id, KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {

                bool response = cnkh.UpdateKH(kh);

                if (response)
                {
                    TempData["message"] = "Data has been updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("ShowKhachHang");
                }
            }

            return View();
        }

        public ActionResult DeleteKH(string MaKH)
        {
            int rs = cnkh.DelectKH(MaKH);

            ViewBag.KiemTraXoa = rs;
            return RedirectToAction("ShowKhachHang");
        }

        //cthoadon
        public ActionResult ShowCTHoaDon(string search = "")
        {
            List<CHITIETHOADON> CTHoaDon = cthd.getData().Where(product => product.MAHD.ToLower().Contains(search.ToLower()) || product.MAMP.ToLower().Contains(search.ToLower())).ToList();
            ViewBag.search = search;
            return View(CTHoaDon);
        }

        //public ActionResult CreateCTHD()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateCTHD(CHITIETHOADON ct)
        //{
        //    bool response = cthd.AddCTHoaĐon(ct);

        //    if (response)
        //    {
        //        TempData["message"] = "Data has been inserted successfully";
        //        ModelState.Clear();
        //        return RedirectToAction("ShowCTHoaDon");
        //    }
        //    return View();
        //}

        public ActionResult DetailsLoai(string id)
        {

            List<LOAIMP> mp = cnmp.getData();

            var detail = mp.Find(emp => emp.MALOAI.Trim() == id.Trim());


            return View(detail);
        }
    }
}