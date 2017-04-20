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

namespace CRMProject.View
{
    /// <summary>
    /// Interaction logic for EmployeesHomeTabView.xaml
    /// </summary>
    public partial class EmployeesHomeTabView : UserControl
    {
        public EmployeesHomeTabView()
        {
            InitializeComponent();
        }

        private void tbSearchEmployeeByName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbSearchEmployeeByName.Text = "";
        }

        private void tbSearchEmployeeByName_TextChanged(object sender, TextChangedEventArgs e)
        {
           
           
        }
    }
}
