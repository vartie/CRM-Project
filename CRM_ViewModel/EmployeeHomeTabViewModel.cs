using CRM_Model;
using System.Data.SqlClient;
using System.Windows;
using System.ComponentModel;
using CRM_ExtraSelfDesignLibraries;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CRM_ViewModel.Commands;
using System;

namespace CRM_ViewModel
{
    public class EmployeeHomeTabViewModel
    {
        //All Fields
        DataBase DB;
        public DeletePopupMenuHomeEmployeeTabCommand DeleteCommand { get; set; }
        private string _SearchEmployee;
        private ObservableCollection<Employee> _Employees;
        private Employee _SelectedEmployee;
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
       

        //Constructor
        public EmployeeHomeTabViewModel()
        {
            //Register for messages from different viewModels
            EmployeeAddedMessage.Default.Register<Employee>(this, (employee) =>
            {
                ReceiveMessage(employee);
            });
            //Initialize comopents with some values
            Employees = new ObservableCollection<Employee>();

            //Register CollectionChangedEvent for the Employees
            Employees.CollectionChanged += ContentCollectionChanged;

            this.DeleteCommand = new DeletePopupMenuHomeEmployeeTabCommand(this);
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
            Employees.Clear();
            tempList.Clear();
            tempList = DB.getAllEmployee();
            foreach (Employee e in tempList)
            {
                Employees.Add(e);
            }
        }

        //Popup Delete buttom Clicked
        public void popupDelete_Click()
        {
            if (SelectedEmployee != null)
            {
                var result = MessageBox.Show("Are You Sure You Want to Delete!?", "Delete Employee", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && SelectedEmployee.Id > 0)
                {
                    DB.deleteEmployeeById(SelectedEmployee.Id);
                    EmployeeAddedMessage.Default.Send(SelectedEmployee);
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
