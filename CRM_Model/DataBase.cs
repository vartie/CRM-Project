using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //------------------------------------Employee----------------------------------------------
        //Add Employee
        public void addEmployee(Employee e)
        {
            string sql = "INSERT INTO Employee(FName,LName,BirthDate,HiredDate,StreetNo,StreetName,AppNo,Municipality,City,Province,PostalCode,Country,Email,Phone,Rank,Title,SalaryPerHour,UserName,Password,Image) VALUES(@Fname,@Lname,@BirthDate,@HiredDate,@StreetNo,@StreetName,@AppNo,@Municipality,@City,@Province,@PostalCode,@Country,@Email,@Phone,@Rank,@Title,@SalaryPerHour,@UserName,@Password,@Image)";
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
            cmd.Parameters.Add("@Image", SqlDbType.Image).Value = e.Image;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        //retrive All Employees from Database
        public ObservableCollection<Employee> getAllEmployee()
        {
            ObservableCollection<Employee> EmployeeList = new ObservableCollection<Employee>();

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
        //Delete Employee by User Id
        public void deleteEmployeeById(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE Id=@Id", conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }
        //Update Employee
        public void updateEmployee(Employee e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Employee SET FName=@FName,LName=@LName,BirthDate=@BirthDate,HiredDate=@HiredDate,StreetNo=@StreetNo,StreetName=@StreetName,AppNo=@AppNo,Municipality=@Municipality,City=@City,Province=@Province,PostalCode=@PostalCode,Country=@Country,Email=@Email,Phone=@Phone,Rank=@Rank,Title=@Title,SalaryPerHour=@SalaryPerHour,UserName=@UserName,Password=@Password,Image=@Image WHERE Id=@Id", conn);
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
            cmd.Parameters.Add("@Image", SqlDbType.Image).Value = e.Image;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = e.Id;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        //Select logined Employee 
        public Employee getLoginEmployee(string user,string pass)
        {
            Employee e = new Employee();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE UserName=@UserName AND Password=@Password", conn))
            {
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = pass;
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
                        e = new Employee(id, fname, lname, birth, hired, streetno, streetname, appno, municipal, city, province, postalcode, country, email, phone, rank, title, salary, username, password, image);
                    }
                }
            }
            return e;
        }
        //------------------------------------Customer----------------------------------------------
        //Add Customer
        public void addCustomer(Customer e)
        {
            string sql = "INSERT INTO Customer(FName,LName,BirthDate,RegDate,StreetNo,StreetName,AppNo,Municipality,City,Province,PostalCode,Country,Email,Phone) VALUES(@Fname,@Lname,@BirthDate,@RegDate,@StreetNo,@StreetName,@AppNo,@Municipality,@City,@Province,@PostalCode,@Country,@Email,@Phone)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar).Value = e.Fname;
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar).Value = e.Lname;
            cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = e.BirthDate;
            cmd.Parameters.Add("@RegDate", SqlDbType.DateTime).Value = e.RegisterDate;
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
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        //retrive All Customers from Database
        public ObservableCollection<Customer> getAllCustomers()
        {
            ObservableCollection<Customer> CustomerList = new ObservableCollection<Customer>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", conn))

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string fname = (string)reader["FName"];
                    string lname = (string)reader["LName"];
                    DateTime birth = (DateTime)reader["BirthDate"];
                    DateTime reg = (DateTime)reader["RegDate"];
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

                    CustomerList.Add(new Customer(id, fname, lname, birth, reg, streetno, streetname, appno, municipal, city, province, postalcode, country, email, phone));
                }
            }
            return CustomerList;
        }
        //Update Customer
        public void updateCustomer(Customer e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Customer SET FName=@FName,LName=@LName,BirthDate=@BirthDate,RegDate=@RegDate,StreetNo=@StreetNo,StreetName=@StreetName,AppNo=@AppNo,Municipality=@Municipality,City=@City,Province=@Province,PostalCode=@PostalCode,Country=@Country,Email=@Email,Phone=@Phone WHERE Id=@Id", conn);
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar).Value = e.Fname;
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar).Value = e.Lname;
            cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime).Value = e.BirthDate;
            cmd.Parameters.Add("@RegDate", SqlDbType.DateTime).Value = e.RegisterDate;
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
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = e.Id;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        //Delete Employee by User Id
        public void deleteCustumerById(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE Id=@Id", conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }

        //------------------------------------Products----------------------------------------------

        //Add Product
        public void addProduct(Product p)
        {
            string sql = "INSERT INTO Product(Name,Catalog,Price,Qty,Discount,StartDiscountDate,EndtDiscountDate) VALUES(@Name,@Catalog,@Price,@Qty,@Discount,@StartDiscountDate,@EndtDiscountDate)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = p.Name;
            cmd.Parameters.Add("@Catalog", SqlDbType.VarChar).Value = p.Catalog;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = p.Price;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = p.Qty;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = p.Discount;
            cmd.Parameters.Add("@StartDiscountDate", SqlDbType.DateTime).Value = p.StartDiscountDate;
            cmd.Parameters.Add("@EndtDiscountDate", SqlDbType.DateTime).Value = p.EndtDiscountDate;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        //retrive All Customers from Database
        public ObservableCollection<Product> getAllProducts()
        {
            ObservableCollection<Product> ProductList = new ObservableCollection<Product>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product", conn))

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    decimal price = (decimal)reader["Price"];
                    int qty = (int)reader["Qty"];
                    string catalog = (string)reader["Catalog"];
                    decimal discount = (decimal)reader["Discount"];
                    DateTime disStart = (DateTime)reader["StartDiscountDate"];
                    DateTime disEnd = (DateTime)reader["EndtDiscountDate"];
                    ProductList.Add(new Product(id, name, price, discount, qty, catalog, disStart, disEnd));
                }
            }
            return ProductList;
        }
        //Update Customer
        public void updateProduct(Product p)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Product SET Name=@Name,Catalog=@Catalog,Price=@Price,Qty=@Qty,Discount=@Discount,StartDiscountDate=@StartDiscountDate,EndtDiscountDate=@EndtDiscountDate WHERE Id=@Id", conn);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = p.Name;
            cmd.Parameters.Add("@Catalog", SqlDbType.VarChar).Value = p.Catalog;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = p.Price;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = p.Qty;
            cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = p.Discount;
            cmd.Parameters.Add("@StartDiscountDate", SqlDbType.DateTime).Value = p.StartDiscountDate;
            cmd.Parameters.Add("@EndtDiscountDate", SqlDbType.DateTime).Value = p.EndtDiscountDate;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = p.Id;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        //Delete Employee by User Id
        public void deleteProductById(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE Id=@Id", conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }
    }
}
