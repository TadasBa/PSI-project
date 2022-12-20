using Autofac.Extras.Moq;
using Castle.Components.DictionaryAdapter.Xml;
using Pantry.models;
using Pantry.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xunit;

namespace Pantry.Tests
{
    public  class UtilitiesTests_Data_DataHandlerFile
    {
        //[Fact]
        public void AddProduct_ShouldAddProductToList()
        {
            Product p = new Product("morka", ProductType.VEGETABLES, new DateTime(2022, 12, 12), 1);
            ConcurrentHashSet<Product> ProductList = new ConcurrentHashSet<Product>();
            ProductList.Add(p);

            IDataHandler<EventArgs> handler;

            handler = DependencyService.Get<IDataHandler<EventArgs>>(DependencyFetchTarget.GlobalInstance);

            handler.AddProduct(p);

            Assert.True(handler.Equals(ProductList));
 
        }
    }
}
