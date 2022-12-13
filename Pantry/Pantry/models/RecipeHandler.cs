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
        private static List<string> recipeTypes = new List<string>();
        public static DictionaryWrapper RecipeProducts = new DictionaryWrapper(new Dictionary<int, List<DateTime>>());
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
                            RecipeProducts.Add(r.ID, p.ExpiryDate);

                        }
                    }
                }
            }
        }

        public static List<string> GetTypes()
        {
            foreach (Recipe recipe in RecipeList)
            {
                recipeTypes.Add(recipe.Type);
            }

            return recipeTypes;
        }

        public static DateTime? GetMinExpiryDate(Recipe r)
        {
            foreach (int key in RecipeProducts.Keys)
            {
                if(key == r.ID)
                {
                    return RecipeProducts[key].Max(date => date);
                }
            }
            return null;
        }

        public static DateTime? GetMaxExpiryDate(Recipe r)
        {
            foreach (int key in RecipeProducts.Keys)
            {
                if (key == r.ID)
                {
                    return RecipeProducts[key].Min(date => date);
                }
            }
            return null;
        }

    }

}