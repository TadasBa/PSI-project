using Pantry.enums;
using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProduct : Popup
    {
        IDataHandler<EventArgs> dataHandler = DependencyService.Get<IDataHandler<EventArgs>>(DependencyFetchTarget.GlobalInstance);
        public Product Product { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public ProductType Type { get; set; }
        public EditProduct(Product product)
        {
            BindingContext = this;
            Product = product;
            Name = product.ProductName;
            Date = product.ExpiryDate;
            Type = product.ProductType;
            InitializeComponent();
            TypePicker.ItemsSource = ProductTypeHandler.Values;
            TypePicker.SelectedItem = Type.ToDescriptionString();
            ExpiryDate.MinimumDate = DateTime.Now;
        }
        public void OnCanceled(object sender, EventArgs args)
        {
            Dismiss("Canceled");
        }

        public async void OnConfirm(object sender, EventArgs args)
        {
            if (Name != "")
            {
                if (Regex.IsMatch(Name, @"^[a-zA-Z\s]+$") == true)
                {
                    Type = ProductTypeExtensions.StringToEnum((string)TypePicker.SelectedItem);
                    dataHandler.UpdateProduct(Product, Name, Date, Type);
                    ((MainPage)Application.Current.MainPage).DisplayToast("Saving changes");
                    Dismiss("Confirmed");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid input", "Please enter letters only", "Close");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Invalid input", "Please enter product name", "Close");
            }
        }
        public void OnDelete(object sender, EventArgs args)
        {
            Dismiss("Delete");
        }
    }
}