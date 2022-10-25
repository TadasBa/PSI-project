using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProduct : Popup
    {
        public Product Product { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public EditProduct(Product product)
        {
            BindingContext = this;
            Product = product;
            Name = product.ProductName;
            Date = product.ExpiryDate;

            InitializeComponent();
        }
        public void OnCanceled(object sender, EventArgs args)
        {
            Dismiss("Canceled");
        }

        public void OnConfirm(object sender, EventArgs args)
        {
            Product.ProductName = Name;
            Product.ExpiryDate = Date;
            Product.ProductColor = SelectColor.SetColor(Date);
            Product.DaysLeft = SelectColor.DisplayDaysLeft();
            DataHandler.WriteData();
            ((MainPage)Application.Current.MainPage).DisplayToast("Saving changes");
            Dismiss("Confirmed");
        }

        public void OnDelete(object sender, EventArgs args)
        {
            Dismiss("Delete");
        }
    }
}