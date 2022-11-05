using Pantry.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Pantry
{
    public interface IDataHandler
    {
        List<Product> ProductList { get; }
        Task AddProduct(Product product);
        Task RemoveProduct(Product product);
        Task UpdateProduct(Product product, string name, DateTime date);

        event EventHandler ProductUpdated;
        void Notify();
    }
}