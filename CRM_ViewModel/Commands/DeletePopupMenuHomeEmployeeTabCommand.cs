using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_ViewModel.Commands
{
   public  class DeletePopupMenuHomeEmployeeTabCommand : ICommand
    {
        public EmployeeHomeTabViewModel ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public DeletePopupMenuHomeEmployeeTabCommand(EmployeeHomeTabViewModel viewmodel)
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
