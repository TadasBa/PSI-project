using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public interface IProduct
    {
        string ProductName { get; set; }
        DateTime ExpiryDate { get; set; }
        string ProductColor { get; set; }
        string DaysLeft { get; set; }

        ProductType ProductType { get; set; }
        string ImageSource { get; set; }
        void Update();
    }
}
