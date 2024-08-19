using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebLacome.Models
{
    public class ConnectMyPham
    {
        List<MyPham> listMyPham = new List<MyPham>();
        string conStr = "Data Source=LAPTOP-A054QLV3;Initial Catalog=QL_MYPHAM1;Integrated Security=True";
        public List<MyPham> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    string sql = "Select * from MyPham";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var emp = new MyPham();
                        emp.MAMP = row["MAMP"].ToString();
                        emp.TENMP = row["TENMP"].ToString();
                        emp.ANH = row["ANH"].ToString();
                        emp.NGAYSX = row["NGAYSX"].ToString();
                        emp.TGBH = row["TGBH"].ToString();
                        emp.MALOAI = row["MALOAI"].ToString();
                        emp.NSX = row["NSX"].ToString();
                        emp.DVT = row["DVT"].ToString();
                        emp.GIA = (int)row["GIA"];
                        listMyPham.Add(emp);
                    }
                }
                return listMyPham;
            }
            catch
            {
                throw;
            }
        }
        public List<MyPham> getMyPham(string MAMP)
        {
            string sql = "Select * from MyPham WHERE MAMP = '" + MAMP + "'";
            List<MyPham> listMyPham = new List<MyPham>();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.ConnectionString = conStr;
            
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            foreach (DataRow row in dt.Rows)
            {
                var emp = new MyPham();
                emp.MAMP = row["MAMP"].ToString();
                emp.TENMP = row["TENMP"].ToString();
                emp.ANH = row["ANH"].ToString();
                emp.NGAYSX = row["NGAYSX"].ToString();
                emp.TGBH = row["TGBH"].ToString();
                emp.MALOAI = row["MALOAI"].ToString();
                emp.NSX = row["NSX"].ToString();
                emp.DVT = row["DVT"].ToString();
                emp.GIA = int.Parse(row["GIA"].ToString());
                listMyPham.Add(emp);
            }
            return listMyPham;
        }
        public List<MyPham> searchMyPham(string txtTenMP)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {

                    con.ConnectionString = conStr;
                    string sql;
                    if (txtTenMP != "")
                        sql = "Select * from MYPHAM where TENMP LIKE N'%" + txtTenMP + "%'";
                    else
                        sql = "Select * from MYPHAM";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var emp = new MyPham();
                        emp.MAMP = row["MAMP"].ToString();
                        emp.TENMP = row["TENMP"].ToString();
                        emp.ANH = row["ANH"].ToString();
                        emp.NGAYSX = row["NGAYSX"].ToString();
                        emp.TGBH = row["TGBH"].ToString();
                        emp.MALOAI = row["MALOAI"].ToString();
                        emp.NSX = row["NSX"].ToString();
                        emp.DVT = row["DVT"].ToString();
                        emp.GIA = int.Parse(row["GIA"].ToString());
                        listMyPham.Add(emp);
                    }
                }
                return listMyPham;
            }
            catch
            {
                throw;
            }
        }
    }
}
