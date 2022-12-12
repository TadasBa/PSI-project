using Pantry.models;
using System;
using System.Threading.Tasks;
using Pantry.Utilities;

namespace Pantry
{
    public delegate void ProductUpdatedEventHandler<TEArgs>(object sender, TEArgs args) where TEArgs : EventArgs;
    public interface IDataHandler<TEArgs> where TEArgs : EventArgs
    {
        ConcurrentHashSet<Product> ProductList { get; }
        Task AddProduct(Product product);
        Task RemoveProduct(Product product);
        Task UpdateProduct(Product product, string name, DateTime date, ProductType type);

        Task GetProducts();

        event ProductUpdatedEventHandler<TEArgs> ProductUpdated;
    }
}