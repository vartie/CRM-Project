using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject
{
    class Database
    {
        SqlConnection conn;
        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ipd\Documents\c_sharp_fundamental-2017\WpfApplicationTest\WpfApplicationTest\TestDB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
        }

        public void addEmployee(Employee e)
        {
            string sql = "INSERT INTO Employees(Fname,Lname,Birthdate,HiredDate,StreetNo,StreetName,AppNo,Municipality,City,Province,PostalCode,Country,Rank,Title,SalaryPerHour,UserName,Password) VALUES(@Fname,@Lname,@Birthdate,@HiredDate,@StreetNo,@StreetName,@AppNo,@Municipality,@City,@Province,@PostalCode,@Country,@Rank,@Title,@SalaryPerHour,@UserName,@Password)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar).Value = e.Fname;
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar).Value = e.Lname;
            cmd.Parameters.Add("@Birthdate", SqlDbType.DateTime).Value = e.BirthDate;
            cmd.Parameters.Add("@HiredDate", SqlDbType.DateTime).Value = e.HiredDate;
            cmd.Parameters.Add("@StreetNo", SqlDbType.Int).Value = e.StreetNo;
            cmd.Parameters.Add("@StreetName", SqlDbType.VarChar).Value = e.StreetName;
            cmd.Parameters.Add("@AppNo", SqlDbType.Int).Value = e.AppNo;
            cmd.Parameters.Add("@Municipality", SqlDbType.VarChar).Value = e.Municipality;
            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = e.City;
            cmd.Parameters.Add("@Province", SqlDbType.Char).Value = e.Province;
            cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = e.PostalCode;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = e.Country;
            cmd.Parameters.Add("@Rank", SqlDbType.Char).Value = e.Rank;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = e.Title;
            cmd.Parameters.Add("@SalaryPerHour", SqlDbType.Decimal).Value = e.SalaryPerHour;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = e.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = e.Password;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
}
