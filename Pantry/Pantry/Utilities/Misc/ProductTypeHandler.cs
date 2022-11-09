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
        public static List<string> Values { get; set; }

        static ProductTypeHandler()
        {
            Values = new List<string>();
            foreach (ProductType pt in Enum.GetValues(typeof(ProductType)))
            {
                string value = pt.ToDescriptionString();
                Values.Add(value);
            }

            Values.Sort();
        }

    }

}