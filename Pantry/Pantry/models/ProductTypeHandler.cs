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
            switch (product.type)
            {
                case ProductType.BAKED_GOODS:
                    product.imageSource = "";
                    break;

                case ProductType.BERRIES:
                    product.imageSource = "";
                    break;

                case ProductType.DAIRY:
                    product.imageSource = "";
                    break;

                case ProductType.DRINKS:
                    product.imageSource = "";
                    break;

                case ProductType.EGGS:
                    product.imageSource = "";
                    break;

                case ProductType.FRUITS:
                    product.imageSource = "";
                    break;

                case ProductType.GRAINS:
                    product.imageSource = "";
                    break;

                case ProductType.LEGUMES:
                    product.imageSource = "";
                    break;

                case ProductType.MEAT:
                    product.imageSource = "";
                    break;

                case ProductType.NUTS_AND_SEEDS:
                    product.imageSource = "";
                    break;

                case ProductType.SEAFOOD:
                    product.imageSource = "";
                    break;

                case ProductType.VEGETABLES:
                    product.imageSource = "";
                    break;

            }

        }

    }

}