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
using CRM_ViewModel;
using CRM_ExtraSelfDesignLibraries;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace CRM_View.Views
{
    /// <summary>
    /// Interaction logic for EmployeesAddTabView.xaml
    /// </summary>
    public partial class EmployeesAddTabView : UserControl
    {
       

        public EmployeesAddTabView()
        {
            InitializeComponent();             
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        
    }
}
