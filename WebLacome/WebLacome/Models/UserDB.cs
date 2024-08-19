using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using System.Data;

using System.Configuration;
using WebLacome.Areas.Admin.Models;
namespace WebLacome.Models
{
    public class UserDB
    {


        public string connectStr = "Data Source=LAPTOP-A054QLV3;Initial Catalog=QL_MYPHAM1;Integrated Security=True";



        public List<TaiKhoan> GetTaiKhoans()

            {

                List<TaiKhoan> userList = new List<TaiKhoan>();



                SqlConnection connection = new SqlConnection(connectStr);

                SqlCommand cmd = new SqlCommand();



                cmd.CommandText = "SELECT * FROM TaiKhoan";

                cmd.Connection = connection;



                connection.Open();



                SqlDataReader dataReader = cmd.ExecuteReader();

                var ok = dataReader.HasRows;



                // Get rows in table

                while (dataReader.Read())

                {    
                    TaiKhoan user = new TaiKhoan();
                    user.TENDN = dataReader["TENDN"].ToString();

                    user.HOTEN = dataReader["HOTEN"].ToString();

                    user.EMAIL = dataReader["EMAIL"].ToString();

                    user.MATKHAU = dataReader["MATKHAU"].ToString();

                    user.ANHBIAUSER = dataReader["ANHBIAUSER"].ToString();
                    user.VAITRO = dataReader["VAITRO"].ToString().TrimEnd();
                    userList.Add(user);

                }



                connection.Close();





                return userList;

            }



            public bool CreateTaiKhoan(TaiKhoan registerInfo)

            {

                SqlConnection connection = new SqlConnection(connectStr);

                SqlCommand cmd = new SqlCommand();



                cmd.CommandText = "INSERT INTO TaiKhoan(TENDN,EMAIL, HOTEN, MATKHAU,VAITRO) VALUES (@TENDN,@EMAIL, @HOTEN, @MATKHAU,@VAITRO); ";

                cmd.Connection = connection;



                cmd.Parameters.AddWithValue("@TENDN", registerInfo.TENDN);
                cmd.Parameters.AddWithValue("@EMAIL", registerInfo.EMAIL);

                cmd.Parameters.AddWithValue("@HOTEN", registerInfo.HOTEN);

                cmd.Parameters.AddWithValue("@MATKHAU", registerInfo.MATKHAU);


                cmd.Parameters.AddWithValue("@VAITRO","User");




            connection.Open();



                int result = cmd.ExecuteNonQuery();
                








                connection.Close();
            return result > 0;


                // Create successfully
            }


            public bool isExisted(string userName, string email)

            {

                List<TaiKhoan> users = GetTaiKhoans();

                bool result = users.Any(user => user.TENDN == userName || user.EMAIL == email);

                return result;

            }

        
    }
}