using Pantry.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pantry.Utilities
{
    public static class RecipeHandler
    {
        public static ObservableCollection<Recipe> RecipeList { get; set; }
        public static List<string> RecipeTypes { get; private set; }

        public static List<string> GetTypes()
        {
            foreach(Recipe recipe in RecipeList)
            {
                RecipeTypes.Add(recipe.Type);
            }

            return RecipeTypes;
        }
        
    }
}
