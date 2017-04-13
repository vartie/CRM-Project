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

namespace CRMProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        Database DB;
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

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            

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
    }
}
