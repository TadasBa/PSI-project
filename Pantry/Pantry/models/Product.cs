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
        private string _ProductName;
        public string ProductName { get; set; }
        public DateTime ExpiryDate { get; set; }

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

        public static Dictionary<ProductType, Type> valuePairs = new Dictionary<ProductType, Type>
        {
            { ProductType.SEAFOOD,          typeof(Seafood) },
            { ProductType.BAKED_GOODS,      typeof(BakedGoods) },
            { ProductType.BERRIES,          typeof(Berries) },
            { ProductType.DAIRY,            typeof(Dairy) },
            { ProductType.DRINKS,           typeof(Drinks) },
            { ProductType.EGGS,             typeof(Eggs)},
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
