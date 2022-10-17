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

namespace Pantry
{
    public sealed class DataHandler
    {
        private static readonly DataHandler instance = new DataHandler();
        public static DataHandler Instance { get { return instance; } }

        public static ObservableCollection<IProduct> productList { get; private set; }

        private static string path;

        public static void AddProduct(IProduct product)
        {
            productList.Add(product);
            WriteData();
        }
        public static void RemoveProduct(Product product)
        {
            productList.Remove(product);
            Console.WriteLine("Removing");
            WriteData();
        }

        public static void WriteData()
        {
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, productList);
            }
        }

        private static void ReadData()
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    productList = (ObservableCollection<IProduct>)bformatter.Deserialize(stream);
                    foreach (var product in productList)
                    {
                        product.Update();
                        LocalNotificationCenter.Current.Show(Notification.ProductExpirationNotification(product.expiryDate));

                    }
                }
            }
            catch (Exception ex)
            {
                productList = new ObservableCollection<IProduct>();
            }
        }
        static DataHandler()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "products.data");
            ReadData();
        }

    }
}
