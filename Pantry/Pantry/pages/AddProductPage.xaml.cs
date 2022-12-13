using Pantry.enums;
using Pantry.models;
using Pantry.models.Login;
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

        IDataHandler<EventArgs> dataHandler;
        LoginService loginService;
        public AddProductPage()
        {
            dataHandler = DependencyService.Get<IDataHandler<EventArgs>>(DependencyFetchTarget.GlobalInstance);
            loginService = DependencyService.Get<LoginService>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
            TypePicker.ItemsSource = ProductTypeHandler.Values;
            ExpiryDate.MinimumDate = DateTime.Now;
        }

        private async void BtnProductAddToList(object sender, EventArgs e)
        {
            string productName = ProductName.Text;
            string value = (string)TypePicker.SelectedItem;

            if (string.IsNullOrEmpty(productName) && string.IsNullOrEmpty(value))
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Please fill all the fields", "Close");

            }else if (string.IsNullOrEmpty(productName))
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Please enter product name", "Close");
            }
            else if (string.IsNullOrEmpty(value))
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Please select product type", "Close");
            }
            else
            {
                ProductType selectedType = ProductTypeExtensions.StringToEnum(value);
                Product product = new Product(productName, selectedType, ExpiryDate.Date, loginService.currentUser.Id);

                if (Regex.IsMatch(productName, @"^[a-zA-Z\s]+$") == true)
                {

                    dataHandler.AddProduct(product);

                    Dismiss(ExpiryDate.Date);

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid input", "Please enter letters only", "Close");
                }
            }
        }
    }
}