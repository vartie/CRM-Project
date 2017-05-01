using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model
{
    public class Product
    {
        private int _Id;
        private string _Name;
        private decimal _Price;
        private decimal _Discount;
        private int _Qty;
        private string _Catalog;
        private DateTime _StartDiscountDate;
        private DateTime _EndtDiscountDate;

        public Product()
        {

        }
        public Product(int _Id, string _Name, decimal _Price, decimal _Discount, int _Qty, string _Catalog, DateTime _StartDiscountDate, DateTime _EndtDiscountDate)
        {
            Id = _Id;
            Name = _Name;
            Price = _Price;
            Discount = _Discount;
            Qty = _Qty;
            Catalog = _Catalog;
            StartDiscountDate = _StartDiscountDate;
            EndtDiscountDate = _EndtDiscountDate;
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        public string Catalog
        {
            get { return _Catalog; }
            set { _Catalog = value; }
        }
        public DateTime StartDiscountDate
        {
            get{return _StartDiscountDate;}
            set{_StartDiscountDate = value;}
        }
        public DateTime EndtDiscountDate
        {
            get{return _EndtDiscountDate;}
            set { _EndtDiscountDate = value; }
        }
        public decimal Discount
        {
            get{return _Discount;}
            set{_Discount = value;}
        }
    }
}
