using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class ConnectHoaDon : ConnectSQL
    {
        List<HOADON> listHoaDon = new List<HOADON>();
        SqlCommand cmd = new SqlCommand();
        public List<HOADON> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from HOADON";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var hd = new HOADON();
                        hd.MAHD = row["MAHD"].ToString();
                        hd.NGAYHD = row["NGAYHD"].ToString();
                        hd.MAKH = row["MAKH"].ToString();
                        hd.TRIGIA = row["TRIGIA"].ToString();
                        listHoaDon.Add(hd);
                    }
                }
                return listHoaDon;
            }
            catch
            {
                throw;
            }

        }

        public bool AddHoaDon(HOADON hd)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO HOADON(MAHD, NGAYHD,MAKH,TRIGIA) VALUES (@MAHD, @NGAYHD,@MAKH,@TRIGIA)";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MAHD", hd.MAHD);
            cmd.Parameters.AddWithValue("@NGAYHD", hd.NGAYHD);
            cmd.Parameters.AddWithValue("@MAKH", hd.MAKH);
            cmd.Parameters.AddWithValue("@TRIGIA", hd.TRIGIA);

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

        public bool UpdateHD(HOADON hd)
        {
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE HOADON SET MAHD = @MAHD, NGAYHD = @NGAYHD, MAKH = @MAKH, TRIGIA =  @TRIGIA WHERE MAHD = @MAHD";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@MAHD", hd.MAHD);
            cmd.Parameters.AddWithValue("@NGAYHD", hd.NGAYHD);
            cmd.Parameters.AddWithValue("@MAKH", hd.MAKH);
            cmd.Parameters.AddWithValue("@TRIGIA", hd.TRIGIA);

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

        public int DelectHD(string txtMaHD)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.Open();
            string sql2 = "select count(*) from CHITIETHD where MAHD = '" + txtMaHD + "'";
            cmd.CommandText = sql2;
            cmd.Connection = con;
            int rs = 0;
            int kt = (int)cmd.ExecuteScalar();

            if (kt == 0)
            {
                string sql = "delete from HOADON where MAHD = '" + txtMaHD + "'";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }

            con.Close();
            return rs;
        }
    }
}