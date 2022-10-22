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
            TypePicker.ItemsSource = ProductTypeHandler.values;
            ExpiryDate.MinimumDate = DateTime.Now;
        }

        private async void BtnProductAddToList(object sender, EventArgs e)
        {
            try
            {
                string productName = ProductName.Text;
                string value = (string)TypePicker.SelectedItem;

                if (String.IsNullOrEmpty(productName) && String.IsNullOrEmpty(value))
                {
                    await App.Current.MainPage.DisplayAlert("Invalid input", "Please fill all the fields", "Close");

                }else if (String.IsNullOrEmpty(productName))
                {
                    await App.Current.MainPage.DisplayAlert("Invalid input", "Please enter product name", "Close");
                }
                else if (String.IsNullOrEmpty(value))
                {
                    await App.Current.MainPage.DisplayAlert("Invalid input", "Please select product type", "Close");
                }
                else
                {
                    ProductType selectedType = ProductTypeExtensions.StringToEnum(value);
                    Product tempProd = new Product() { ProductName = ProductName.Text, expiryDate = ExpiryDate.Date, productColor = SelectColor.SetColor(ExpiryDate.Date), daysLeft = SelectColor.DisplayDaysLeft() };

                    //Reflectoins used to call generic method with type selectedType
                    MethodInfo method = typeof(ProductTypeExtensions).GetMethod(nameof(ProductTypeExtensions.Convert));
                    MethodInfo generic = method.MakeGenericMethod(Product.valuePairs[selectedType]);
                    object[] args = new object[] { tempProd };
                    var product = generic.Invoke(this, args);


                    if (Regex.IsMatch(productName, @"^[a-zA-Z\s]+$") == true)
                    {

                        DataHandler.AddProduct((IProduct)product);

                        //Dismiss("Created");
                        Dismiss(ExpiryDate.Date);

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Invalid input", "Please enter letters only", "Close");
                    }
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Please check if your input", "Close");
            }
           
        

            //try
            //{
            //    string value = (string)TypePicker.SelectedItem;
            //    ProductType selectedType = ProductTypeExtensions.StringToEnum(value);
            //    Product tempProd = new Product() { ProductName = ProductName.Text, expiryDate = ExpiryDate.Date, productColor = SelectColor.SetColor(ExpiryDate.Date), daysLeft = SelectColor.DisplayDaysLeft() };

            //    // Reflectoins used to call generic method with type selectedType
            //    MethodInfo method = typeof(ProductTypeExtensions).GetMethod(nameof(ProductTypeExtensions.Convert));
            //    MethodInfo generic = method.MakeGenericMethod(Product.valuePairs[selectedType]);
            //    object[] args = new object[] { tempProd };
            //    var product = generic.Invoke(this, args);

            //    string productName = ProductName.Text;
            //    if (String.IsNullOrEmpty(productName))
            //    {
            //        await App.Current.MainPage.DisplayAlert("Invalid input", "Plase enter product name", "Close");
            //    }
            //    else
            //    {
            //        if (Regex.IsMatch(ProductName.Text, @"^[a-zA-Z\s]+$") == true)
            //        {
            //            DataHandler.AddProduct((IProduct)product);

            //            //Dismiss("Created");
            //            Dismiss(ExpiryDate.Date);
            //        }
            //        else
            //        {
            //            await App.Current.MainPage.DisplayAlert("Invalid input", "Please enter letters only", "Close");
            //        }
            //    }

            //}
            //catch (NullReferenceException)
            //{
            //    await App.Current.MainPage.DisplayAlert("Invalid input", "Please select product type", "Close");
            //}
            //catch (ArgumentNullException)
            //{
            //    await App.Current.MainPage.DisplayAlert("Invalid input", "Plase enter product name", "Close");
            //}
        }

        private async void setSelectedType(ProductType selectedType, string value)
        {
            try
            {
                selectedType = ProductTypeExtensions.StringToEnum(value);

            }
            catch (NullReferenceException)
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Please select product type", "Close");
            }
        }

        private async void isProductNameNull(string productName){

            if (productName == null)
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Plase enter product name", "Close");
            }
        }

    }
}