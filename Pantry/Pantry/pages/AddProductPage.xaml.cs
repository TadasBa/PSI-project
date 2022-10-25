using Pantry.enums;
using Pantry.models;
using Pantry.models.types;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }
        
        private void BtnProductAddToList(object sender, EventArgs e)
        {
            string value = (string)TypePicker.SelectedItem;
            ProductType selectedType = ProductTypeExtensions.StringToEnum(value);
            Product product = ProductPrefabs.CreateProduct(selectedType, ProductName.Text, ExpiryDate.Date);

            if (Regex.IsMatch(ProductName.Text, @"^[a-zA-Z]+$") == true)
            {
                DataHandler.AddProduct(product);

                Dismiss("Created");
            }
            else
            {
                lblCorrect.IsVisible = true;
            }

            LocalNotificationCenter.Current.Show(Notification.Notifications(ExpiryDate.Date));
        }
    }
}