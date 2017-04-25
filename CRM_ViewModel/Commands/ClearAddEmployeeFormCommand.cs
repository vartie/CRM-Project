using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_ViewModel.Commands
{
    public class ClearAddEmployeeFormCommand : ICommand
    {
        public EmployeesAddTabViewModel ViewModel { get; set; }

        public ClearAddEmployeeFormCommand(EmployeesAddTabViewModel viewmodel)
        {
            this.ViewModel = viewmodel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.btnClearForm_Click();
        }
    }
}
