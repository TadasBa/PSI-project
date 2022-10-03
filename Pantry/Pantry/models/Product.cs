using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Pantry.models;
using Xamarin.Forms;

namespace Pantry.models
{
    [Serializable]
    public class Product : IComparable
    {
        public string productName { get; set; }
        public DateTime expiryDate { get; set; }
        public string productColor { get; set; }
        public string daysLeft { get; set; }

        public ProductType type { get; set; }

        public int CompareTo(object obj)
        {
            Product a = this;
            Product b = (Product)obj;
            return a.expiryDate.CompareTo(b.expiryDate);
        }
        public void Update()
        {
            productColor = SelectColor.SetColor(expiryDate);
            daysLeft = SelectColor.DisplayDaysLeft(expiryDate);
        }

    }
}
