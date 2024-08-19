using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebLacome.Models;
using WebLacome.Areas.Admin.Models;

namespace WebLacome.Models
{
    public class MyPhamController : Controller
    {


        connectGioHang connectGH = new connectGioHang();
        List<GioHang> listGioHang = new List<GioHang>();
        public ActionResult ShowProducts()
        {
            List<MyPham> listMyPham = new List<MyPham>();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    string conStr = "Data Source=LAPTOP-A054QLV3;Initial Catalog=QL_MYPHAM1;Integrated Security=True";
                    con.ConnectionString = conStr;
                    string sql = "Select MAMP ,TenMP, ANH, GIA From MYPHAM";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var mp = new MyPham();
                        mp.MAMP = row["MAMP"].ToString();
                        mp.TENMP = row["TENMP"].ToString();
                        mp.ANH = row["ANH"].ToString();
                        mp.GIA = (int)row["GIA"];
                        listMyPham.Add(mp);
                    }
                }
                return View(listMyPham);
            }
            catch
            {
                throw;
            }
        }

        public ActionResult ShowCategoryList()
        {
            List<LoaiMP> listMP = new List<LoaiMP>();
            ConnectLoaiMP cnLoaiMP = new ConnectLoaiMP();
            listMP = cnLoaiMP.getData();
            return View(listMP);
        }

        public ActionResult ShowListMPByCTG(string MALOAI)
        {
            ConnectLoaiMP cnLMP = new ConnectLoaiMP();
            List<MyPham> list = new List<MyPham>();
            list = cnLMP.ShowListMPByCTG(MALOAI);
            return View(list);
        }

        public ActionResult KhamPha() 
        {
            return View();
        }
        public List<MyPham> LayMPTL(string maloai)
        {
            List<MyPham> listMyPham = new List<MyPham>();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    string conStr = "Data Source=LAPTOP-A054QLV3;Initial Catalog=QL_MYPHAM1;Integrated Security=True";
                    con.ConnectionString = conStr;
                    string sql = "select MAMP,TenMP, ANH, GIA from MYPHAM where MALOAI = '" + maloai + "'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var mp = new MyPham();
                        mp.MAMP = row["MAMP"].ToString();
                        mp.TENMP = row["TENMP"].ToString();
                        mp.ANH = row["ANH"].ToString();
                        mp.GIA = (int)row["GIA"];
                        listMyPham.Add(mp);
                    }
                   
                }
            }
            catch
            {
                throw;
            }
            return listMyPham;
        }
        public ActionResult Home()
        {

            ViewBag.taytrang = LayMPTL("CLEAN_A").Take(4);
            ViewBag.nuocthan = LayMPTL("SERUM_A").Take(4);
           
            return View();
        }
        //
        // GET: /MyPham/

        public ActionResult Details(string MAMP)
        {
            ConnectMyPham mp = new ConnectMyPham();
            List<MyPham> obj = mp.getMyPham(MAMP);
            return View(obj.FirstOrDefault());
        }
        ConnectMyPham mp = new ConnectMyPham();
        List<MyPham> products = new List<MyPham>();
        public ActionResult SearchProducts()
        {
            products = mp.getData();
            return View(products);
        }
        [HttpPost]
        public ActionResult SearchProducts(string txtTenMP)
        {
            products = mp.searchMyPham(txtTenMP);
            ViewBag.mess = "";
            if (products.Count == 0)
            {
                ViewBag.mess = "Không tìm thấy";
            }
            ViewBag.txtTenSP = txtTenMP;
            return View(products);
        }

    
        public ActionResult HomeGioHang()
        {
            if (Session["User"] == null)
                return RedirectToAction("DangNhap", "User");
            else
            {
                ViewBag.User = Session["User"];
                string TenDN = Session["User"].ToString();
                listGioHang = connectGH.layGioHang(TenDN);
                Session["GioHang"] = listGioHang;
                return View(listGioHang);
            }
        }
        public ActionResult AddGioHang(string MaMP)
        {
            if (Session["User"] == null)
                return RedirectToAction("DangNhap", "User");
            else
            {
                string TenDN = Session["User"].ToString();
                int rs = connectGH.ThemGioHang(MaMP, TenDN);
                return RedirectToAction("ShowProducts", "MyPham");
            }
        }
        public ActionResult DeleteGioHang(string MaMP)
        {
            string TenDN = Session["User"].ToString();
            int rs = connectGH.XoaGioHang(MaMP, TenDN);
            return RedirectToAction("HomeGioHang");
        }
        public ActionResult UpdateSoLuongGH(string MAMP, FormCollection f)
        {
            int SoLuong = int.Parse(f["SoLuong"].ToString());
            string TenDN = Session["User"].ToString();
            int rs = connectGH.UpdateSoLuong(MAMP, TenDN, SoLuong);
            return RedirectToAction("HomeGioHang");
        }

        public ActionResult ViewTongSoLuong()
        {
            ViewBag.TongSL = TongSoLuong();
            return PartialView();
        }
        public int TongSoLuong()
        {
            int tsl = 0;
            var listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tsl = listGioHang.Sum(sp => sp.SOLUONG);
            }
            return tsl;
        }

        public ActionResult ThanhToanThanhCong()
        {
            return View();
        }

        public ActionResult XuLyThanhToan()
        {
            try
            {
                string MAHD = TaoMaHoaDonMoi();
                string MAKH;

                var listGioHang = Session["GioHang"] as List<GioHang>;

                int TRIGIA = (int)listGioHang.Sum(item => item.THANHTIEN);

                // Kiểm tra xem đã có MAKH trong session chưa, nếu chưa thì tạo mới
                if (Session["MAKH"] == null)
                {
                    MAKH = TaoMaKhachHangMoi();
                    Session["MAKH"] = MAKH;

                    // Thêm thông tin khách hàng mới vào bảng KHACHHANG
                    connectGioHang KhachHangMNG = new connectGioHang();
                    KhachHangMNG.ThemKhachHangMoi(MAKH, "thanhtu");
                }
                else
                {
                    MAKH = Session["MAKH"].ToString();
                }

                connectGioHang gioHangManager = new connectGioHang();
                gioHangManager.LuuChiTietHoaDon(MAHD, listGioHang, MAKH, TRIGIA);

                gioHangManager.XoaTatCaGioHang("TENDN");

                return RedirectToAction("ThanhToanThanhCong");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
                return View("Error");
            }
        }


        private string TaoMaHoaDonMoi()
        {
            string MAHD = "HD2" + DateTime.Now.ToString("ss");

            return MAHD;
        }

        private string TaoMaKhachHangMoi()
        {
            string MAKH = "KH2" + DateTime.Now.ToString("ss");

            return MAKH;
        }

    }
}
