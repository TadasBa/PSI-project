using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public class WithLazy
    {
        public List<Ingredient> Ingredients;
        public string Description;

        private static Lazy<WithLazy> lazy = new Lazy<WithLazy>(() => new WithLazy());

        public static WithLazy Instance
        {
            get
            {
                return lazy.Value;
            }

        }

        public WithLazy()
        {
            Ingredients = GetIngredients();
            Description = GetDescription();
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

        public string GetDescription()
        {
            return "Skanuu";
        }
    }
}
