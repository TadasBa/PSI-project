using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    [Serializable]
    public class Product : IComparable
    {
        public string productName { get; set; }
        public DateTime expiryDate { get; set; }

        public int CompareTo(object obj)
        {
            return expiryDate.CompareTo(obj);
        }
    }
}
