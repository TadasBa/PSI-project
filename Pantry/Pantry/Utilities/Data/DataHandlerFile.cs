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
    public class DataHandlerFile : IDataHandler<EventArgs>
    {
        public ConcurrentHashSet<Product> ProductList { get; private set; }

        private string path;

        public event ProductUpdatedEventHandler<EventArgs> ProductUpdated;

        public async Task AddProduct(Product product)
        {
            ProductList.Add(product);
            await WriteData(0);
            ProductUpdated(this, EventArgs.Empty);
        }
        public async Task RemoveProduct(Product product)
        {
            ProductList.Remove(product);
            Console.WriteLine("Removing");
            await WriteData(0);
            ProductUpdated(this, EventArgs.Empty);
        }

        public async Task UpdateProduct(Product product, string name, DateTime date, ProductType type)
        {
            product.ProductName = name;
            product.ExpiryDate = date;
            product.ProductType = type;
            await WriteData(0);
        }

        public async Task WriteData(int id)
        {
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, ProductList);
            }
        }

        public async Task GetProducts()
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
                }
            }
            catch (Exception ex)
            {
                ProductList = new ConcurrentHashSet<Product>();
                ExceptionLogger.LogExceptionToFile(ex);
            }
        }

        public DataHandlerFile()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.data");
            GetProducts();
        }

    }
}
