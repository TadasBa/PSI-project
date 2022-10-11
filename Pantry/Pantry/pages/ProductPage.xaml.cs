﻿using Pantry.enums;
using Pantry.models;
using Pantry.pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    public partial class ProductPage : ContentPage
    {
        private string selectedTypeString = null;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        public ProductPage()
        {
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

        private async void BtnProductFilter(object sender, EventArgs e)
        {
            
            try
            {
                List<Object> items = (List<Object>) await Navigation.ShowPopupAsync(new FilterPage(selectedTypeString, startDate, endDate));
                selectedTypeString = (string)items[0];
                startDate = (DateTime?)items[1];
                endDate = (DateTime?)items[2];
                Update(this, null);
            }
            catch (Exception)
            {
                return;
            }  
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

            if (selectedTypeString != null && startDate != null && endDate != null)
            {
                ProductType selectedType = ProductTypeExtensions.StringToEnum(selectedTypeString);
                IEnumerable<Product> filteredByDateAndType = from product in ordered
                                                             where product.expiryDate >= startDate && product.expiryDate <= endDate && product.type == selectedType
                                                             select product;

                itemListView.ItemsSource = filteredByDateAndType;


            }
            else if(selectedTypeString != null)
            {
                ProductType selectedType = ProductTypeExtensions.StringToEnum(selectedTypeString);
                IEnumerable<Product> filteredByType = from product in ordered
                                                where product.type == selectedType
                                                select product;

                itemListView.ItemsSource = filteredByType;
            }
            else if(startDate != null && endDate != null)
            {
                IEnumerable<Product> filteredByDate = from product in ordered
                                                      where product.expiryDate >= startDate && product.expiryDate <= endDate
                                                      select product;

                itemListView.ItemsSource = filteredByDate;
            }
            else{

                itemListView.ItemsSource = ordered;
            }

        }
        
    }
}