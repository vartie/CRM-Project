using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_ViewModel.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        public EmployeesAddTabViewModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public AddEmployeeCommand(EmployeesAddTabViewModel viewmodel)
        {
            this.ViewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.btnAddEmployee_Click();
        }
    }
}
