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
            itemListView.ItemsSource = DataHandler.productList;
        }

        private void BtnProductAdd(object sender, EventArgs e)
        {
            DataHandler.AddProduct(new Product() { productName = ProductName.Text, expiryDate = ExpiryDate.Date, productColor = SelectColor.SetColor(ExpiryDate.Date)});
        }

        private void BtnProductDelete(object sender, EventArgs e)
        {
           DataHandler.RemoveProduct((Product)itemListView.SelectedItem);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Product> search =
            from product in DataHandler.productList
            where product.productName.ToLower().StartsWith(e.NewTextValue.ToLower())
            select product;

            itemListView.ItemsSource = search;
        }
    }
}
