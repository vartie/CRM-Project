using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model
{
    public class Customer
    {
        private int _Id;
        private string _Fname;
        private string _lname;
        private DateTime _BirthDate;
        private DateTime _RegisterDate;
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

        /* Constractor */
        public Customer(int id, string fname, string lname, DateTime birth,DateTime regdate, int streetno, string streetname, int appno, string municipality, string city, string province, string postalcode, string country, string email, string phone)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            BirthDate = birth;
            RegisterDate = regdate;
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
            set { _Fname = value; }
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
        public DateTime RegisterDate
        {
            get { return _RegisterDate; }
            set { _RegisterDate = value; }
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
            set { _Municipality = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
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
    }
}
