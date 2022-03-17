using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twodatabase_twogender_division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlcon1 = new SqlConnection(@"Data Source=EFICYIT-LT12;Initial Catalog=dbone;Integrated Security=True");
            SqlConnection sqlcon2 = new SqlConnection(@"Data Source=EFICYIT-LT12;Initial Catalog=dbtwo;Integrated Security=True");

            int Age = 0;
            bool status = true;
            string Name = "", Gender = "";
            while (status)
            {
                Console.Clear();
                Age = 0;
                Name = Gender = "";
                Console.WriteLine("Provide Name: ");
                Name=Console.ReadLine();
                Console.WriteLine("Provide Age: ");
                Age = Convert.ToInt32(Console.ReadLine());    
                Console.WriteLine("Provide Gender [M|F]: ");
                Gender = Console.ReadLine();
                if(Age<50)
                {
                    if(Gender=="M"||Gender=="m")
                    {
                        SqlDataAdapter sqlmins1 = new SqlDataAdapter($"INSERT INTO male (Name, Age, Gender) VALUES('{Name}',{Age},'{Gender}')", sqlcon1);
                        DataTable dtbl = new DataTable();
                        sqlmins1.Fill(dtbl);
                    }
                    else if(Gender=="F"||Gender=="f")
                    {
                        SqlDataAdapter sqlmins1 = new SqlDataAdapter($"INSERT INTO female (Name, Age, Gender) VALUES('{Name}',{Age},'{Gender}')", sqlcon1);
                        DataTable dtbl = new DataTable();
                        sqlmins1.Fill(dtbl);
                    }
                    else
                    {
                        Console.WriteLine("Gender is not Correct!");
                    }
                }
                else if(Age>=50)
                {
                    if (Gender == "M" || Gender == "m")
                    {
                        SqlDataAdapter sqlmins2 = new SqlDataAdapter($"INSERT INTO male (Name, Age, Gender) VALUES('{Name}',{Age},'{Gender}')", sqlcon2);
                        DataTable dtbl2 = new DataTable();
                        sqlmins2.Fill(dtbl2);
                    }
                    else if (Gender == "F" || Gender == "f")
                    {
                        SqlDataAdapter sqlmins2 = new SqlDataAdapter($"INSERT INTO female (Name, Age, Gender) VALUES('{Name}',{Age},'{Gender}')", sqlcon2);
                        DataTable dtbl = new DataTable();
                        sqlmins2.Fill(dtbl);
                    }
                    else
                    {
                        Console.WriteLine("Gender is not Correct!");
                    }
                }
                else
                {
                    Console.WriteLine("Provided Age is Not Correct!");
                }
                Console.WriteLine("Want to Add more? \nPress Number to Continue\nPress 0 for Exit.");
                if (Convert.ToInt32(Console.ReadLine()) == 0)
                    status = false;
            }
        }
    }
}
