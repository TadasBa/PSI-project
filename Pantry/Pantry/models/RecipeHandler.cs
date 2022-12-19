using Java.Util;
using Org.Apache.Http.Impl.Client;
using Pantry.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Pantry.models
{
    public static class RecipeHandler
    {
        public static ObservableCollection<Recipe> RecipeList = new ObservableCollection<Recipe>();
        public static HashSet<string> RecipeTypes = new HashSet<string>();
        private static RecipeDictionary RecipeProducts = new RecipeDictionary();
        private static IDataHandler<EventArgs> dataHandler = DependencyService.Get<IDataHandler<EventArgs>>(DependencyFetchTarget.GlobalInstance);

        public static void SetProductsForRecipes()
        {

            var products = dataHandler.ProductList.GetAll();

            foreach (Recipe r in RecipeList)
            {
                foreach (Ingredient i in r.Ingredients)
                {
                    foreach (Product p in products)
                    {
                        if (i.Name.ToLower() == p.ProductName.ToLower())
                        {
                            RecipeProducts.Add(r.Id, p.ExpiryDate);

                        }
                    }
                }
            }
        }

        public static void SetTypes()
        {
            foreach (Recipe recipe in RecipeList)
            {
                RecipeTypes.Add(recipe.Type);
            }
        }
        public static DateTime? GetMinExpiryDate(Recipe r)
        {
            foreach (int key in RecipeProducts.Keys)
            {
                if(key == r.Id)
                {
                    return RecipeProducts[key].Min(date => date);
                }
            }
            return null;
        }

        public static DateTime? GetMaxExpiryDate(Recipe r)
        {
            foreach (int key in RecipeProducts.Keys)
            {
                if (key == r.Id)
                {
                    return RecipeProducts[key].Max(date => date);
                }
            }
            return null;
        }

    }

}