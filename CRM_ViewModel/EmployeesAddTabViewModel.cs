using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_ExtraSelfDesignLibraries;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using CRM_ViewModel.Commands;
using System.Diagnostics;
using CRM_Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CRM_ViewModel
{
    
    public class EmployeesAddTabViewModel
    {
        public OpenFileInAddEmployeeTabCommand OpenCommand { get; set; }
        public ClearAddEmployeeFormCommand ClearCommand { get; set; }
        public AddEmployeeCommand AddEmployee { get; set; }
        DataBase DB;
        MyValidations check;

        //All the Fields
        private int _Id;
        private string _Fname;
        private string _lname;
        private DateTime _BirthDate;
        private DateTime _HiredDate;
        private int _StreetNo;
        private string _StreetName;
        private int _AppNo;
        private string _Municipality;
        private string _City;
        private string _Province;
        private string _PostalCode;
        private string _Country= "Canada";
        private string _Email;
        private string _Phone;
        private char _Rank;
        private string _Title;
        private decimal _SalaryPerHour;
        private string _UserName;
        private string _Password;
        private string _ConfirmPassword;
        private byte[] _Image;
        private BitmapImage _ImageSource;
        private long m_lImageFileLength = 0;

        //viewModel Constructor 
        public EmployeesAddTabViewModel()
        {
            this.Provinces = new ObservableCollection<string>() {"Ontario(ON)","Quebec(QC)","Nova Scotia(NS)","New Brunswick(NB)","Manitoba(MB)","British Columbia(BC)", "Prince Edward Island(PE)" , "Saskatchewan(SK)" , "Alberta(AB)" , "Newfoundland(NL)" };
            this.Ranks = new ObservableCollection<char>() { 'A', 'B', 'C', 'D', 'E', 'F' };
            this.Titles = new ObservableCollection<string> { "IT Administrator", "Consultant", "Marketing Advisor", "Dep. Manager", "Acountant" };
            ImageSource  = new BitmapImage(new Uri(@"C:\Users\vartie\Desktop\CRM_View\CRM_View\Images\personal.png"));
            this.BirthDate = DateTime.Parse("1900/01/01");
            this.HiredDate = DateTime.Now;
            this.OpenCommand = new OpenFileInAddEmployeeTabCommand(this);
            this.ClearCommand = new ClearAddEmployeeFormCommand(this);
            this.AddEmployee = new AddEmployeeCommand(this);
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
        public DateTime HiredDate
        {
            get { return _HiredDate; }
            set
            {
                if (_HiredDate != value )
                {
                    _HiredDate = value;
                    RaisePropertyChanged("HiredDate");
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
                if (_StreetName != value )
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
                if (_Municipality != value )
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
                if (_City != value )
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
                if (_Phone != value )
                {
                    _Phone = value;
                    RaisePropertyChanged("Phone");
                }             
            }
        }
        public ObservableCollection<char> Ranks { get; }
        public char Rank
        {
            get { return _Rank; }
            set
            {
                if (_Rank != value)
                {
                    _Rank = value;
                    RaisePropertyChanged("Rank");
                }
            }
        }
        public ObservableCollection<string> Titles { get; }
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        public decimal SalaryPerHour
        {
            get { return _SalaryPerHour; }
            set
            {
                if (_SalaryPerHour != value)
                {
                    _SalaryPerHour = value;
                    RaisePropertyChanged("SalaryPerHour");
                }
            }
        }
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value )
                {
                    _Password = value;
                    RaisePropertyChanged("Password");
                }               
            }
        }
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                if (_ConfirmPassword != value)
                {
                    _ConfirmPassword = value;
                    RaisePropertyChanged("ConfirmPassword");
                }
               
            }
        }
        public byte[] Image
        {
            get { return _Image; }
            set
            {
                if (_Image != value)
                {
                    _Image = value;
                    RaisePropertyChanged("Image");
                }               
            }
        }
        public BitmapImage ImageSource
        {
            get {return _ImageSource; }

            set
            {
                if (_ImageSource != value)
                {
                    _ImageSource = value;
                    RaisePropertyChanged("ImageSource");
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
        // Button upload Image clicked
        public void btnUpload_Click()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                try
                {                  
                    string strFn = op.FileName;
                    //ImageSource = new BitmapImage(new Uri(strFn));             
                    FileInfo fiImage = new FileInfo(strFn);
                    this.m_lImageFileLength = fiImage.Length;
                    FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Image = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                   // ImageSource = byteArrayToImage(Image);
                   int iBytesRead = fs.Read(Image, 0, Convert.ToInt32(this.m_lImageFileLength));
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Button Clear Form clicked
        public void btnClearForm_Click()
        {
            ResetAllProperties();
        }
        //Button Add Employee Clicked
        public void btnAddEmployee_Click()
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
            if (!check.IsValidHiredDay(HiredDate)||check.IsNullOrEmptyEntry(HiredDate))
            {
                MessageBox.Show("Please Enter a valid Hired Date!", "Hired Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);               
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
            //Validate the Salary
            if (check.IsNullOrEmptyEntry(SalaryPerHour))
            {
                MessageBox.Show("Please Enter a valid Salary!", "Salary Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Username
            if (!check.IsValidString(UserName))
            {
                MessageBox.Show("Please Enter a valid Username!", "Username Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Password
            if (!check.IsValidString(Password) || !check.IsValidPassword(Password))
            {
                MessageBox.Show("Please Enter a valid Password!", "Password Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Verify the password
            if (ConfirmPassword != Password )
            {
                MessageBox.Show("Both Entry Password is not match!", "Password Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Image
            if (Image == null || Image.Length == 0)
            {
                MessageBox.Show("Please Upload An Image!", "Image Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }         
                Employee em = new Employee(0, FirstName, LastName, BirthDate, HiredDate, StreetNo, StreetName, AppNo, Municipality, City, Province, PostalCode, Country, Email, Phone, Rank, Title, SalaryPerHour, UserName, Password, Image);
                DB.addEmployee(em);
                MessageBox.Show("Employee Added Successfully.", "Employee Added", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        // Reset All Properties
        private void ResetAllProperties()
        {
            FirstName = "";
            LastName = "";
            BirthDate = DateTime.Parse("1900/01/01");
            HiredDate = DateTime.Now;
            StreetNo = 0;
            StreetName = "";
            AppNo = 0;
            Municipality = "";
            City = "";
            PostalCode = "";
            Email = "";
            Phone = "";
            SalaryPerHour = 0;
            UserName = "";
            Password = "";
            ConfirmPassword = "";
            ImageSource = new BitmapImage(new Uri(@"C:\Users\vartie\Desktop\CRM_View\CRM_View\Images\personal.png"));
        }
        //Convert byte[] to BitmapImage
        private BitmapImage byteArrayToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

    }
}
