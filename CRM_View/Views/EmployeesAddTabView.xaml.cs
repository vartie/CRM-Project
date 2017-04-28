using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

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
