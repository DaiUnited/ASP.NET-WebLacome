using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class ConnectCTHD : ConnectSQL
    {
        List<CHITIETHOADON> listCTHoaDon = new List<CHITIETHOADON>();
        SqlCommand cmd = new SqlCommand();
        public List<CHITIETHOADON> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from CHITIETHD";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var ct = new CHITIETHOADON();
                        ct.MAHD = row["MAHD"].ToString();
                        ct.MAMP = row["MAMP"].ToString();
                        ct.SOLUONG = (int)row["SOLUONG"];
                        ct.DONGIA = row["DONGIA"].ToString();
                        ct.THANHTIEN = row["THANHTIEN"].ToString();
                        listCTHoaDon.Add(ct);
                    }
                }
                return listCTHoaDon;
            }
            catch
            {
                throw;
            }
        }
    }
}