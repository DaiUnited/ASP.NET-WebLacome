using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebLacome.Models
{
    public class ConnectLoaiMP
    {
        List<LoaiMP> listLoaiMP = new List<LoaiMP>();
        public List<LoaiMP> getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    string conStr = "Data Source=LAPTOP-A054QLV3;Initial Catalog=QL_MYPHAM1;Integrated Security=True";
                    con.ConnectionString = conStr;
                    string sql = "Select * from LoaiMP";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var ctg = new LoaiMP();
                        ctg.MALOAI = row["MALOAI"].ToString();
                        ctg.TENLOAI = row["TENLOAI"].ToString();
                        listLoaiMP.Add(ctg);
                    }
                }
                return listLoaiMP;
            }
            catch
            {
                throw;
            }
        }

        public List<MyPham> ShowListMPByCTG(string MALOAI)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-A054QLV3;Initial Catalog=QL_MYPHAM1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select MAMP, TENMP,ANH,GIA from MYPHAM, LOAIMP where LOAIMP.MALOAI = MYPHAM.MALOAI and LOAIMP.MALOAI = @MALOAI", con);
            SqlParameter Par1 = new SqlParameter("@MALOAI", MALOAI);
            cmd.Parameters.Add(Par1);
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<MyPham> list = new List<MyPham>();
            while (rdr.Read())
            {
                MyPham emp = new MyPham();
                emp.MAMP = rdr.GetValue(0).ToString();

                emp.TENMP = rdr.GetValue(1).ToString();
                emp.ANH = rdr.GetValue(2).ToString();
                emp.GIA = int.Parse(rdr.GetValue(3).ToString());
                list.Add(emp);
            }
            return list;
        }
    }
}