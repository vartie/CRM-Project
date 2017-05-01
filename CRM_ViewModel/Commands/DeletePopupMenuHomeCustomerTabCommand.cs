using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_ViewModel.Commands
{
    public class DeletePopupMenuHomeCustomerTabCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public CustomerHomeTabViewModel ViewModel { get; set; }

        public DeletePopupMenuHomeCustomerTabCommand(CustomerHomeTabViewModel viewmodel)
        {
            this.ViewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.popupDelete_Click();
        }
    }
}
