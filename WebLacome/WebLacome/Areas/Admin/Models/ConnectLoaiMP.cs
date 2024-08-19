using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class ConnectLoaiMP : ConnectSQL
    {
        List<LOAIMP> listLoaiMP = new List<LOAIMP>();
        SqlCommand cmd = new SqlCommand();
        public List<LOAIMP> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from LOAIMP";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var loai = new LOAIMP();
                        loai.MALOAI = row["MALOAI"].ToString();
                        loai.TENLOAI = row["TENLOAI"].ToString();
                        listLoaiMP.Add(loai);
                    }
                }
                return listLoaiMP;
            }
            catch
            {
                throw;
            }

        }
        public bool AddLoai(LOAIMP Loai)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO LOAIMP(MALOAI, TENLOAI) VALUES (@MALOAI, @TENLOAI)";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MALOAI", Loai.MALOAI);
            cmd.Parameters.AddWithValue("@TENLOAI", Loai.TENLOAI);

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


        public bool UpdateLoaiMP(LOAIMP loai)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE LOAIMP SET MALOAI = @MALOAI, TENLOAI = @TENLOAI WHERE MALOAI = @MALOAI";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MALOAI", loai.MALOAI);
            cmd.Parameters.AddWithValue("@TENLOAI", loai.TENLOAI);

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


        public int DelectLoai(string txtMaLoaiMP)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.Open();
            string sql2 = "select count(*) from CHITIETHD where MALOAI = '" + txtMaLoaiMP + "'";
            cmd.CommandText = sql2;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();

            if (kt == 0)
            {
                string sql = "delete from LOAIMP where MALOAI = '" + txtMaLoaiMP + "'";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }

            con.Close();
            return rs;
        }
    }
}