using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace WebLacome.Areas.Admin.Models
{
    public class LoginVaiTro : ConnectSQL
    {
        //public int LoginVaiTro(string Username, string email, string password)
        //{
        //    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE EMAIL=@Email AND TENDN = @Username AND MATKHAU = @Password";
        //    SqlConnection con = new SqlConnection(conStr);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.Parameters.AddWithValue("@Username", Username);
        //    cmd.Parameters.AddWithValue("@Email", email);
        //    cmd.Parameters.AddWithValue("@Password", password);
        //    int result = (int)cmd.ExecuteScalar();
        //    int kt = 0;
        //    if (result != 0)
        //    {

        //        string query2 = "SELECT COUNT(*) FROM TaiKhoan WHERE  TENDN = @Username and VAITRO='Admin'";
        //        SqlCommand command2 = new SqlCommand(query2, con);
        //        command2.Parameters.AddWithValue("@Username", Username);
        //        kt = (int)command2.ExecuteScalar();
        //        if (kt == 1)
        //            return 1;//Tra ve trang Admin
        //        else
        //            return 2;//Tra ve trang User
        //    }
        //    return kt;
        //}
    }
}