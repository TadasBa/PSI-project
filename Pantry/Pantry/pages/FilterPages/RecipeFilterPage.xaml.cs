using Xamarin.CommunityToolkit.UI.Views;
using Pantry.pages;
using Java.Security;
using Pantry.models;
using Xamarin.Forms;
using System;
using Android.Util;
using System.Collections.Generic;

namespace Pantry.pages
{
    public partial class RecipeFilterPage : Popup
    {
        private string typeValue = null;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        public RecipeFilterPage(string typeValue, DateTime? startDate, DateTime? endDate)
        {
            InitializeComponent();
            TypePicker.ItemsSource = RecipeHandler.GetTypes();
            GetValues(typeValue, startDate, endDate);
        }

        private void BtnSetFilter(object sender, EventArgs e)
        {
            SetValues();
            List<object> items = new List<object> { typeValue, startDate, endDate };
            Dismiss(items);
        }

        private void BtnResetFilter(object sender, EventArgs e)
        {
            List<object> items = new List<object> { null, null, null };
            Dismiss(items);

        }

        private void FilterByDateCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                StartDate.IsEnabled = true;
                EndDate.IsEnabled = true;
                FilterByDate.Color = Color.Black;

            }
            else
            {
                StartDate.IsEnabled = false;
                EndDate.IsEnabled = false;
                FilterByDate.Color = Color.Black;
            }
        }

        private void FilterByTypeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                TypePicker.IsEnabled = true;
                FilterByType.Color = Color.Black;
                TypePicker.TitleColor = Color.Black;
            }
            else
            {
                TypePicker.IsEnabled = false;
                FilterByType.Color = Color.DarkGray;
            }
        }

        private void SetValues()
        {
            if (FilterByType.IsChecked && FilterByDate.IsChecked)
            {
                typeValue = (string)TypePicker.SelectedItem;
                startDate = StartDate.Date;
                endDate = EndDate.Date;

            }
            else if (FilterByType.IsChecked)
            {
                typeValue = (string)TypePicker.SelectedItem;
            }
            else if (FilterByDate.IsChecked)
            {
                startDate = StartDate.Date;
                endDate = EndDate.Date;
            }
            else
            {
                return;
            }
        }

        private void GetValues(string typeValue, DateTime? startDate, DateTime? endDate)
        {
            if (typeValue != null)
            {
                TypePicker.SelectedItem = typeValue;
                FilterByType.IsChecked = true;
            }

            if (startDate != null && endDate != null)
            {
                StartDate.Date = (DateTime)startDate;
                EndDate.Date = (DateTime)endDate;
                FilterByDate.IsChecked = true;
            }

        }
    }
}