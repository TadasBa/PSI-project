using Pantry.models;
using Pantry.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Pantry.enums
{
    public static class ProductTypeExtensions
    {
        public static string ToDescriptionString(this ProductType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static ProductType StringToEnum(string value)
        {
            string s = value.ToUpper().Replace(" ", "_");
            if (ProductType.TryParse(s, out ProductType pt))
            {
                return pt;
            }
            else
            {
                Exception e = new Exception();
                ExceptionLogger.LogExceptionToFile(e, "String to enum converstion failed");
                throw e;
            }
        }

        public static T Convert<T>(this Product product) where T : Product, new()
        {
            T type = new T();
            type.ProductName = product.ProductName;
            type.ExpiryDate = product.ExpiryDate;
            type.DaysLeft = product.DaysLeft;
            type.ProductColor = product.ProductColor;
            return type;
        }
    }
}
