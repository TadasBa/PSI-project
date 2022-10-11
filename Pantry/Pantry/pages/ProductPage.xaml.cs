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
            IOrderedEnumerable<Product> ordered = null;
            
            try
            {

                ordered = from product in DataHandler.productList
                            where product.productName.ToLower().StartsWith(SearchFilter.Text)
                            orderby product
                            select product;
                
            }
            catch (NullReferenceException ex)
            {

                ordered = from product in DataHandler.productList
                            orderby product
                            select product;

            }
            finally
            {
                itemListView.ItemsSource = ordered;
            }

           
        }
        
    }
}