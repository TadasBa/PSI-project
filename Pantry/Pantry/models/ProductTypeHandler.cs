using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Pantry.enums;
using Pantry.models;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Pantry.models
{
    public static class ProductTypeHandler

    {
        public static List<string> values { get; set; }

        static ProductTypeHandler()
        {
            values = new List<string>();
            foreach (ProductType pt in Enum.GetValues(typeof(ProductType)))
            {
                String value = pt.ToDescriptionString();
                values.Add(value);

            }

            values.Sort();
        }

        public static void setImageSource(Product product)
        {
            switch (product.type) {
                case ProductType.BAKED_GOODS:
                    product.imageSource = "baked_goods.jpg";
                    break;

                case ProductType.BERRIES:
                    product.imageSource = "berries.jpg";
                    break;

                case ProductType.DAIRY:
                    product.imageSource = "dairy.jpg";
                    break;

                case ProductType.DRINKS:
                    product.imageSource = "drinks.jpg";
                    break;

                case ProductType.EGGS:
                    product.imageSource = "eggs.jpg";
                    break;

                case ProductType.FRUITS:
                    product.imageSource = "fruits.jpg";
                    break;

                case ProductType.GRAINS:
                    product.imageSource = "grains.jpg";
                    break;

                case ProductType.LEGUMES:
                    product.imageSource = "legumes.jpg";
                    break;

                case ProductType.MEAT:
                    product.imageSource = "meat.jgp";
                    break;

                case ProductType.NUTS_AND_SEEDS:
                    product.imageSource = "nuts_and_seeds.jpg";
                    break;

                case ProductType.SEAFOOD:
                    product.imageSource = "seafood.jpg";
                    break;

                case ProductType.VEGETABLES:
                    product.imageSource = "vegetables.jpg";
                    break;

            }

        }

    }

}

