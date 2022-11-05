using Pantry.models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            ProductList.Add(product);
            Notify();
        }
        public async Task RemoveProduct(Product product)
        {
            ProductList.Remove(product);
            Notify();
        }

        private async Task AddProductDB(Product product)
        {
            HttpResponseMessage responseMessage;
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
