﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject
{
    class Employee
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
        private char _Rank;
        private string _Title;
        private decimal _SalaryPerHour;
        private string _UserName;
        private string _Password;

        /* Constractor */
        public Employee(int id, string fname, string lname, DateTime birth, DateTime hire, int streetno, string streetname, int appno, string municipality, string city, string province, string postalcode, string country, char rank, string title, decimal salary, string username, string password)
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
            Rank = rank;
            Title = title;
            SalaryPerHour = salary;
            UserName = username;
            Password = password;
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
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Name must be valid.!");
                }
                _Fname = value;
            }
        }
        public string Lname
        {
            get { return _lname; }
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Name must be valid.!");
                }
                _lname = value;
            }
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
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First StreetName must be valid.!");
                }
                _StreetName = value;
            }
        }
        public int AppNo
        {
            get { return _AppNo; }
            set { _AppNo = value; }
        }
        public string Municipality
        {
            get { return _Municipality; }
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Municipality must be valid.!");
                }
                _Municipality = value;
            }
        }
        public string City
        {
            get { return _City; }
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First City must be valid.!");
                }
                _City = value;
            }
        }
        public string Province
        {
            get { return _Province; }
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Province must be valid.!");
                }
                _Province = value;
            }
        }
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First PostalCode must be valid.!");
                }
                _PostalCode = value;
            }
        }
        public string Country
        {
            get { return _Country; }
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Country must be valid.!");
                }
                _Country = value;
            }
        }
        public char Rank
        {
            get { return _Rank; }
            set { _Rank = value; }
        }
        public string Title
        {
            get { return _Title; }
            set
            {
                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Title must be valid.!");
                }
                _Title = value;
            }
        }
        public decimal SalaryPerHour
        {
            get { return _SalaryPerHour; }
            set { _SalaryPerHour = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (value.Length < 6 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First UserName must be valid.!");
                }
                _UserName = value;
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                if (value.Length < 6 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Password must be valid.!");
                }
                _Password = value;
            }
        }
    }
}