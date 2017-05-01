using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_ViewModel.Commands
{
    public class AddCustomerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public CustomerAddTabViewModel ViewModel { get; set; }

        public AddCustomerCommand(CustomerAddTabViewModel viewmodel)
        {
            this.ViewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.btnAddCustomer_Click();
        }
    }
}
