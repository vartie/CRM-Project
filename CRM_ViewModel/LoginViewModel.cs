using CRM_ExtraSelfDesignLibraries;
using CRM_Model;
using CRM_ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRM_ViewModel
{
    public class LoginViewModel //: ViewModel
    {
        private string _Username;
        private string _Password;
        DataBase DB;
        MyValidations check;

        public string Username
        {
            get
            {
                return _Username;
            }

            set
            {
                if (_Username != value)
                {
                    _Username = value;
                    RaisePropertyChanged("Username");
                }
               
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }
        public LoginCommand login { get; set; }

        public LoginViewModel()
        {
            this.login = new LoginCommand(this);
            check = new MyValidations();
            try
            {
                DB = new DataBase();
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

        //Button Login Clicked
        public void btnLogin_Click()
        {
            if (check.IsNullOrEmptyEntry(Username))
            {
                MessageBox.Show("Please Enter a valid Username!", "Username Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (check.IsNullOrEmptyEntry(Password))
            {
                MessageBox.Show("Please Enter a valid Password!", "Password Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Employee e = DB.getLoginEmployee(Username,Password);
            if(e == null)
            {
                MessageBox.Show("Invalid Username or Password!", "Invalid User", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                EmployeeLoginMessage.Default.Send("ok");
                EmployeeLoginMessage.Default.Send(e);

            }
        }
    }
}
