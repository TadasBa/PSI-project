using Pantry.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Pantry.Utilities.Data.Events;
using Pantry.Utilities;
using Plugin.LocalNotification;

namespace Pantry
{
    public class DataHandlerFile : IDataHandler
    {
        public ConcurrentHashSet<Product> ProductList { get; private set; }

        private string path;

        public event ProductUpdatedEventHandler ProductUpdated;

        public async Task AddProduct(Product product)
        {
            ProductList.Add(product);
            await WriteData();
            ProductUpdated(this, EventArgs.Empty);
        }
        public async Task RemoveProduct(Product product)
        {
            ProductList.Remove(product);
            Console.WriteLine("Removing");
            await WriteData();
            ProductUpdated(this, EventArgs.Empty);
        }

        public async Task UpdateProduct(Product product, string name, DateTime date)
        {
            product.ProductName = name;
            product.ExpiryDate = date;
        }

        public async Task WriteData()
        {
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, ProductList);
            }
        }

        public async Task ReadData()
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    ProductList = (ConcurrentHashSet<Product>)bformatter.Deserialize(stream);
                    ProductList.ForEach(
                        (product) => product.Update()
                    );
                    ProductList.ForEach( 
                        (product) => LocalNotificationCenter.Current.Show(Notification.ProductExpirationNotification(product.ExpiryDate, titleName: "Notification"))
                    );
                }
            }
            catch (Exception ex)
            {
                ProductList = new ConcurrentHashSet<Product>();
            }
        }

        public DataHandlerFile()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.data");
            ReadData();
        }

    }
}
