using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_ViewModel.Commands;
using CRM_Model;
using System.Data.SqlClient;
using System.Windows;
using System.ComponentModel;

namespace CRM_ViewModel
{
    public class EmployeeHomeTabViewModel
    {
        //All Fields
        DataBase DB;
        private string _SearchEmployee;
        private List<Employee> _Employees;
        private Employee _SelectedEmployee;
        private string _FullAddress;

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
                    if (_SearchEmployee == "")
                    {
                        LoadAllEmployeeList();
                    }
                    else
                    {
                        var filteredList = from e in Employees
                                           where (e.Fname.ToLower().Contains(SearchEmployee) || e.Lname.ToLower().Contains(SearchEmployee) || e.Title.ToLower().Contains(SearchEmployee))
                                           select e;

                        Employees = filteredList.ToList<Employee>();
                        MessageBox.Show("ali");
                    }
                }
            }
        }
        public List<Employee> Employees
        {
            get
            {
                return _Employees;
            }

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
                if (_SelectedEmployee != value)
                {
                    _SelectedEmployee = value;
                    RaisePropertyChanged("SelectedEmployee");
                    FullAddress = SelectedEmployee.UserName;
                    //RaisePropertyChanged("FullAddress");
                }
            }
        }
        public string FullAddress
        {
            get
            {
                return _FullAddress;
            }
            set
            {
                if (_FullAddress != value)
                {
                    _FullAddress = value;
                    RaisePropertyChanged("FullAddress");
                }
            }
        }

        //Constructor
        public EmployeeHomeTabViewModel()
        {
            try
            {
                DB = new DataBase();
                LoadAllEmployeeList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There is a problem in Connecting to the DateBase!", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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

  

//Load All Employee List Method
public void LoadAllEmployeeList()
        {
            Employees = DB.getAllEmployee();
        }
    }
}
