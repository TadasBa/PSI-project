using Newtonsoft.Json;
using Pantry.models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Style = Pantry.models.Style;

namespace Pantry
{
    internal class DataHandlerAPI : IDataHandler
    {
        public List<Product> ProductList { get; private set; } = new List<Product>();

        HttpClient client = new HttpClient();

        public event EventHandler ProductUpdated;

        public void Notify()
        {
            EventHandler eventHandler = ProductUpdated;

            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }

        public async Task AddProduct(Product product)
        {
            await AddProductDB(product);
            Notify();
        }
        public async Task RemoveProduct(Product product)
        {
            ProductList.Remove(product);
            Notify();
        }

        private async Task AddProductDB(Product product)
        {
            try
            {
                Application.Current.MainPage.DisplayToastAsync("Creating product...", 1000);
                StringContent c = new StringContent(JsonConvert.SerializeObject(product), UTF32Encoding.UTF8, "application/json");
                HttpResponseMessage m = await client.PostAsync("http://elvinosas.lt/api/Product", c);
                m.EnsureSuccessStatusCode();
                Application.Current.MainPage.DisplayToastAsync(Style.ToastSuccess);
                string result = await m.Content.ReadAsStringAsync();
                product.Id = JsonConvert.DeserializeObject<Product>(result).Id;
                ProductList.Add(product);

            }
            catch(HttpRequestException e)
            {
                Application.Current.MainPage.DisplayToastAsync(Style.ToastError);
                Console.WriteLine(e.Message);
            }
        }

        public async Task UpdateProduct(Product product, string name, DateTime date)
        {
            product.ProductName = name;
            product.ExpiryDate = date;
            product.DaysLeft = SelectColor.DisplayDaysLeft();
            product.ProductColor = SelectColor.SetColor(date);
        }
    }
}
