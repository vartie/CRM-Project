using CRM_ExtraSelfDesignLibraries;
using CRM_Model;
using CRM_ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRM_ViewModel
{
    public class ProductViewModel
    {
        //All Fields
        DataBase DB;
        private string _SearchProduct;
        private ObservableCollection<Product> _Products;
        private Product _SelectedProduct;
        MyValidations check;
        private int _Id;
        private string _Name;
        private decimal _Price;
        private decimal _Discount;
        private int _Qty;
        private string _Catalog;
        private DateTime _StartDiscountDate;
        private DateTime _EndtDiscountDate;

        //Temprory List
        ObservableCollection<Product> tempList = new ObservableCollection<Product>();

        // All Properties
        public string SearchProduct
        {
            get { return _SearchProduct; }
            set
            {
                if (_SearchProduct != value)
                {
                    _SearchProduct = value;
                    RaisePropertyChanged("SearchProduct");
                    if (String.IsNullOrEmpty(_SearchProduct))
                    {
                        Products.Clear();
                        foreach (Product p in tempList)
                        {
                            Products.Add(p);
                        }
                    }
                    else
                    {
                        foreach (Product p in tempList)
                        {
                            if (!(p.Name.ToLower().Contains(SearchProduct)) && !(p.Catalog.ToLower().Contains(SearchProduct)))
                            {
                                Products.Remove(p);
                            }
                        }
                    }
                }
            }
        }
        public ObservableCollection<Product> Products
        {
            get { return _Products; }
            set
            {
                if (_Products != value)
                {
                    _Products = value;
                    RaisePropertyChanged("Customers");
                }
            }
        }
        public Product SelectedProduct
        {
            get
            {
                return _SelectedProduct;
            }

            set
            {
                
                if (_SelectedProduct != value && value != null)
                {
                    _SelectedProduct = value;
                    RaisePropertyChanged("SelectedCustomer");
                    //Id = SelectedProduct.Id;
                    //RaisePropertyChanged("Id");
                    //Name = SelectedProduct.Name;
                    //RaisePropertyChanged("Name");
                    //Catalog = SelectedProduct.Catalog;
                    //RaisePropertyChanged("Catalog");
                    //Price = SelectedProduct.Price;
                    //RaisePropertyChanged("Price");
                    //Qty = SelectedProduct.Qty;
                    //RaisePropertyChanged("Qty");
                    //Discount = SelectedProduct.Discount;
                    //RaisePropertyChanged("Discount");
                    //StartDiscountDate = SelectedProduct.StartDiscountDate;
                    //RaisePropertyChanged("StartDiscountDate");
                    //EndtDiscountDate = SelectedProduct.EndtDiscountDate;
                    //RaisePropertyChanged("EndtDiscountDate");
                }              
            }
        }
        public ObservableCollection<string> Catalogs { get; }
        public AddProductCommand AddProduct { get; set; }
        public EditProductCommand EditProduct { get; set; }
        public DeleteProductCommand DeleteProduct { get; set; }
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get { return _Name; }
            set {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public decimal Price
        {
            get { return _Price; }
            set {
                if (_Price != value)
                {
                    _Price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }
        public int Qty
        {
            get { return _Qty; }
            set {
                if (_Qty != value)
                {
                    _Qty = value;
                    RaisePropertyChanged("Qty");
                }
            }
        }
        public string Catalog
        {
            get { return _Catalog; }
            set {
                if (_Catalog != value)
                {
                    _Catalog = value;
                    RaisePropertyChanged("Catalog");
                }
            }
        }
        public DateTime StartDiscountDate
        {
            get { return _StartDiscountDate; }
            set
            {
                if (_StartDiscountDate != value)
                {
                    _StartDiscountDate = value;
                    RaisePropertyChanged("StartDiscountDate");
                }
            }
        }
        public DateTime EndtDiscountDate
        {
            get { return _EndtDiscountDate; }
            set {
                if (_EndtDiscountDate != value)
                {
                    _EndtDiscountDate = value;
                    RaisePropertyChanged("EndtDiscountDate");
                }
            }
        }
        public decimal Discount
        {
            get { return _Discount; }
            set {
                if (_Discount != value)
                {
                    _Discount = value;
                    RaisePropertyChanged("Discount");
                }
            }
        }

        //Constructor
        public ProductViewModel()
        {
            //Register for messages from different viewModels
            ProductAddedMessage.Default.Register<Product>(this, (product) =>
            {
                ReceiveMessage(product);
            });
            //Initialize comopents with some values
            Products = new ObservableCollection<Product>();

            //Register CollectionChangedEvent for the Customers
            Products.CollectionChanged += ContentCollectionChanged;

            this.Catalogs = new ObservableCollection<string>() { "Softwares", "Hardwares" };
            this.AddProduct = new AddProductCommand(this);
            this.EditProduct = new EditProductCommand(this);
            this.DeleteProduct = new DeleteProductCommand(this);

            check = new MyValidations();
            try
            {
                DB = new DataBase();
                LoadAllProductList();
                foreach (Product p in Products)
                {
                    tempList.Add(p);
                }
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

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Employees");
        }
        //When the message recived 
        private void ReceiveMessage(Product product)
        {
            Products.Clear();
            tempList.Clear();
            tempList = DB.getAllProducts();
            foreach (Product p in tempList)
            {
                Products.Add(p);
            }
        }

        //Load All Product List Method
        public void LoadAllProductList()
        {
            Products = DB.getAllProducts();
            RaisePropertyChanged("Customers");
        }

        //Button Add Product Clicked
        public void btnAddProduct_Click()
        {
            //Validate the Product name
            if (!check.IsValidString(Name))
            {
                MessageBox.Show("Please Enter a valid Product Name!", "Invalid Product Name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Product Catalog
            if (!check.IsValidString(Catalog))
            {
                MessageBox.Show("Please Enter a valid Product Catalog!", "Invalid Product Catalog", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Product price
            if (Price <= 0 || check.IsNullOrEmptyEntry(Price))
            {
                MessageBox.Show("Please Enter a valid Price!", "Invalid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Product Qty
            if (Qty <= 0 || check.IsNullOrEmptyEntry(Qty))
            {
                MessageBox.Show("Please Enter a valid Quantity!", "Invalid Quantity", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the Product Discount
            if (Discount < 0 || check.IsNullOrEmptyEntry(Discount))
            {
                MessageBox.Show("Please Enter a valid Price!", "Invalid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the start Discount Date
            if (!check.IsValidDate(StartDiscountDate) || check.IsNullOrEmptyEntry(StartDiscountDate))
            {
                MessageBox.Show("Please Enter a valid Start Date!", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Validate the End Discount Date
            if (!check.IsValidDate(EndtDiscountDate) || check.IsNullOrEmptyEntry(EndtDiscountDate) || EndtDiscountDate < StartDiscountDate)
            {
                MessageBox.Show("Please Enter a valid End Date!", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product p = new Product(0, Name, Price, Discount, Qty, Catalog, StartDiscountDate, EndtDiscountDate);
            DB.addProduct(p);
            ProductAddedMessage.Default.Send(p);
            MessageBox.Show("Customer Added Successfully.", "Customer Added", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //Button Upadate Product Clicked
        public void btnUpdateProduct_Click()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please Select a Product First!", "Product Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                //Validate the Product name
                if (!check.IsValidString(SelectedProduct.Name))
                {
                    MessageBox.Show("Please Enter a valid Product Name!", "Invalid Product Name", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate the Product Catalog
                if (!check.IsValidString(SelectedProduct.Catalog))
                {
                    MessageBox.Show("Please Enter a valid Product Catalog!", "Invalid Product Catalog", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate the Product price
                if (SelectedProduct.Price <= 0 || check.IsNullOrEmptyEntry(SelectedProduct.Price))
                {
                    MessageBox.Show("Please Enter a valid Price!", "Invalid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate the Product Qty
                if (SelectedProduct.Qty <= 0 || check.IsNullOrEmptyEntry(SelectedProduct.Qty))
                {
                    MessageBox.Show("Please Enter a valid Quantity!", "Invalid Quantity", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate the Product Discount
                if (SelectedProduct.Discount < 0 || check.IsNullOrEmptyEntry(SelectedProduct.Discount))
                {
                    MessageBox.Show("Please Enter a valid Price!", "Invalid Data", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate the start Discount Date
                if (!check.IsValidDate(SelectedProduct.StartDiscountDate) || check.IsNullOrEmptyEntry(SelectedProduct.StartDiscountDate))
                {
                    MessageBox.Show("Please Enter a valid Start Date!", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //Validate the End Discount Date
                if (!check.IsValidDate(SelectedProduct.EndtDiscountDate) || check.IsNullOrEmptyEntry(SelectedProduct.EndtDiscountDate) || SelectedProduct.EndtDiscountDate < SelectedProduct.StartDiscountDate)
                {
                    MessageBox.Show("Please Enter a valid End Date!", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Product p = new Product(SelectedProduct.Id, SelectedProduct.Name, SelectedProduct.Price, SelectedProduct.Discount, SelectedProduct.Qty, SelectedProduct.Catalog, SelectedProduct.StartDiscountDate, SelectedProduct.EndtDiscountDate);
                DB.updateProduct(p);
                ProductAddedMessage.Default.Send(p);
                MessageBox.Show("Customer Updated Successfully.", "Customer Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Button Delete Product Clicked
        public void btnDeleteProduct_Click()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Please Select a Product First!", "Product Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                var result = MessageBox.Show("Are You Sure You Want to Delete!?", "Delete Product", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && SelectedProduct.Id > 0)
                {
                    DB.deleteProductById(SelectedProduct.Id);
                    ProductAddedMessage.Default.Send(SelectedProduct);
                    MessageBox.Show("Product deleted successfully.");
                    return;
                }
            }
        }

    }
}
