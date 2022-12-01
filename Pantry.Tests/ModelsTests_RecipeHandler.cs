using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pantry.Tests
{
    public class ModelsTests_RecipeHandler
    {
        //[Fact]
        public void GetMinExpiryDate_ShouldReturnDateTime()
        {
            /*
            DictionaryWrapper RecipeProducts = new DictionaryWrapper(new Dictionary<int, List<DateTime>>());
            List<Ingredient> ingredients = new List<Ingredient>()
            {
                new Ingredient()
                {
                    Amount = "1",
                    Name = "Carrot"
                },
                new Ingredient()
                {
                    Amount = "100ml",
                    Name = "Water"
                }
            };

            foreach (Recipe r in RecipeList)
            {
                foreach (Ingredient i in r.Ingredients)
                {
                    foreach (Product p in ProductList)
                    {
                        if (i.Name.ToLower() == p.ProductName.ToLower())
                        {
                            RecipeProducts.Add(r.ID, p.ExpiryDate);

                        }
                    }
                }
            }

            Recipe soup = new Recipe(1, "soup", "watter and carrots", "vegan", "", ingredients);

            RecipeProducts.Add(1, new DateTime(2022, 12, 1));
            RecipeProducts.Add(2, new DateTime(2022, 12, 2));

            DateTime expected = new DateTime(2022, 12, 1);

            DateTime minDate = (DateTime)RecipeHandler.GetMinExpiryDate(soup);

            Assert.Equal(expected, minDate);

            */
        }

    }
}
