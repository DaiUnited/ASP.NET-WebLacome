using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class ConnectKhachHang : ConnectSQL
    {

        List<KHACHHANG> listKhachHang = new List<KHACHHANG>();
        SqlCommand cmd = new SqlCommand();
        public List<KHACHHANG> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from KHACHHANG";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var kh = new KHACHHANG();
                        kh.MAKH = row["MAKH"].ToString();
                        kh.TENKH = row["TENKH"].ToString();
                        kh.DCHI = row["DCHI"].ToString();
                        kh.DTHOAI = row["DTHOAI"].ToString();
                        listKhachHang.Add(kh);
                    }
                }
                return listKhachHang;
            }
            catch
            {
                throw;
            }

        }

        public bool AddKhachHang(KHACHHANG kh)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO KHACHHANG(MAKH, TENKH,DCHI,DTHOAI) VALUES (@MAKH, @TENKH,@DCHI,@DTHOAI)";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MAKH", kh.MAKH);
            cmd.Parameters.AddWithValue("@TENKH", kh.TENKH);
            cmd.Parameters.AddWithValue("@DCHI", kh.DCHI);
            cmd.Parameters.AddWithValue("@DTHOAI", kh.DTHOAI);
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


        public bool UpdateKH(KHACHHANG kh)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE KHACHHANG SET MAKH = @MAKH, TENKH = @TENKH ,@DCHI = DCHI,@DTHOAI=DTHOAI WHERE MAKH = @MAKH";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MAKH", kh.MAKH);
            cmd.Parameters.AddWithValue("@TENKH", kh.TENKH);
            cmd.Parameters.AddWithValue("@DCHI", kh.DCHI);
            cmd.Parameters.AddWithValue("@DTHOAI", kh.DTHOAI);

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


        public int DelectKH(string txtMaKH)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.Open();

            cmd.Connection = con;
            int rs = 0;

            string sql = "delete from KHACHHANG where MAKH = '" + txtMaKH + "'";
            cmd.CommandText = sql;
            rs = cmd.ExecuteNonQuery();


            con.Close();
            return rs;
        }
    }
}