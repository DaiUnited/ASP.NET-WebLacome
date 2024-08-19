using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;

namespace WebLacome.Areas.Admin.Models
{
    public class ConnectProduct : ConnectSQL
    {
        List<MYPHAM> listProduct = new List<MYPHAM>();
        SqlCommand cmd = new SqlCommand();
        public List<MYPHAM> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from MYPHAM";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var mp = new MYPHAM();
                        mp.MAMP = row["MAMP"].ToString();
                        mp.TENMP = row["TENMP"].ToString();
                        mp.ANH = row["ANH"].ToString();
                        mp.NGAYSX = row["NGAYSX"].ToString();
                        mp.TGBH = row["TGBH"].ToString();
                        mp.MALOAI = row["MALOAI"].ToString();
                        mp.NSX = row["NSX"].ToString();
                        mp.DVT = row["DVT"].ToString();
                        mp.GIA = (int)row["GIA"];
                        listProduct.Add(mp);
                    }
                }
                return listProduct;
            }
            catch
            {
                throw;
            }

        }
        public List<MYPHAM> search(string txtTenMP)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {

                    con.ConnectionString = conStr;
                    string sql;
                    if (txtTenMP != "")
                        sql = "Select * from MYPHAM where TENMP LIKE '%" + txtTenMP + "%'";
                    else
                        sql = "Select * from MYPHAM";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var mp = new MYPHAM();
                        mp.MAMP = row["MAMP"].ToString();
                        mp.TENMP = row["TENMP"].ToString();
                        mp.ANH = row["ANH"].ToString();
                        mp.NGAYSX = row["NGAYSX"].ToString();
                        mp.TGBH = row["TGBH"].ToString();
                        mp.MALOAI = row["MALOAI"].ToString();
                        mp.NSX = row["NSX"].ToString();
                        mp.DVT = row["DVT"].ToString();
                        mp.GIA = (int)row["GIA"];
                        listProduct.Add(mp);
                    }
                }
                return listProduct;
            }
            catch
            {
                throw;
            }

        }


        public bool UpdateEmployee(MYPHAM mp)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE MYPHAM SET MAMP = @MAMP, TENMP = @TENMP, ANH = @ANH, NGAYSX =  @NGAYSX, TGBH = @TGBH, MALOAI = @MALOAI,  NSX = @NSX ,DVT= @DVT,@GIA=GIA  WHERE MAMP = @MAMP";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MAMP", mp.MAMP);
            cmd.Parameters.AddWithValue("@TENMP", mp.TENMP);
            cmd.Parameters.AddWithValue("@ANH", mp.ANH);
            cmd.Parameters.AddWithValue("@NGAYSX", mp.ANH);
            cmd.Parameters.AddWithValue("@TGBH", mp.TGBH);
            cmd.Parameters.AddWithValue("@MALOAI", mp.MALOAI);
            cmd.Parameters.AddWithValue("@NSX", mp.NSX);
            cmd.Parameters.AddWithValue("@DVT", mp.DVT);
            cmd.Parameters.AddWithValue("@GIA", mp.GIA);
            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            // Success
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public int DelectProduct(string txtMaMyPham)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.Open();
            string sql2 = "select count(*) from CHITIETHD where MAMP = '" + txtMaMyPham + "'";
            cmd.CommandText = sql2;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();

            if (kt == 0)
            {
                string sql = "delete from MYPHAM where MAMP = '" + txtMaMyPham + "'";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }

            con.Close();
            return rs;
        }
        public bool AddMyPham(MYPHAM mp)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO MYPHAM(MAMP, TENMP, ANH, NGAYSX, TGBH, MALOAI,NSX,DVT,GIA) VALUES (@MAMP, @TENMP, @ANH, @NGAYSX, @TGBH, @MALOAI,@NSX,@DVT,@GIA)";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MAMP", mp.MAMP);
            cmd.Parameters.AddWithValue("@TENMP", mp.TENMP);
            cmd.Parameters.AddWithValue("@ANH", mp.ANH);
            cmd.Parameters.AddWithValue("@NGAYSX", mp.NGAYSX);
            cmd.Parameters.AddWithValue("@TGBH", mp.TGBH);
            cmd.Parameters.AddWithValue("@MALOAI", mp.MALOAI);
            cmd.Parameters.AddWithValue("@NSX", mp.NSX);
            cmd.Parameters.AddWithValue("@DVT", mp.DVT);
            cmd.Parameters.AddWithValue("@GIA", mp.GIA);
            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            // Success
            if (result > 0)
            {
                return true;
            }

            return false;
        }




    }
}