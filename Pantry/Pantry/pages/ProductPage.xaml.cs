using Android.OS;
using Pantry.enums;
using Pantry.models;
using Pantry.models.Login;
using Pantry.Utilities;
using Plugin.LocalNotification;
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
        private IDataHandler<EventArgs> _dataHandler;
        private string selectedTypeString = null;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        public Command LongPressItem { get; }

        public ProductPage()
        {
            _dataHandler = DependencyService.Get<IDataHandler<EventArgs>>(DependencyFetchTarget.GlobalInstance);
            _ = _dataHandler.GetProducts();

            LongPressItem = new Command(async (object s) =>
            {

                string result = (string)await Navigation.ShowPopupAsync(new EditProduct((Product)s));
                if (result == "Delete")
                {
                    bool res = await DisplayAlert("Delete", "Delete: " + ((Product)s).ProductName, "Delete", "Cancel");
                    if (res)
                    {
                        await _dataHandler.RemoveProduct((Product)s);
                    }
                }
                ((Product)s).Update();
                Update(this, null);
              
            });

            InitializeComponent();
            BindingContext = this;
            _dataHandler.ProductUpdated += Update;
            _dataHandler.GetProducts();
            Update(this, null);
        }
        
        private async void BtnProductAdd(object sender, EventArgs e)
        {
            try
            {
                DateTime result = (DateTime)await Navigation.ShowPopupAsync(new AddProductPage());

                SettingsPage.WarningsOn(result);

            }
            catch(NullReferenceException ex)
            {
                ExceptionLogger.LogExceptionToFile(ex, "Data from AddProductPage could not be trasferred");
            }
        }

        private async void BtnProductFilter(object sender, EventArgs e)
        {
            try
            {
                List<object> items = (List<object>) await Navigation.ShowPopupAsync(new ProductFilterPage(selectedTypeString, startDate, endDate));
                selectedTypeString = (string)items[0];
                startDate = (DateTime?)items[1];
                endDate = (DateTime?)items[2];
                Update(this, null);
            }
            catch(NullReferenceException ex)
            {
                ExceptionLogger.LogExceptionToFile(ex, "Data from ProductFilterPage could not be trasferred");
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update(this, null);
        }
        
     
        public void Update(object sender, EventArgs args)
        {

            IOrderedEnumerable<Product> ordered =
                            from product in _dataHandler.ProductList.GetAll()
                            where product.ProductName.ToLower().StartsWith(SearchFilter.Text)
                            orderby product
                            select product;

            if (selectedTypeString != null && startDate != null && endDate != null)
            {
                ProductType selectedType = ProductTypeExtensions.StringToEnum(selectedTypeString);
                IEnumerable<Product> filteredByDateAndType = from product in ordered
                                                             where product.ExpiryDate >= startDate && product.ExpiryDate <= endDate && product.ProductType == selectedType
                                                             select product;

                itemCollectionView.ItemsSource = filteredByDateAndType;


            }
            else if (selectedTypeString != null)
            {
                ProductType selectedType = ProductTypeExtensions.StringToEnum(selectedTypeString);
                IEnumerable<Product> filteredByType = from product in ordered
                                                      where product.ProductType == selectedType
                                                      select product;

                itemCollectionView.ItemsSource = filteredByType;
            }
            else if (startDate != null && endDate != null)
            {
                IEnumerable<Product> filteredByDate = from product in ordered
                                                      where product.ExpiryDate >= startDate && product.ExpiryDate <= endDate
                                                      select product;

               itemCollectionView.ItemsSource = filteredByDate;
            }
            else
            {

                itemCollectionView.ItemsSource = ordered;
            }

        }
        

    }
}