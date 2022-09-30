using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Pantry.models;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Pantry
{
    public partial class MainPage : ContentPage
    {
       

        ObservableCollection<Product> itemList = new ObservableCollection<Product>();
        public MainPage()
        {
            InitializeComponent();
            itemListView.ItemsSource = itemList;

        }

        private void BtnProductAdd(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Products.txt");
            
            itemList.Add(new Product() { productName = ProductName.Text, expiryDate = ExpiryDate.Date.ToShortDateString()});
            string product = ProductName.Text + " " + ExpiryDate.Date.ToShortDateString();

        }

        private void BtnProductDelete(object sender, EventArgs e)
        {
           itemList.Remove((Product)itemListView.SelectedItem);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemListView.ItemsSource = itemList.Where(s => s.productName.StartsWith(e.NewTextValue));
        }
    }
}
