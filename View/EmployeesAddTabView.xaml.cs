using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CRMProject.View
{
    /// <summary>
    /// Interaction logic for EmployeesAddTabView.xaml
    /// </summary>
    public partial class EmployeesAddTabView : UserControl
    {
        Database DB;
        DateTime ValidBirthDate = DateTime.Now.AddYears(-25);
        char[] Rank = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
        private byte[] m_barrImg;
        private long m_lImageFileLength = 0;
        decimal salary;
        public EmployeesAddTabView()
        {
            try
            {
                DB = new Database();
                InitializeComponent();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There is a problem in Connecting to the DateBase!", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            tbEmployeeBirthdate.Foreground = Brushes.Gray;
            tbEmployeeHireddate.Foreground = Brushes.Gray;
            tbEmployeePhone.Foreground = Brushes.Gray;
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
            Regex regexPostalcode = new Regex("[abceghjklmnprstvxyABCEGHJKLMNPRSTVXY][0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ] ?[0-9][abceghjklmnprstvwxyzABCEGHJKLMNPRSTVWXYZ][0-9]");
            if (tbEmployeePostalcode.Text.Length < 2 || tbEmployeePostalcode.Text.Length > 7 || String.IsNullOrEmpty(tbEmployeePostalcode.Text) || !regexPostalcode.IsMatch(tbEmployeePostalcode.Text))
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
            //Validatye the Email Address
            try
            {
                MailAddress m = new MailAddress(tbEmployeeEmail.Text);
            }
            catch (FormatException)
            {
                lblEmployeeEmailError.Content = "Invalid Email Address!";
                tbEmployeeEmail.Focus();
                return;
            }
            //Validate the phone
            Regex regexPhone = new Regex(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
            if (tbEmployeePhone.Text.Length < 0 || tbEmployeePhone.Text.Length > 12 || String.IsNullOrEmpty(tbEmployeePhone.Text) || !regexPhone.IsMatch(tbEmployeePhone.Text))
            {
                lblEmployeePhoneError.Content = "Invalid Phone Number!";
                tbEmployeePhone.Focus();
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
            if (tbEmployeePassword.Password.Length < 2 || tbEmployeePassword.Password.Length > 15 || String.IsNullOrEmpty(tbEmployeePassword.Password.ToString()))
            {
                lblEmployeePasswordError.Content = "Invalid Password!";
                tbEmployeePassword.Focus();
                return;
            }
            //Verify the password
            if (tbEmployeePassword.Password != tbEmployeeVerifyPassword.Password)
            {
                lblEmployeeVerifyPasswordError.Content = "Passwords must match.";
                tbEmployeeVerifyPassword.Focus();
                return;
            }
            //Validate the Image
            if (m_barrImg == null || m_barrImg.Length == 0)
            {
                lblEmployeeImageError.Content = "Please Uploade an image.";
                return;
            }
            try
            {
                string title = ((ComboBoxItem)cmbTitle.SelectedItem).Content.ToString();
                string province = ((ComboBoxItem)cmbEmployeeProvince.SelectedItem).Content.ToString();
                //MessageBox.Show(tbEmployeeFname.Text, "Employee Added", MessageBoxButton.OK, MessageBoxImage.Information);
                Employee em = new Employee(0, tbEmployeeFname.Text, tbEmployeeLname.Text, DateTime.Parse(tbEmployeeBirthdate.Text), DateTime.Parse(tbEmployeeHireddate.Text), int.Parse(tbEmployeeStreetNo.Text), tbEmployeeStreetName.Text, int.Parse(tbEmployeeAppNo.Text), tbEmployeeMunicipality.Text, tbEmployeeCity.Text, province, tbEmployeePostalcode.Text, tbEmployeeCountry.Text, tbEmployeeEmail.Text, tbEmployeePhone.Text, Rank[cmbRank.SelectedIndex], title, salary, tbEmployeeUsername.Text, tbEmployeePassword.Password.ToString(), m_barrImg);
                DB.addEmployee(em);
                MessageBox.Show("Employee Added Successfully.", "Employee Added", MessageBoxButton.OK, MessageBoxImage.Information);
                cleanAllEmployeeTextBoxInAddForm();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }


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
                try
                {
                    string strFn = op.FileName;
                    imgEmployeeImage.Source = new BitmapImage(new Uri(strFn));
                    FileInfo fiImage = new FileInfo(strFn);
                    this.m_lImageFileLength = fiImage.Length;
                    FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                    m_barrImg = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                    int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(this.m_lImageFileLength));
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            lblEmployeeEmailError.Content = "";
            lblEmployeePhoneError.Content = "";
            lblEmployeeSalaryError.Content = "";
            lblEmployeeUsernameError.Content = "";
            lblEmployeePasswordError.Content = "";
            lblEmployeeVerifyPasswordError.Content = "";
        }
        private void cleanAllEmployeeTextBoxInAddForm()
        {
            tbEmployeeFname.Text = "";
            tbEmployeeLname.Text = "";
            tbEmployeeAppNo.Text = "";
            tbEmployeeCity.Text = "";
            tbEmployeeCountry.Text = "";
            tbEmployeeEmail.Text = "";
            tbEmployeePhone.Text = "";
            tbEmployeeMunicipality.Text = "";
            tbEmployeeSalary.Text = "";
            tbEmployeePostalcode.Text = "";
            tbEmployeeStreetName.Text = "";
            tbEmployeeStreetNo.Text = "";
            tbEmployeeUsername.Text = "";
            tbEmployeePassword.Password = "";
            tbEmployeeVerifyPassword.Password = "";
            tbEmployeeHireddate.Text = "YYYY/MM/DD";
            tbEmployeeBirthdate.Text = "YYYY/MM/DD";
            tbEmployeePhone.Text = "000-000-0000";
            tbEmployeeBirthdate.Foreground = Brushes.Gray;
            tbEmployeeHireddate.Foreground = Brushes.Gray;
            tbEmployeePhone.Foreground = Brushes.Gray;
            imgEmployeeImage.Source = new BitmapImage(new Uri(@"C:\Users\ipd\Documents\CRM-Project\Images\personal.png"));

        }

        private void tbEmployeeBirthdate_GotFocus(object sender, RoutedEventArgs e)
        {
            tbEmployeeBirthdate.Text = "";
            tbEmployeeBirthdate.Foreground = Brushes.Black;

        }

        private void tbEmployeeHireddate_GotFocus(object sender, RoutedEventArgs e)
        {
            tbEmployeeHireddate.Text = "";
            tbEmployeeHireddate.Foreground = Brushes.Black;
        }



        private void btnClearAddEmployeeForm_Click(object sender, RoutedEventArgs e)
        {
            cleanAllEmployeeTextBoxInAddForm();
        }

        private void tbEmployeePhone_GotFocus(object sender, RoutedEventArgs e)
        {
            tbEmployeePhone.Text = "";
            tbEmployeePhone.Foreground = Brushes.Black;
        }

    }
}
