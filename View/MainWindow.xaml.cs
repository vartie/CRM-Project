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
using System.IO;
using System.Net.Mail;


namespace CRMProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
       
       
        public MainWindow()
        {            
                InitializeComponent();        
        }

        private void EmployeesHomeTabViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            CRMProject.ViewModel.EmployeesHomeTabViewModel EmployeesHomeTabViewModelObject = new CRMProject.ViewModel.EmployeesHomeTabViewModel();
            EmployeesHomeTabViewModelObject.LoadEmployees();
            EmployeesHomeTabView.DataContext = EmployeesHomeTabViewModelObject;
        }
     
    }
}
