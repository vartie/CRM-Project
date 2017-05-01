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
using System.Threading.Tasks;
using System.Windows;

namespace CRM_ViewModel
{
    public class CustomerHomeTabViewModel
    {
        //All Fields
        DataBase DB;
        private string _SearchCustomer;
        private ObservableCollection<Customer> _Customers;
        private Customer _SelectedCustomer;

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
        public DeletePopupMenuHomeCustomerTabCommand DeleteCommand { get; set; }

        //Constructor
        public CustomerHomeTabViewModel()
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

            this.DeleteCommand = new DeletePopupMenuHomeCustomerTabCommand(this);

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

        //Popup Delete buttom Clicked
        public void popupDelete_Click()
        {
            if (SelectedCustomer != null)
            {
                var result = MessageBox.Show("Are You Sure You Want to Delete!?", "Delete Customer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && SelectedCustomer.Id > 0)
                {
                    DB.deleteCustumerById(SelectedCustomer.Id);
                    CustomerAddedMessage.Default.Send(SelectedCustomer);
                    MessageBox.Show("Employee deleted successfully.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select an Employee first.");
                return;
            }

        }
    }
}
