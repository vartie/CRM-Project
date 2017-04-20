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
        public EmployeesHomeTabViewModel()
        {
            try
            {
                DB = new Database();
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
    }
}
