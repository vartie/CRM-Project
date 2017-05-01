using CRM_ExtraSelfDesignLibraries;
using CRM_Model;
using CRM_ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace CRM_ViewModel
{
    public class CustomerAddTabViewModel
    {
        DataBase DB;
        MyValidations check;
        public AddCustomerCommand AddCustomer { get; set; }


        //All the Fields
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
        private string _Country = "Canada";
        private string _Email;
        private string _Phone;

        //viewModel Constructor 
        public CustomerAddTabViewModel()
        {
            this.Provinces = new ObservableCollection<string>() { "Ontario(ON)", "Quebec(QC)", "Nova Scotia(NS)", "New Brunswick(NB)", "Manitoba(MB)", "British Columbia(BC)", "Prince Edward Island(PE)", "Saskatchewan(SK)", "Alberta(AB)", "Newfoundland(NL)" };
            this.BirthDate = DateTime.Parse("1900/01/01");
            this.RegisterDate = DateTime.Now;
            this.AddCustomer = new AddCustomerCommand(this);
            check = new MyValidations();
            try
            {
                DB = new DataBase();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There is a problem in Connecting to the DateBase!", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Setters And Getters 
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string FirstName
        {
            get { return _Fname; }

            set
            {
                if (_Fname != value)
                {
                    _Fname = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return _lname; }
            set
            {
                if (_lname != value)
                {
                    _lname = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set
            {
                if (_BirthDate != value)
                {
                    _BirthDate = value;
                    RaisePropertyChanged("BirthDate");
                }
            }

        }
        public DateTime RegisterDate
        {
            get { return _RegisterDate; }
            set
            {
                if (_RegisterDate != value)
                {
                    _RegisterDate = value;
                    RaisePropertyChanged("RegisterDate");
                }
            }
        }
        public int StreetNo
        {
            get { return _StreetNo; }
            set
            {
                if (_StreetNo != value)
                {
                    _StreetNo = value;
                    RaisePropertyChanged("StreetNo");
                }
            }

        }
        public string StreetName
        {
            get { return _StreetName; }
            set
            {
                if (_StreetName != value)
                {
                    _StreetName = value;
                    RaisePropertyChanged("StreetName");
                }
            }
        }
        public int AppNo
        {
            get { return _AppNo; }
            set
            {
                if (_AppNo != value)
                {
                    _AppNo = value;
                    RaisePropertyChanged("AppNo");
                }
            }
        }
        public string Municipality
        {
            get { return _Municipality; }
            set
            {
                if (_Municipality != value)
                {
                    _Municipality = value;
                    RaisePropertyChanged("Municipality");
                }
            }
        }
        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    RaisePropertyChanged("City");
                }
            }
        }
        public ObservableCollection<string> Provinces { get; }
        public string Province
        {
            get { return _Province; }
            set
            {
                if (_Province != value)
                {
                    _Province = value;
                    RaisePropertyChanged("Province");
                }
            }
        }
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if (_PostalCode != value)
                {
                    _PostalCode = value;
                    RaisePropertyChanged("PostalCode");
                }
            }
        }
        public string Country
        {
            get { return _Country; }

        }
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    RaisePropertyChanged("Email");
                }
            }
        }
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (_Phone != value)
                {
                    _Phone = value;
                    RaisePropertyChanged("Phone");
                }
            }
        }

        /// <summary>
        /// Property Change Event Handeller
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void btnAddCustomer_Click()
        {
            //Validate the First name
            if (!check.IsValidString(FirstName))
            {
                MessageBox.Show("Please Enter a valid First Name!", "Invalid First Name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Last Name
            if (!check.IsValidString(LastName))
            {
                MessageBox.Show("Please Enter a valid Last Name!", "Invalid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Birth Date
            if (!check.IsValidBirthDay(BirthDate) || check.IsNullOrEmptyEntry(BirthDate))
            {
                MessageBox.Show("Please Enter a valid Birth Date!", "Birth Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Validate the hired date
            if (!check.IsValidHiredDay(RegisterDate) || check.IsNullOrEmptyEntry(RegisterDate))
            {
                MessageBox.Show("Please Enter a valid Register Date!", "Hired Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Street Number
            if (StreetNo <= 0)
            {
                MessageBox.Show("Please Enter a valid Street Number!", "Street Number Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Street Name
            if (!check.IsValidString(StreetName))
            {
                MessageBox.Show("Please Enter a valid Street Name!", "Street Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Apartment Number
            if (AppNo <= 0)
            {
                MessageBox.Show("Please Enter a valid Apartment Number!", "Apartment Number Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Municipality
            if (!check.IsValidString(Municipality))
            {
                MessageBox.Show("Please Enter a valid Municipality!", "Municipality Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the City
            if (!check.IsValidString(City))
            {
                MessageBox.Show("Please Enter a valid City!", "City Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Postalcode
            Regex regexPostalcode = new Regex("[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY][0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ] ?[0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ][0-9]");
            if (!check.IsValidString(PostalCode) || !regexPostalcode.IsMatch(PostalCode))
            {
                MessageBox.Show("Please Enter a valid Postal Code!", "Postal Code Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Country
            if (!check.IsValidString(Country))
            {
                MessageBox.Show("Please Enter a valid Country!", "Country Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validatye the Email Address
            if (check.IsNullOrEmptyEntry(Email))
            {
                MessageBox.Show("Please Enter a valid Email!", "Email Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the phone
            Regex regexPhone = new Regex(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
            if (check.IsNullOrEmptyEntry(Phone) || !regexPhone.IsMatch(Phone))
            {
                MessageBox.Show("Please Enter a valid Phone!", "Phone Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            Customer cm = new Customer(0, FirstName, LastName, BirthDate, RegisterDate, StreetNo, StreetName, AppNo, Municipality, City, Province, PostalCode, Country, Email, Phone);
            DB.addCustomer(cm);
            CustomerAddedMessage.Default.Send(cm);
            MessageBox.Show("Customer Added Successfully.", "Customer Added", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
