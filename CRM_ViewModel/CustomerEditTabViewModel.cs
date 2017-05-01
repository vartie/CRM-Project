using CRM_ExtraSelfDesignLibraries;
using CRM_Model;
using CRM_ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace CRM_ViewModel
{
    public class CustomerEditTabViewModel
    {
        //All Fields
        DataBase DB;
        private string _SearchCustomer;
        private ObservableCollection<Customer> _Customers;
        private Customer _SelectedCustomer;
        MyValidations check;

        //Temprory List
        ObservableCollection<Customer> tempList = new ObservableCollection<Customer>();

        // All Properties
        public string SearchCustomer
        {
            get { return _SearchCustomer; }
            set
            {
                if (_SearchCustomer != value)
                {
                    _SearchCustomer = value;
                    RaisePropertyChanged("SearchCustomer");
                    if (String.IsNullOrEmpty(_SearchCustomer))
                    {
                        Customers.Clear();
                        foreach (Customer c in tempList)
                        {
                            Customers.Add(c);
                        }
                    }
                    else
                    {
                        foreach (Customer c in tempList)
                        {
                            if (!(c.Fname.ToLower().Contains(SearchCustomer)) && !(c.Lname.ToLower().Contains(SearchCustomer)))
                            {
                                Customers.Remove(c);
                            }
                        }
                    }
                }
            }
        }
        public ObservableCollection<Customer> Customers
        {
            get { return _Customers; }
            set
            {
                if (_Customers != value)
                {
                    _Customers = value;
                    RaisePropertyChanged("Customers");
                }
            }
        }
        public Customer SelectedCustomer
        {
            get
            {
                return _SelectedCustomer;
            }

            set
            {
                if (_SelectedCustomer != value && value != null)
                {
                    _SelectedCustomer = value;
                    RaisePropertyChanged("SelectedCustomer");
                }
            }
        }
        public ObservableCollection<string> Provinces { get; }
        public EditeCustomerCommand EditCustomer { get; set; }

        //Constructor
        public CustomerEditTabViewModel()
        {
            //Register for messages from different viewModels
            CustomerAddedMessage.Default.Register<Customer>(this, (customer) =>
            {
                ReceiveMessage(customer);
            });
            //Initialize comopents with some values
            Customers = new ObservableCollection<Customer>();

            //Register CollectionChangedEvent for the Customers
            Customers.CollectionChanged += ContentCollectionChanged;
            this.Provinces = new ObservableCollection<string>() { "Ontario(ON)", "Quebec(QC)", "Nova Scotia(NS)", "New Brunswick(NB)", "Manitoba(MB)", "British Columbia(BC)", "Prince Edward Island(PE)", "Saskatchewan(SK)", "Alberta(AB)", "Newfoundland(NL)" };
            this.EditCustomer = new EditeCustomerCommand(this);
            check = new MyValidations();
            try
            {
                DB = new DataBase();
                LoadAllCustomersList();
                foreach (Customer c in Customers)
                {
                    tempList.Add(c);
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
        //When the message recived 
        private void ReceiveMessage(Customer customer)
        {
            Customers.Clear();
            tempList.Clear();
            tempList = DB.getAllCustomers();
            foreach (Customer c in tempList)
            {
                Customers.Add(c);
            }
        }

        //Load All Customer List Method
        public void LoadAllCustomersList()
        {
            Customers = DB.getAllCustomers();
            RaisePropertyChanged("Customers");
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
        
        //Button Edit Customer Clicked
        public void btnEditCustomer_Click()
        {
            //Validate the First name
            if (!check.IsValidString(SelectedCustomer.Fname))
            {
                MessageBox.Show("Please Enter a valid First Name!", "Invalid First Name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Last Name
            if (!check.IsValidString(SelectedCustomer.Lname))
            {
                MessageBox.Show("Please Enter a valid Last Name!", "Invalid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Birth Date
            if (!check.IsValidBirthDay(SelectedCustomer.BirthDate) || check.IsNullOrEmptyEntry(SelectedCustomer.BirthDate))
            {
                MessageBox.Show("Please Enter a valid Birth Date!", "Birth Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Validate the hired date
            if (!check.IsValidHiredDay(SelectedCustomer.RegisterDate) || check.IsNullOrEmptyEntry(SelectedCustomer.RegisterDate))
            {
                MessageBox.Show("Please Enter a valid Register Date!", "Hired Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Street Number
            if (SelectedCustomer.StreetNo <= 0)
            {
                MessageBox.Show("Please Enter a valid Street Number!", "Street Number Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Street Name
            if (!check.IsValidString(SelectedCustomer.StreetName))
            {
                MessageBox.Show("Please Enter a valid Street Name!", "Street Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Apartment Number
            if (SelectedCustomer.AppNo <= 0)
            {
                MessageBox.Show("Please Enter a valid Apartment Number!", "Apartment Number Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Municipality
            if (!check.IsValidString(SelectedCustomer.Municipality))
            {
                MessageBox.Show("Please Enter a valid Municipality!", "Municipality Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the City
            if (!check.IsValidString(SelectedCustomer.City))
            {
                MessageBox.Show("Please Enter a valid City!", "City Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Postalcode
            Regex regexPostalcode = new Regex("[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY][0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ] ?[0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ][0-9]");
            if (!check.IsValidString(SelectedCustomer.PostalCode) || !regexPostalcode.IsMatch(SelectedCustomer.PostalCode))
            {
                MessageBox.Show("Please Enter a valid Postal Code!", "Postal Code Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the Country
            if (!check.IsValidString(SelectedCustomer.Country))
            {
                MessageBox.Show("Please Enter a valid Country!", "Country Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validatye the Email Address
            if (check.IsNullOrEmptyEntry(SelectedCustomer.Email))
            {
                MessageBox.Show("Please Enter a valid Email!", "Email Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Validate the phone
            Regex regexPhone = new Regex(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
            if (check.IsNullOrEmptyEntry(SelectedCustomer.Phone) || !regexPhone.IsMatch(SelectedCustomer.Phone))
            {
                MessageBox.Show("Please Enter a valid Phone!", "Phone Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Customer cm = new Customer(SelectedCustomer.Id, SelectedCustomer.Fname, SelectedCustomer.Lname, SelectedCustomer.BirthDate, SelectedCustomer.RegisterDate, SelectedCustomer.StreetNo, SelectedCustomer.StreetName, SelectedCustomer.AppNo, SelectedCustomer.Municipality, SelectedCustomer.City, SelectedCustomer.Province, SelectedCustomer.PostalCode, SelectedCustomer.Country, SelectedCustomer.Email, SelectedCustomer.Phone);
            DB.updateCustomer(cm);
            CustomerAddedMessage.Default.Send(cm);
            MessageBox.Show("Customer Added Successfully.", "Customer Added", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
