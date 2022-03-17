using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssmsDataConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=EFICYIT-LT12;Initial Catalog=customersdb;Integrated Security=True");
            SqlDataAdapter sqlad = new SqlDataAdapter("Select * from dbo.customers",sqlcon);
            DataTable dtbl = new DataTable();
            sqlad.Fill(dtbl);

            foreach (DataRow dr in dtbl.Rows)
            {
                Console.WriteLine(dr["cust_id"] + " " + dr["cust_name"]);
            }
            Console.ReadLine();
        }
    }
}
