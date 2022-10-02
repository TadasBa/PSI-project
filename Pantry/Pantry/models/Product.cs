using System;
using System.Collections.Generic;
using System.Text;
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

        public ProductType type { get; set; }

        public int CompareTo(object obj)
        {
            return expiryDate.CompareTo(obj);
        }

        public void Update()
        {
            productColor = SelectColor.SetColor(expiryDate);
        }

    }
}
