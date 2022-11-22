﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Pantry.models;
using Pantry.pages;
using Plugin.LocalNotification;
using Xamarin.Forms;

namespace Pantry.models
{
    [Serializable]
    public class Product : IComparable, IProduct
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public int UsrID { get; private set; } = 0;
        [JsonProperty]
        public string ProductName { get; set; }
        [JsonProperty]
        public ProductType ProductType { get; set; }

        private DateTime _date;
        [JsonProperty]
        public DateTime ExpiryDate { get { return _date; } set { _date = value; ProductColor = SelectColor.SetColor(value); } }

        [JsonIgnore]
        public string ProductColor { get; set; }
        [JsonIgnore]
        public string DaysLeft { get; set; }
        [JsonIgnore]
        public string ImageSource { get; set; }

        public Product(string name, ProductType type, DateTime expiryDate)
        {
            ProductName = name;
            ProductType = type;
            ExpiryDate = expiryDate;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }

        public int CompareTo(object obj)
        {
            Product b = (Product)obj;
            return ExpiryDate.CompareTo(b.ExpiryDate);
        }
        public void Update()
        {
            ProductColor = SelectColor.SetColor(ExpiryDate);
            DaysLeft = SelectColor.DisplayDaysLeft();
            SettingsPage.NotificationsOn(ExpiryDate);
        }
    }
}
