using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    internal static class ProductPrefabs
    {
        public static BakedGoods CreateBakedGoods(Product product)
        {
            return (BakedGoods)product;
        }

        public static Product CreateProduct(ProductType type, string name, DateTime date)
        {
            Product product;
            switch (type)
            {
                case ProductType.BAKED_GOODS:       product = new BakedGoods(); break;
                case ProductType.LEGUMES:           product = new Legumes(); break;
                case ProductType.FISH:              product = new Fish(); break;
                case ProductType.SEAFOOD:           product = new Seafood(); break;
                case ProductType.NUTS_AND_SEEDS:    product = new Nuts(); break;
                case ProductType.BERRIES:           product = new Berries(); break;
                case ProductType.DAIRY:             product = new Dairy(); break;
                case ProductType.DRINKS:            product = new Drinks(); break;
                case ProductType.EGGS:              product = new Eggs(); break;
                case ProductType.FRUITS:            product = new Fruits(); break;
                case ProductType.VEGETABLES:        product = new Vegetables(); break;
                case ProductType.MEAT:              product = new Meat(); break;
                case ProductType.GRAINS:            product = new Grains(); break;
                default:                            product = new Product(); break;
            }
            product.ProductName = name;
            product.ExpiryDate = date;
            return product;
        }
    }
}
