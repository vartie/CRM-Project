using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model
{
    public class DataBase
    {
        SqlConnection conn;
        public DataBase()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vartie\Desktop\CRM_View\DataBaseTestFile\CRM_Test_DB.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
        }

        public void addEmployee(Employee e)
        {
            string sql = "INSERT INTO Employee(FName,LName,BirthDate,HiredDate,StreetNo,StreetName,AppNo,Municipality,City,Province,PostalCode,Country,Email,Phone,Rank,Title,SalaryPerHour,UserName,Password) VALUES(@Fname,@Lname,@BirthDate,@HiredDate,@StreetNo,@StreetName,@AppNo,@Municipality,@City,@Province,@PostalCode,@Country,@Email,@Phone,@Rank,@Title,@SalaryPerHour,@UserName,@Password)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar).Value = e.Fname;
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar).Value = e.Lname;
            cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = e.BirthDate;
            cmd.Parameters.Add("@HiredDate", SqlDbType.DateTime).Value = e.HiredDate;
            cmd.Parameters.Add("@StreetNo", SqlDbType.Int).Value = e.StreetNo;
            cmd.Parameters.Add("@StreetName", SqlDbType.VarChar).Value = e.StreetName;
            cmd.Parameters.Add("@AppNo", SqlDbType.Int).Value = e.AppNo;
            cmd.Parameters.Add("@Municipality", SqlDbType.VarChar).Value = e.Municipality;
            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = e.City;
            cmd.Parameters.Add("@Province", SqlDbType.Char).Value = e.Province;
            cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = e.PostalCode;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = e.Country;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = e.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = e.Phone;
            cmd.Parameters.Add("@Rank", SqlDbType.Char).Value = e.Rank;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = e.Title;
            cmd.Parameters.Add("@SalaryPerHour", SqlDbType.Decimal).Value = e.SalaryPerHour;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = e.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = e.Password;
            //cmd.Parameters.Add("@Image", SqlDbType.Image).Value = e.Image;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        public List<Employee> getAllEmployee()
        {
            List<Employee> EmployeeList = new List<Employee>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", conn))

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string fname = (string)reader["FName"];
                    string lname = (string)reader["LName"];
                    DateTime birth = (DateTime)reader["BirthDate"];
                    DateTime hired = (DateTime)reader["HiredDate"];
                    int streetno = (int)reader["StreetNo"];
                    string streetname = (string)reader["StreetName"];
                    int appno = (int)reader["AppNo"];
                    string municipal = (string)reader["Municipality"];
                    string city = (string)reader["City"];
                    string province = (string)reader["Province"];
                    string postalcode = (string)reader["PostalCode"];
                    string country = (string)reader["Country"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    char rank = ((string)reader["Rank"])[0];
                    string title = (string)reader["Title"];
                    decimal salary = (decimal)reader["SalaryPerHour"];
                    string username = (string)reader["UserName"];
                    string password = (string)reader["Password"];
                    byte[] image = (byte[])reader["Image"];
                    EmployeeList.Add(new Employee(id, fname, lname, birth, hired, streetno, streetname, appno, municipal, city, province, postalcode, country, email, phone, rank, title, salary, username, password, image));
                }
            }
            return EmployeeList;
        }
    }
}
