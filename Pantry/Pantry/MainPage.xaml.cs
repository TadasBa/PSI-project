using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Pantry.models;
using System.IO;

namespace Pantry
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            DataHandler.productList.CollectionChanged += Update;
        }

        private void BtnProductAdd(object sender, EventArgs e)
        {
            DataHandler.AddProduct(new Product() { productName = ProductName.Text, expiryDate = ExpiryDate.Date, productColor = SelectColor.SetColor(ExpiryDate.Date), daysLeft = SelectColor.DisplayDaysLeft(ExpiryDate.Date)});
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
