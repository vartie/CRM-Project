using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRMProject.ViewModel
{
    class EmployeesHomeTabViewModel
    {
        Database DB;
        public MyICommand SearchEmployee { get; set; }
        private string _SearchCriteria;
        public string SearchCriteria { get { return _SearchCriteria; } set { _SearchCriteria = value; SearchEmployee.RaiseCanExecuteChanged(); } }
        public EmployeesHomeTabViewModel()
        {
            try
            {
                DB = new Database();
                LoadEmployees();
                SearchEmployee = new MyICommand(SearchEmployeeByName);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There is a problem in Connecting to the DateBase!", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public List<Employee> Employees
        {
            get;
            set;
        }

        public void LoadEmployees()
        {
            Employees = DB.getAllEmployee();
        }

        private void SearchEmployeeByName()
        {
            if (SearchCriteria == "")
            {
                LoadEmployees();
            }
            else
            {
                List<Employee> list = DB.getAllEmployee();

                var filteredList = from b in list
                                   where b.Fname.ToLower().Contains(SearchCriteria)
                                   select b;

                Employees =(List<Employee>)filteredList;
            }

        }
    }
}
