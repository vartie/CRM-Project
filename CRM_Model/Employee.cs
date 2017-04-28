using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model
{
    public class Employee 
    {
        private int _Id;
        private string _Fname;
        private string _lname;
        private DateTime _BirthDate;
        private DateTime _hiredDate;
        private int _StreetNo;
        private string _StreetName;
        private int _AppNo;
        private string _Municipality;
        private string _City;
        private string _Province;
        private string _PostalCode;
        private string _Country;
        private string _Email;
        private string _Phone;
        private char _Rank;
        private string _Title;
        private decimal _SalaryPerHour;
        private string _UserName;
        private string _Password;
        private byte[] _Image;



        /* Constractor */
        public Employee(int id, string fname, string lname, DateTime birth, DateTime hire, int streetno, string streetname, int appno, string municipality, string city, string province, string postalcode, string country, string email, string phone, char rank, string title, decimal salary, string username, string password, byte[] image)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            BirthDate = birth;
            HiredDate = hire;
            StreetNo = streetno;
            StreetName = streetname;
            AppNo = appno;
            Municipality = municipality;
            City = city;
            Province = province;
            PostalCode = postalcode;
            Country = country;
            Email = email;
            Phone = phone;
            Rank = rank;
            Title = title;
            SalaryPerHour = salary;
            UserName = username;
            Password = password;
            Image = image;
        }


        /* setter and getters */
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Fname
        {
            get { return _Fname; }
            set{_Fname = value;  }
        }
        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
        public DateTime HiredDate
        {
            get { return _hiredDate; }
            set { _hiredDate = value; }
        }
        public int StreetNo
        {
            get { return _StreetNo; }
            set { _StreetNo = value; }
        }
        public string StreetName
        {
            get { return _StreetName; }
            set { _StreetName = value; }
        }
        public int AppNo
        {
            get { return _AppNo; }
            set { _AppNo = value; }
        }
        public string Municipality
        {
            get { return _Municipality; }
            set { _Municipality = value;}
        }
        public string City
        {
            get { return _City; }
            set { _City = value;}
        }
        public string Province
        {
            get { return _Province; }
            set { _Province = value;}
        }
        public string PostalCode
        {
            get { return _PostalCode; }
            set {  _PostalCode = value;}
        }
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public char Rank
        {
            get { return _Rank; }
            set { _Rank = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public decimal SalaryPerHour
        {
            get { return _SalaryPerHour; }
            set { _SalaryPerHour = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set {_UserName = value;}
        }
        public string Password
        {
            get { return _Password; }
            set{ _Password = value;}
        }
        public byte[] Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

    }
}
