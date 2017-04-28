using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_ViewModel.Commands
{
    public class EditEmployeeCommand : ICommand
    {
        public EmployeeEditTabViewModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public EditEmployeeCommand(EmployeeEditTabViewModel viewmodel)
        {
            this.ViewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.btnUpdate_Click();
        }
    }
}
