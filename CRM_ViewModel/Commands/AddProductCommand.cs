﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRM_ViewModel.Commands
{
    public class AddProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ProductViewModel ViewModel { get; set; }

        public AddProductCommand(ProductViewModel viewmodel)
        {
            this.ViewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           this.ViewModel.btnAddProduct_Click();
        }
    }
}
