using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebLacome.Areas.Admin.Models
{
    public class ConnectSQL
    {
        public string conStr { get; set; }
        public ConnectSQL()
        {
            conStr = "Data Source = LAPTOP-A054QLV3; Initial Catalog = QL_MYPHAM1; Integrated Security = True";
            //conStr = "Data Source=LAPTOP-4C8FM0QJ\\SQLEXPRESS;Initial Catalog=QL_MYPHAM;Integrated Security=True";
        }
    }
}