using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebLacome.Areas.Admin.Models;
namespace WebLacome.Models
{
    public class connectGioHang
    {
        public string conStr = "Data Source=LAPTOP-A054QLV3;Initial Catalog=QL_MYPHAM1;Integrated Security=True";
        List<GioHang> lstGioHang = new List<GioHang>();
        public List<GioHang> layGioHang(string TENDN)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "select * from GioHang where TENDN='" + TENDN + "'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var gh = new GioHang();
                        gh.TENDN = row["TENDN"].ToString();
                        gh.MAMP = row["MAMP"].ToString();
                        gh.TENMP = row["TENMP"].ToString();
                        gh.ANH = row["ANH"].ToString();
                        gh.GIA = float.Parse(row["GIA"].ToString());
                        gh.SOLUONG = int.Parse(row["SOLUONG"].ToString());
                        gh.THANHTIEN = float.Parse(row["THANHTIEN"].ToString());
                        lstGioHang.Add(gh);
                    }
                }
                return lstGioHang;
            }
            catch
            {
                throw;
            }
        }
        public int ThemGioHang(string MaMP, string TENDN)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "exec ThemGioHang'" + MaMP + "','" + TENDN + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;

        }
        public int XoaGioHang(string MaMP, string TENDN)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "delete GioHang where TENDN='" + TENDN + "' and MAMP='" + MaMP + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;

        }
        public int UpdateSoLuong(string MAMP, string TENDN, int SoLuong)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "exec UpdateSoLuong'" + MAMP + "','" + TENDN + "'," + SoLuong + "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            int rs = 0;
            rs = cmd.ExecuteNonQuery();
            return rs;
        }
        public void XoaTatCaGioHang(string TenDN)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conStr;
            con.Open();
            string sql = "delete from GioHang where TENDN='" + TenDN + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public int LuuChiTietHoaDon(string MAHD, List<GioHang> gioHang, string MAKH, int TRIGIA)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Kiểm tra xem mã hóa đơn đã tồn tại hay chưa
                    string checkExistSql = "SELECT COUNT(*) FROM HOADON WHERE MAHD = @MAHD";
                    SqlCommand checkExistCmd = new SqlCommand(checkExistSql, con);
                    checkExistCmd.Parameters.AddWithValue("@MAHD", MAHD);

                    int existCount = (int)checkExistCmd.ExecuteScalar();

                    if (existCount == 0)
                    {
                        // Mã hóa đơn không tồn tại, tạo mã hóa đơn mới
                        string insertHoaDonSql = "INSERT INTO HOADON (MAHD, NGAYHD, MAKH, TRIGIA) " +
                                                 "VALUES (@MAHD, @NGAYHD, @MAKH, @TRIGIA)";
                        SqlCommand insertHoaDonCmd = new SqlCommand(insertHoaDonSql, con);
                        insertHoaDonCmd.Parameters.AddWithValue("@MAHD", MAHD);
                        insertHoaDonCmd.Parameters.AddWithValue("@NGAYHD", DateTime.Now.ToString("dd/MM/yyyy"));
                        insertHoaDonCmd.Parameters.AddWithValue("@MAKH", MAKH);
                        insertHoaDonCmd.Parameters.AddWithValue("@TRIGIA", TRIGIA);

                        insertHoaDonCmd.ExecuteNonQuery();
                    }

                    // Thêm chi tiết hóa đơn với mã hóa đơn mới
                    foreach (var item in gioHang)
                    {
                        string insertSql = "INSERT INTO CHITIETHD (MAHD, MAMP, SOLUONG, DONGIA, THANHTIEN) " +
                                           "VALUES (@MAHD, @MAMP, @SOLUONG, @DONGIA, @THANHTIEN)";

                        SqlCommand cmd = new SqlCommand(insertSql, con);
                        cmd.Parameters.AddWithValue("@MAHD", MAHD);
                        cmd.Parameters.AddWithValue("@MAMP", item.MAMP);
                        cmd.Parameters.AddWithValue("@SOLUONG", item.SOLUONG);
                        cmd.Parameters.AddWithValue("@DONGIA", item.GIA);
                        cmd.Parameters.AddWithValue("@THANHTIEN", item.THANHTIEN);

                        cmd.ExecuteNonQuery();
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine("Lỗi: " + ex.Message);

                throw;
            }
        }

        public int ThemKhachHangMoi(string MAKH, string TENDN)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Lấy thông tin từ bảng TaiKhoan
                    string selectTaiKhoanSql = "SELECT HOTEN, EMAIL, SDT FROM TaiKhoan WHERE TENDN = @TENDN";
                    SqlCommand selectTaiKhoanCmd = new SqlCommand(selectTaiKhoanSql, con);
                    selectTaiKhoanCmd.Parameters.AddWithValue("@TENDN", TENDN);

                    string HOTEN, EMAIL, SDT;

                    using (SqlDataReader reader = selectTaiKhoanCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            HOTEN = reader["HOTEN"].ToString();
                            EMAIL = reader["EMAIL"].ToString();
                            SDT = reader["SDT"].ToString();
                        }
                        else
                        {
                            // Xử lý trường hợp không tìm thấy thông tin tài khoản
                            throw new Exception("Không tìm thấy thông tin tài khoản.");
                        }
                    }

                    // Thêm thông tin khách hàng mới vào bảng KHACHHANG
                    string insertKhachHangSql = "INSERT INTO KHACHHANG (MAKH, TENKH, DCHI, DTHOAI) " +
                                                "VALUES (@MAKH, @TENKH, @DCHI, @DTHOAI)";
                    SqlCommand insertKhachHangCmd = new SqlCommand(insertKhachHangSql, con);
                    insertKhachHangCmd.Parameters.AddWithValue("@MAKH", MAKH);
                    insertKhachHangCmd.Parameters.AddWithValue("@TENKH", HOTEN);
                    insertKhachHangCmd.Parameters.AddWithValue("@DCHI", EMAIL);
                    insertKhachHangCmd.Parameters.AddWithValue("@DTHOAI", SDT);

                    insertKhachHangCmd.ExecuteNonQuery();
                }

                return 1;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine("Lỗi: " + ex.Message);

                throw;
            }
        }

    }
}