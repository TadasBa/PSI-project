using Pantry.enums;
using Pantry.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{
    public partial class FilterPage : Popup
    {
        private string typeValue = null;
        public DateTime? startDate = null;
        public DateTime? endDate = null;

        public FilterPage(string typeValue, DateTime? startDate, DateTime? endDate)
        {
            InitializeComponent();
            TypePicker.ItemsSource = ProductTypeHandler.values;
            GetValues(typeValue, startDate, endDate);

        }
        private void BtnSetFilter(object sender, EventArgs e)
        {
            SetValues();
            List<Object> items = new List<Object> { typeValue, startDate, endDate };
            Dismiss(items);

        }

        private void BtnResetFilter(object sender, EventArgs e)
        {
            List<Object> items = new List<Object> { typeValue, startDate, endDate };
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