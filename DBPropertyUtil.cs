using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ElectronicGadgetsLibrary
{
    class DBPropertyUtil
    {
        public static SqlConnection AppConnection()
        {
            string cnstring = GetConnectionString();
            SqlConnection cn = new SqlConnection(cnstring);
            return cn;
        }

        public static string GetConnectionString()
        {
            return "server=DESKTOP-MPVCQ2B\\SQLEXPRESS;database=TechShop;integrated security=true;trust server certificate=true";
        }
    }
}
