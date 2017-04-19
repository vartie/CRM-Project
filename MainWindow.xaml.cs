using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Ribbon;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace CRMProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        Database DB;
        DateTime ValidBirthDate = DateTime.Now.AddYears(-25);
        decimal salary;
        public MainWindow()
        {
            try
            {
               // DB = new Database();
                InitializeComponent();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There is a problem in Connecting to the DateBase!", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            DateTime birth, hire;
            refreshAllEmployeeErrorMessages();
            //Validate the First name
            if (tbEmployeeFname.Text.Length < 2 || tbEmployeeFname.Text.Length > 50 || String.IsNullOrEmpty(tbEmployeeFname.Text))
            {
                lblEmployeeFnameError.Content = "Invalid First Name!";
                tbEmployeeFname.Focus();
                return;
            }
            //Validate the Last Name
            if (tbEmployeeLname.Text.Length < 2 || tbEmployeeLname.Text.Length > 50 || String.IsNullOrEmpty(tbEmployeeLname.Text))
            {
                lblEmployeeLnameError.Content = "Invalid Last Name!";
                tbEmployeeLname.Focus();
                return;
            }
            //Validate the Birth Date
            if (String.IsNullOrEmpty(tbEmployeeBirthdate.Text))
            {
                MessageBox.Show("Please Enter a valid Birth Date!", "Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbEmployeeBirthdate.Focus();
                return;
            }
            else
            {
                try
                {
                    if (DateTime.Parse(tbEmployeeBirthdate.Text) > ValidBirthDate)
                    {
                        MessageBox.Show("We can not Hired less than 25 years old!", "Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        tbEmployeeHireddate.Focus();
                        return;
                    }
                    birth = DateTime.Parse(tbEmployeeBirthdate.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please Enter a valid Birth Date!", "Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbEmployeeBirthdate.Focus();
                    return;
                }
                
            }
            // Validate the hired date
            if (String.IsNullOrEmpty(tbEmployeeHireddate.Text))
            {
                MessageBox.Show("Please Enter a valid Hired Date!", "Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbEmployeeHireddate.Focus();
                return;
            }
            else
            {
                try
                {
                    if (DateTime.Parse(tbEmployeeHireddate.Text) > DateTime.Now)
                    {
                        MessageBox.Show("Hired Date must not be after today!", "Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        tbEmployeeHireddate.Focus();
                        return;
                    }
                    hire = DateTime.Parse(tbEmployeeHireddate.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Please Enter a valid Hired Date!", "Date Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbEmployeeHireddate.Focus();
                    return;
                }

            }
            //Validate the Street name
            if (tbEmployeeStreetName.Text.Length < 2 || tbEmployeeStreetName.Text.Length > 50 || String.IsNullOrEmpty(tbEmployeeStreetName.Text))
            {
                lblEmployeeStreetNameError.Content = "Invalid Last Name!";
                tbEmployeeStreetName.Focus();
                return;
            }
            //Validate the Municipality
            if (tbEmployeeMunicipality.Text.Length < 2 || tbEmployeeMunicipality.Text.Length > 50 || String.IsNullOrEmpty(tbEmployeeMunicipality.Text))
            {
                lblEmployeeMunicipalityError.Content = "Invalid Municipality!";
                tbEmployeeMunicipality.Focus();                
                return;
            }
            //Validate the City
            if (tbEmployeeCity.Text.Length < 2 || tbEmployeeCity.Text.Length > 50 || String.IsNullOrEmpty(tbEmployeeCity.Text))
            {
                lblEmployeeCityError.Content = "Invalid City!";
                tbEmployeeCity.Focus();
                return;
            }
            //Validate the Postalcode
            Regex regex = new Regex("[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY][0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ] ?[0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ][0-9]");
            if (tbEmployeePostalcode.Text.Length < 2 || tbEmployeePostalcode.Text.Length > 7 || String.IsNullOrEmpty(tbEmployeePostalcode.Text) || !regex.IsMatch(tbEmployeePostalcode.Text))
            {
                lblEmployeePostalcodeError.Content = "Invalid PostalCode!";
                tbEmployeePostalcode.Focus();
                return;
            }
            //Validate the Country
            if (tbEmployeeCountry.Text.Length < 2 || tbEmployeeCountry.Text.Length > 50 || String.IsNullOrEmpty(tbEmployeeCountry.Text))
            {
                lblEmployeeCountryError.Content = "Invalid Country!";
                tbEmployeeCountry.Focus();
                return;
            }
            //Validate the Salary
            if (tbEmployeeSalary.Text.Length < 2 || tbEmployeeSalary.Text.Length > 50 || String.IsNullOrEmpty(tbEmployeeSalary.Text))
            {
                lblEmployeeSalaryError.Content = "Invalid Salary!";
                tbEmployeeSalary.Focus();
                return;
            }
            else
            {
                try
                {
                    salary = decimal.Parse(tbEmployeeSalary.Text);
                }
                catch (FormatException ex)
                {
                    lblEmployeeSalaryError.Content = "Invalid Salary!";
                    tbEmployeeSalary.Focus();
                    return;
                }
            }
            //Validate the Username
            if (tbEmployeeUsername.Text.Length < 2 || tbEmployeeUsername.Text.Length > 15 || String.IsNullOrEmpty(tbEmployeeUsername.Text))
            {
                lblEmployeeUsernameError.Content = "Invalid Username!";
                tbEmployeeUsername.Focus();
                return;
            }
            //Validate the Password
            if (tbEmployeePassword.Text.Length < 2 || tbEmployeePassword.Text.Length > 15 || String.IsNullOrEmpty(tbEmployeePassword.Text))
            {
                lblEmployeePasswordError.Content = "Invalid Password!";
                tbEmployeePassword.Focus();
                return;
            }


           // Employee e = new Employee(0, tbEmployeeFname.Text, tbEmployeeLname.Text, DateTime.Parse(tbEmployeeBirthdate.Text), DateTime.Parse(tbEmployeeHireddate.Text), int.Parse(tbEmployeeStreetNo.Text), tbEmployeeStreetName.Text, int.Parse(tbEmployeeAppNo.Text), tbEmployeeMunicipality.Text, tbEmployeeCity.Text, cmbEmployeeProvince.Text, tbEmployeePostalcode.Text, tbEmployeeCountry, cmbRank.Text, cmbTitle.Text, salary, tbEmployeeUsername.Text, tbEmployeePassword.Text);

        }

        private void btnEmployeeUploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
               imgEmployeeImage.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void refreshAllEmployeeErrorMessages()
        {
            lblEmployeeFnameError.Content = "";
            lblEmployeeLnameError.Content = "";
            lblEmployeeStreetNoError.Content = "";
            lblEmployeeStreetNameError.Content = "";
            lblEmployeeAppNoError.Content = "";
            lblEmployeeMunicipalityError.Content = "";
            lblEmployeeCityError.Content = "";
            lblEmployeePostalcodeError.Content = "";
            lblEmployeeCountryError.Content = "";
            lblEmployeeSalaryError.Content = "";
            lblEmployeeUsernameError.Content = "";
            lblEmployeePasswordError.Content = "";  
        }

        private void tbEmployeeBirthdate_GotFocus(object sender, RoutedEventArgs e)
        {
            tbEmployeeBirthdate.Text = "";
        }

        private void tbEmployeeHireddate_GotFocus(object sender, RoutedEventArgs e)
        {
            tbEmployeeHireddate.Text = "";
        }

        
    }
}
