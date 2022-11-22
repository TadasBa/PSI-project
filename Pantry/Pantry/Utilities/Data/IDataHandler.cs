using Pantry.models;
using System;
using System.Threading.Tasks;
using Pantry.Utilities;

namespace Pantry
{
    public delegate void ProductUpdatedEventHandler(object sender, EventArgs args);
    public interface IDataHandler
    {
        ConcurrentHashSet<Product> ProductList { get; }
        Task AddProduct(Product product);
        Task RemoveProduct(Product product);
        Task UpdateProduct(Product product, string name, DateTime date);

        Task GetProducts(int id);

        event ProductUpdatedEventHandler ProductUpdated;
    }
}