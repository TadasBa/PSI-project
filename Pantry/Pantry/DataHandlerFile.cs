using Pantry.models;
using Plugin.LocalNotification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pantry
{
    public class DataHandlerFile : IDataHandler
    {
        public List<Product> ProductList { get; private set; }

        private string path;

        public event EventHandler ProductUpdated;

        public void Notify()
        {
            EventHandler eventHandler = ProductUpdated;

            if(eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }

        public async Task AddProduct(Product product)
        {
            ProductList.Add(product);
            await WriteData();
            Notify();
        }
        public async Task RemoveProduct(Product product)
        {
            ProductList.Remove(product);
            Console.WriteLine("Removing");
            await WriteData();
            Notify();
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

                    ProductList = (List<Product>)bformatter.Deserialize(stream);
                    foreach (var product in ProductList)
                    {
                        product.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                ProductList = new List<Product>();
            }
        }

        public DataHandlerFile()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.data");
            ReadData();
        }

    }
}
