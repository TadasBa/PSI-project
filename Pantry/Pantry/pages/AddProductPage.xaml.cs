using Pantry.enums;
using Pantry.models;
using Pantry.models.types;
using Plugin.LocalNotification;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.PlatformConfiguration.iOSSpecific;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    public partial class AddProductPage : Popup
    {
        public AddProductPage()
        {
            InitializeComponent();
            TypePicker.ItemsSource = ProductTypeHandler.Values;
            ExpiryDate.MinimumDate = DateTime.Now;
        }

        private void BtnProductAddToList(object sender, EventArgs e)
        {
            string productName = ProductName.Text;
            string value = (string)TypePicker.SelectedItem;

            if (string.IsNullOrEmpty(productName) && String.IsNullOrEmpty(value))
            {
                App.Current.MainPage.DisplayAlert("Invalid input", "Please fill all the fields", "Close");

            }else if (string.IsNullOrEmpty(productName))
            {
                App.Current.MainPage.DisplayAlert("Invalid input", "Please enter product name", "Close");
            }
            else if (string.IsNullOrEmpty(value))
            {
                App.Current.MainPage.DisplayAlert("Invalid input", "Please select product type", "Close");
            }
            else
            {
                ProductType selectedType = ProductTypeExtensions.StringToEnum(value);
                Product tempProd = new Product() { ProductName = ProductName.Text, ExpiryDate = ExpiryDate.Date, ProductColor = SelectColor.SetColor(ExpiryDate.Date), DaysLeft = SelectColor.DisplayDaysLeft() };

                //Reflectoins used to call generic method with type selectedType

                if (Regex.IsMatch(productName, @"^[a-zA-Z\s]+$") == true)
                {

                    DataHandler.AddProduct(tempProd);

                    Dismiss(ExpiryDate.Date);

                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Invalid input", "Please enter letters only", "Close");
                }
            }

        }
    }
}