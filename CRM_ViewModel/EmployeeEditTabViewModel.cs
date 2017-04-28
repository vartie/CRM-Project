using CRM_ExtraSelfDesignLibraries;
using CRM_Model;
using CRM_ViewModel.Commands;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace CRM_ViewModel
{
    public class EmployeeEditTabViewModel
    {
        //All Fields
        DataBase DB;
        private string _SearchEmployee;
        private ObservableCollection<Employee> _Employees;
        private Employee _SelectedEmployee;
        public EditEmployeeCommand UpdateCommand { get; set; }
    MyValidations check;
        private string _ConfirmPassword;
        //Temprory List
        ObservableCollection<Employee> tempList = new ObservableCollection<Employee>();

        // All Properties
        public string SearchEmployee
        {
            get { return _SearchEmployee; }
            set
            {
                if (_SearchEmployee != value)
                {
                    _SearchEmployee = value;
                    RaisePropertyChanged("SearchEmployee");
                    if (String.IsNullOrEmpty(_SearchEmployee))
                    {
                        Employees.Clear();
                        foreach (Employee e in tempList)
                        {
                            Employees.Add(e);
                        }
                    }
                    else
                    {
                        foreach (Employee e in tempList)
                        {
                            if (!(e.Fname.ToLower().Contains(SearchEmployee)) && !(e.Lname.ToLower().Contains(SearchEmployee)) && !(e.Title.ToLower().Contains(SearchEmployee)))
                            {
                                Employees.Remove(e);
                            }
                        }
                    }
                }
            }
        }
        public ObservableCollection<Employee> Employees
        {
            get { return _Employees; }
            set
            {
                if (_Employees != value)
                {
                    _Employees = value;
                    RaisePropertyChanged("Employees");
                }
            }
        }
        public ObservableCollection<string> Provinces { get; }
        public ObservableCollection<char> Ranks { get; }
        public ObservableCollection<string> Titles { get; }
        public Employee SelectedEmployee
        {
            get
            {
                return _SelectedEmployee;
            }

            set
            {
                if (_SelectedEmployee != value && value != null)
                {
                    _SelectedEmployee = value;
                    RaisePropertyChanged("SelectedEmployee");
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

        public EmployeeEditTabViewModel()
        {
            //Register for messages from different viewModels
            EmployeeAddedMessage.Default.Register<Employee>(this, (employee) =>
            {
                ReceiveMessage(employee);
            });
            //Initialize comopents with some values
            Employees = new ObservableCollection<Employee>();

            //Register CollectionChangedEvent for the OrderItems
            Employees.CollectionChanged += ContentCollectionChanged;

            this.Provinces = new ObservableCollection<string>() { "Ontario(ON)", "Quebec(QC)", "Nova Scotia(NS)", "New Brunswick(NB)", "Manitoba(MB)", "British Columbia(BC)", "Prince Edward Island(PE)", "Saskatchewan(SK)", "Alberta(AB)", "Newfoundland(NL)" };
            this.Ranks = new ObservableCollection<char>() { 'A', 'B', 'C', 'D', 'E', 'F' };
            this.Titles = new ObservableCollection<string> { "IT Administrator", "Consultant", "Marketing Advisor", "Dep. Manager", "Acountant" };
            this.UpdateCommand = new EditEmployeeCommand(this);
            check = new MyValidations();
            try
            {
                DB = new DataBase();
                LoadAllEmployeeList();
                foreach (Employee e in Employees)
                {
                    tempList.Add(e);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There is a problem in Connecting to the DateBase!", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Employees");
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

        //Load All Employee List Method
        public void LoadAllEmployeeList()
        {
            Employees = DB.getAllEmployee();
            RaisePropertyChanged("Employees");
        }

        //When the message recived 
        private void ReceiveMessage(Employee employee)
        {
            Employees.Add(employee);
        }

        //Buttom Update Clicked
        public void btnUpdate_Click()
        {
            //Validate the First name
            if (!check.IsValidString(SelectedEmployee.Fname))
            {
                MessageBox.Show("Please Enter a valid First Name!", "Invalid First Name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Last Name
            if (!check.IsValidString(SelectedEmployee.Lname))
            {
                MessageBox.Show("Please Enter a valid Last Name!", "Invalid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Birth Date
            if (!check.IsValidBirthDay(SelectedEmployee.BirthDate) || check.IsNullOrEmptyEntry(SelectedEmployee.BirthDate))
            {
                MessageBox.Show("Please Enter a valid Birth Date!", "Birth Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Validate the hired date
            if (!check.IsValidHiredDay(SelectedEmployee.HiredDate) || check.IsNullOrEmptyEntry(SelectedEmployee.HiredDate))
            {
                MessageBox.Show("Please Enter a valid Hired Date!", "Hired Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Street Number
            if (SelectedEmployee.StreetNo <= 0)
            {
                MessageBox.Show("Please Enter a valid Street Number!", "Street Number Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Street Name
            if (!check.IsValidString(SelectedEmployee.StreetName))
            {
                MessageBox.Show("Please Enter a valid Street Name!", "Street Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Apartment Number
            if (SelectedEmployee.AppNo <= 0)
            {
                MessageBox.Show("Please Enter a valid Apartment Number!", "Apartment Number Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Municipality
            if (!check.IsValidString(SelectedEmployee.Municipality))
            {
                MessageBox.Show("Please Enter a valid Municipality!", "Municipality Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the City
            if (!check.IsValidString(SelectedEmployee.City))
            {
                MessageBox.Show("Please Enter a valid City!", "City Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Postalcode
            Regex regexPostalcode = new Regex("[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY][0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ] ?[0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ][0-9]");
            if (!check.IsValidString(SelectedEmployee.PostalCode) || !regexPostalcode.IsMatch(SelectedEmployee.PostalCode))
            {
                MessageBox.Show("Please Enter a valid Postal Code!", "Postal Code Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Country
            if (!check.IsValidString(SelectedEmployee.Country))
            {
                MessageBox.Show("Please Enter a valid Country!", "Country Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validatye the Email Address
            if (check.IsNullOrEmptyEntry(SelectedEmployee.Email))
            {
                MessageBox.Show("Please Enter a valid Email!", "Email Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the phone
            Regex regexPhone = new Regex(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
            if (check.IsNullOrEmptyEntry(SelectedEmployee.Phone) || !regexPhone.IsMatch(SelectedEmployee.Phone))
            {
                MessageBox.Show("Please Enter a valid Phone!", "Phone Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Salary
            if (check.IsNullOrEmptyEntry(SelectedEmployee.SalaryPerHour))
            {
                MessageBox.Show("Please Enter a valid Salary!", "Salary Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Username
            if (!check.IsValidString(SelectedEmployee.UserName))
            {
                MessageBox.Show("Please Enter a valid Username!", "Username Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Password
            if (!check.IsValidString(SelectedEmployee.Password) || !check.IsValidPassword(SelectedEmployee.Password))
            {
                MessageBox.Show("Please Enter a valid Password!", "Password Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Verify the password
            if (ConfirmPassword != SelectedEmployee.Password)
            {
                MessageBox.Show("Both Entry Password is not match!", "Password Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Image
            if (SelectedEmployee.Image == null || SelectedEmployee.Image.Length == 0)
            {
                MessageBox.Show("Please Upload An Image!", "Image Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Employee em = new Employee(0, SelectedEmployee.Fname, SelectedEmployee.Lname, SelectedEmployee.BirthDate, SelectedEmployee.HiredDate, SelectedEmployee.StreetNo, SelectedEmployee.StreetName, SelectedEmployee.AppNo, SelectedEmployee.Municipality, SelectedEmployee.City, SelectedEmployee.Province, SelectedEmployee.PostalCode, SelectedEmployee.Country, SelectedEmployee.Email, SelectedEmployee.Phone, SelectedEmployee.Rank, SelectedEmployee.Title, SelectedEmployee.SalaryPerHour, SelectedEmployee.UserName, SelectedEmployee.Password, SelectedEmployee.Image);
            DB.updateEmployee(em);
            EmployeeAddedMessage.Default.Send(em);
            MessageBox.Show("Employee Updated Successfully.", "Employee Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
