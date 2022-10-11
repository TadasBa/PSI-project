using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public Command LongPressItem { get; }

        public ProductPage()
        {
            LongPressItem = new Command(async (object s) =>
            {
                var result = await Navigation.ShowPopupAsync(new EditProduct((Product)s));
                if(result == "Delete")
                {
                    bool res = await DisplayAlert("Delete", "Delete: " + ((Product)s).productName, "Delete", "Cancel");
                    if(res)
                    {
                        DataHandler.RemoveProduct((Product)s);
                    }
                }
                Update(this, null);
            });

            InitializeComponent();
            BindingContext = this;
            DataHandler.productList.CollectionChanged += Update;
            Update(this, null);
        }
        
        private void BtnProductAdd(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new AddProductPage());
        }
        
        private void BtnProductDelete(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new DeleteConfirmationPage());
          // DataHandler.RemoveProduct((Product)itemListView.SelectedItem);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update(this, null);
        }
        
        public void Update(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args)
        {
            IOrderedEnumerable<Product> ordered =
                        from product in DataHandler.productList
                        where product.productName.ToLower().StartsWith(SearchFilter.Text)
                        orderby product
                        select product;

            IEnumerable<Product> filtered = ordered

            itemListView.ItemsSource = ordered;
           
        }
        
    }
}