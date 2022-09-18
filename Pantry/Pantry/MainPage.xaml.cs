using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Pantry.models;

namespace Pantrys
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Item> itemList = new ObservableCollection<Item>();
        public MainPage()
        {
            InitializeComponent();
            itemListView.ItemsSource = itemList;
        }

        private void onAddButtonClicked(object sender, EventArgs e)
        {
            itemList.Add(new Item() { name = "Potato", date = "2022-09-18", imageSource = "https://play-lh.googleusercontent.com/9UDY3O4wSwlBm-kHHfjKf85Yk5GCt0nckL5ZdMR-nYotAfNjODvR4sZ-scPXG3ABVF65" });
        }
    }
}
