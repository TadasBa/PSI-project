﻿using Newtonsoft.Json;
using Pantry.models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using Pantry.Utilities;
using Style = Pantry.models.Style;
using Pantry.Utilities.Data.Events;
using System.Collections.Generic;

namespace Pantry
{
    internal class DataHandlerAPI : IDataHandler
    {
        public ConcurrentHashSet<Product> ProductList { get; private set; } = new ConcurrentHashSet<Product>();
        private HttpClient _client = DependencyService.Get<HttpClient>(DependencyFetchTarget.GlobalInstance);

        public DataHandlerAPI()
        {
            _client.BaseAddress = new Uri("http://elvinosas.lt");
            _ = GetProducts(0);
        }

        public event ProductUpdatedEventHandler ProductUpdated;

        public async Task AddProduct(Product product)
        {
            await AddProductDB(product);
            ProductUpdated(this, new ProductUpdatedApiArgs(_client.BaseAddress.AbsoluteUri));
        }
        public async Task RemoveProduct(Product product)
        {
            await RemoveProductDB(product);
            ProductUpdated(this, new ProductUpdatedApiArgs(_client.BaseAddress.AbsoluteUri));
        }
        public async Task UpdateProduct(Product product, string name, DateTime date)
        {
            product.ProductName = name;
            product.ExpiryDate = date;
            product.DaysLeft = SelectColor.DisplayDaysLeft();
            product.ProductColor = SelectColor.SetColor(date);
            await UpdateProductDB(product);
            ProductUpdated(this, EventArgs.Empty);
        }

        private async Task RemoveProductDB(Product product)
        {
            try
            {
                Application.Current.MainPage.DisplayToastAsync("Removing product...", 1000);
                HttpResponseMessage m = await _client.DeleteAsync("http://elvinosas.lt/api/Product/" + product.Id);
                m.EnsureSuccessStatusCode();
                ProductList.Remove(product);
            }
            catch (HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
            }
        }
        private async Task AddProductDB(Product product)
        {
            try
            {
                Application.Current.MainPage.DisplayToastAsync("Creating product...", 1000);

                StringContent c = new StringContent(JsonConvert.SerializeObject(product), UTF32Encoding.UTF8, "application/json");
                HttpResponseMessage m = await _client.PostAsync("http://elvinosas.lt/api/Product", c);
                m.EnsureSuccessStatusCode();

                Application.Current.MainPage.DisplayToastAsync(Style.ToastSuccess);

                string result = await m.Content.ReadAsStringAsync();
                product.Id = JsonConvert.DeserializeObject<Product>(result).Id;

                ProductList.Add(product);
            }
            catch(HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
            }
        }
        private async Task UpdateProductDB(Product product)
        {
            try
            {
                Application.Current.MainPage.DisplayToastAsync("Updating product...", 1000);
                StringContent c = new StringContent(JsonConvert.SerializeObject(product), UTF32Encoding.UTF8, "application/json");
                HttpResponseMessage m = await _client.PutAsync("http://elvinosas.lt/api/Product/" + product.Id, c);
                m.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
            }
        }

        public async Task GetProducts(int id)
        {
            try
            {
                HttpResponseMessage m = await _client.GetAsync("http://elvinosas.lt/api/Product/usrid?usrid="+ id);
                m.EnsureSuccessStatusCode();

                string result = await m.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<List<Product>>(result);

                ProductList.Clear();
                foreach (var item in res)
                {
                    item.Update();
                    ProductList.Add(item);
                }

                ProductUpdated(this, EventArgs.Empty);
            }
            catch (HttpRequestException e)
            {
                ExceptionLogger.LogExceptionToFile(e);
            }
        }
    }
}
