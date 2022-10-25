using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Pantry.models;
using Pantry.models.types;
using Xamarin.Forms;

namespace Pantry.models
{
    [Serializable]
    public class Product : IComparable, IProduct
    {
        public string ProductName { get; set; }

        private DateTime _date;
        public DateTime ExpiryDate { get { return _date; } set { _date = value; ProductColor = SelectColor.SetColor(value); } }

        public string ProductColor { get; set; }

        public string DaysLeft { get; set; }
        public ProductType ProductType { get; set; }
        public string ImageSource { get; set; }

        public int CompareTo(object obj)
        {
            Product b = (Product)obj;
            return ExpiryDate.CompareTo(b.ExpiryDate);
        }
        public void Update()
        {
            ProductColor = SelectColor.SetColor(ExpiryDate);
            DaysLeft = SelectColor.DisplayDaysLeft();
        }
    }
}
