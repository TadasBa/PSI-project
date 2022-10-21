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
        public Product product { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public EditProduct(Product product)
        {
            BindingContext = this;
            this.product = product;
            Name = product.ProductName;
            Date = product.expiryDate;

            InitializeComponent();
        }
        public void OnCanceled(object sender, EventArgs args)
        {
            Dismiss("Canceled");
        }

        public void OnConfirm(object sender, EventArgs args)
        {
            product.ProductName = Name;
            product.expiryDate = Date;
            product.productColor = SelectColor.SetColor(Date);
            product.daysLeft = SelectColor.DisplayDaysLeft();
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