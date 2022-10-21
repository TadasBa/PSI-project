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
        private string productName;
        public string ProductName { 
            get { return productName; } 
            set { productName = value[0].ToString().ToUpper() + value.Substring(1); } }
        public DateTime expiryDate { get; set; }

        public string productColor { get; set; }

        public string daysLeft { get; set; }
        public ProductType type { get; set; }
        public string imageSource { get; set; }

        public int CompareTo(object obj)
        {
            Product b = (Product)obj;
            return expiryDate.CompareTo(b.expiryDate);
        }
        public void Update()
        {
            productColor = SelectColor.SetColor(expiryDate);
            daysLeft = SelectColor.DisplayDaysLeft();
        }

        public static Dictionary<ProductType, Type> valuePairs = new Dictionary<ProductType, Type>
        {
            { ProductType.SEAFOOD,          typeof(Seafood) },
            { ProductType.BAKED_GOODS,      typeof(BakedGoods) },
            { ProductType.BERRIES,          typeof(Berries) },
            { ProductType.DAIRY,            typeof(Dairy) },
            { ProductType.DRINKS,           typeof(Drinks) },
            {ProductType.EGGS,              typeof(Eggs)},
            { ProductType.FISH,             typeof(Fish) },
            { ProductType.FRUITS,           typeof(Fruits) },
            { ProductType.GRAINS,           typeof(Grains) },
            { ProductType.LEGUMES,          typeof(Legumes) },
            { ProductType.MEAT,             typeof(Meat) },
            { ProductType.NUTS_AND_SEEDS,   typeof(Nuts) },
            { ProductType.VEGETABLES,       typeof(Vegetables) }
        };
    }
}
