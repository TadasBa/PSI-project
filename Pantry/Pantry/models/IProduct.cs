using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public interface IProduct
    {
        string productName { get; set; }
        DateTime expiryDate { get; set; }
        string productColor { get; set; }
        string daysLeft { get; set; }

        ProductType type { get; set; }
        string imageSource { get; set; }
        void Update();
    }
}
