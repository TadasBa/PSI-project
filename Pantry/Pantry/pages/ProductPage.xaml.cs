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
        public ProductPage()
        {
            InitializeComponent();
             DataHandler.productList.CollectionChanged += Update;
        }
        
        private void BtnProductAdd(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new AddProductPage());
        }
        
        private void BtnProductDelete(object sender, EventArgs e)
        {
           DataHandler.RemoveProduct((Product)itemListView.SelectedItem);
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
           itemListView.ItemsSource = ordered;
        }
        
    }
}