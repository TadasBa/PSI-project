using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public class LazyIngrientsInitialization
    {
        public List<Ingredient> Ingredients;

        private static Lazy<LazyIngrientsInitialization> lazy = new Lazy<LazyIngrientsInitialization>(() => new LazyIngrientsInitialization());

        public static LazyIngrientsInitialization Instance
        {
            get
            {
                return lazy.Value;
            }
            
        }

        public LazyIngrientsInitialization()
        {
            Ingredients = GetIngredients();
        }

        public List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>()
            {
                new Ingredient()
                {
                    Name = "Bread",
                    Amount = "4 slices"
                },
                new Ingredient()
                {
                    Name = "Cheese",
                    Amount = "200 g"
                }
            };
        }
    }
}

