using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Pantry.Utilities;
using Android.OS;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {

        private string selectedType = null;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        private IDataHandler<EventArgs> dataHandler;
        public Command TappedItem { get; }

        public RecipePage()
        {
            dataHandler = DependencyService.Get<IDataHandler<EventArgs>>(DependencyFetchTarget.GlobalInstance);
            var products = dataHandler.ProductList.GetAll();

            TappedItem = new Command((object s) =>
            {
                // string ingredients = null;
                // foreach (var item in WithLazy.Instance.Ingredients)
                // {
                //     ingredients += item.Name + " " + item.Amount + ", ";
                // }
                // var description = WithLazy.Instance.Description;

                // ingredients = ingredients.Remove(ingredients.Length - 2, 2);

                var recipe = (Recipe)s;
                string ingredients = null;
                ingredients = string.Join(", ", recipe.Ingredients);


                Navigation.ShowPopup(new RecipeInfoPage(recipe.Title, ingredients, recipe.Description, recipe.ImageSource));
            });



            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 1,
=======
                Id = 1,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Cheese sandwich",
                Description = "Spread 1/2 Tbsp of butter on one side of each slice of bread.\r\nSet a skillet over medium/low heat and place 2 slices of bread in the skillet with the butter-side-down.\r\nStack cheeses on one piece of toast: cheddar, havarti, then gouda. Once the breads are golden brown, closed the sandwich with the crisp sides on the outside.\r\nContinue cooking until the bread is a rich golden brown, flipping once and press down lightly to help the bread stick to the cheese. Total cooking time should one 5-6 minutes. Keep the heat on medium low for the breads to toast slowly, giving your cheese a chance to fully melt and adhere to the bread.",
                Type = "Vegetarian",
                ImageSource = "https://media.istockphoto.com/photos/close-up-shot-of-tomato-soup-with-a-grilled-cheese-sandwich-blue-and-picture-id898582260",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Bread", Amount = "4 slices" }, new Ingredient() { Name = "Cheese", Amount = "200 g" } }
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 2,
=======
                Id = 2,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Apple-Cranberry Crostada",
                Description = "Heat butter in a large skillet over medium-high heat. Add apples, sugar and cranberries; cover and cook until apples release their liquid, about 5 minutes. Remove lid and continue to cook, stirring frequently, until soft apples fall apart and juices thicken to a thin-syrup consistency, about 5 minutes longer. Pour onto a large-lipped cookie sheet or jellyroll pan and cool to room temperature. (Can be refrigerated in an airtight container up to 5 days.)\r\nAdjust oven rack to low position and heat oven to 400 degrees. Open puff pastry sheet on a lightly floured work surface. Roll into a rectangle, about 10 by 16 inches. Transfer to a large cookie sheet. (I suggest lining the sheet with parchment paper; this ensures the crostada doesn't stick and allows easy cleanup.)\r\nSpread cooked apples over pastry, leaving a 2-inch border. Fold up pastry borders over apples. Unfold corners and form ruffled creases to keep dough from overlapping. Brush pastry border with egg white and sprinkle with the remaining 1 Tb. sugar. Bake until pastry is golden brown, 25 to 30 minutes. Serve warm or at room temperature with optional ice cream or whipped cream.\r\n",
                Type = "Dessert",
                ImageSource = "https://www.allrecipes.com/thmb/IA7OA82bnZnZ8V9CQKIHjtFn29M=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/369214-very-chocolate-ice-cream-Melissa-Goff-4x3-1-1dab9af6809244b19d0f8ec8e3986a48.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Butter", Amount = "" +
                "3 tablespoons" }, new Ingredient() { Name = "Apples", Amount = "3 pounds" }, new Ingredient() { Name = "Cranberries", Amount = "Half cup" }, new Ingredient() { Name = "Frozen pastry", Amount = "1 sheet" }, new Ingredient() { Name = "Egg", Amount = "1" } }
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 3,
=======
                Id = 3,
                Title = "Sweet Potato Wedges",
                Description = "1.\tPreheat an oven to 450 degrees F (230 degrees C). Grease a baking sheet and line with oil.\r\n2.\tCut sweet potatoes (unpeeled) into 1/2-inch wedges and arrange on the prepared baking sheet in a single layer. Drizzle with oil and season with salt and pepper.\r\n3.\tRoast, stirring halfway through, until browned and tender, about 30 minutes. Transfer to a large bowl.\r\n4.\tMeanwhile, heat butter in a small skillet over medium heat until melted and golden brown, about 5 minutes. Stir in rosemary and orange zest. Pour over sweet potato wedges and toss to coat.\r\n",
                Type = "Vegetarian",
                ImageSource = "https://www.allrecipes.com/thmb/_UUcgLKtDM2Dc9yYI2nB3CpBu6Q=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/KH_012422_AR3920-4x3-1-6ce9aaca3609422b906f2220ef372988.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Potato", Amount = "4" }, new Ingredient() { Name = "Olive oil", Amount = "1 tablespoon" }, new Ingredient() { Name = "Butter", Amount = "2 tablespoons" }, new Ingredient() { Name = "Rosemary", Amount = "2 teaspoons, finely chopped" } }
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
                Id = 4,
                Title = "Caramel Apples",
                Description = "1.\tRemove the stem from each apple and press a craft stick into the top. Spray a baking sheet with cooking spray.\r\n2.\tPlace caramels and milk in a microwave-safe bowl; microwave for 2 minutes, stirring once. Set aside to cool briefly.\r\n3.\tRoll each apple quickly in caramel sauce until well coated. Place on prepared sheet to set.\r\n",
                Type = "Fruits",
                ImageSource = "https://www.allrecipes.com/thmb/LT6141ASeoi-uKJzM-aLepN9RY0=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/481786-6c24ca3a641f43eea1597930a40b6178.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Apple", Amount = "6" }, new Ingredient() { Name = "Caramel", Amount = "14 ounce" }, new Ingredient() { Name = "Milk", Amount = "2 tablespoons" } },
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
                Id = 5,
                Title = "Maple Salmon",
                Description = "1.\tStir maple syrup, soy sauce, garlic, garlic salt, and pepper together in a small bowl.\r\n2.\tCut salmon into 4 equal-sized fillets; place in a shallow glass baking dish and coat with maple syrup mixture. Cover the dish and marinate salmon in the refrigerator for 30 minutes, turning once halfway.\r\n3.\tPreheat the oven to 400 degrees F (200 degrees C).\r\n4.\tPlace the baking dish in the preheated oven and bake salmon uncovered until flesh easily flakes with a fork, about 20 minutes.\r\n",
                Type = "Seafood",
                ImageSource = "https://www.allrecipes.com/thmb/jaXQ9LIKIDQ1w9I8eJa4Xm_eZoE=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/862371-cd7a4b6c481f444382e3f69273b982f9.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Maple syrup", Amount = "1/4 cup" }, new Ingredient() { Name = "Soy sauce", Amount = "2 tablespoons" }, new Ingredient() { Name = "Salmon", Amount = "1 pound" } },
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
                Id = 6,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Sable Cookies",
                Description = "1.\tPulse flour, powdered sugar, and salt together in a food processor until just combined, about 5 times. Add butter to processor, and pulse until mixture is crumbly, about 12 times. Add egg yolks and vanilla, and process until dough begins to clump together, about 30 seconds. Shape dough into a disc about 1 inch thick; wrap in plastic wrap, and refrigerate until firm, at least 30 minutes or up to 2 days.\r\n2.\tPreheat oven to 350 degrees F (175 degrees C). Position racks in the upper and lower thirds of oven. Line 2 baking sheets with parchment paper.\r\n3.\tRoll out dough on a floured surface to 1/4-inch thickness. Using a 2 1/2-inch fluted, round cookie cutter, cut as many cookies as you can from dough. Re-roll dough as needed. Place cookies 1 1/2 inches apart on the prepared pans.\r\n4.\tStir 1 teaspoon water and egg white together in a small bowl until combined. Lightly brush over cookies, and sprinkle generously with sanding sugar.\r\n5.\tBake in the preheated oven in upper and lower thirds, 2 baking sheets at a time, rotating top to bottom and bottom to top, halfway through, until set and lightly golden around edges, 12 to 14 minutes. Let cool completely on baking sheets, about 15 minutes. \r\n\r\n",
                Type = "Dessert",
                ImageSource = "https://www.allrecipes.com/thmb/0zeoDi7c9G4nQl9aFkSSG_qs5ZM=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/sable-cookies-ddmfs-1288-4x3-1-67e9ecb57cab49c8ad9887c998e356e4.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "All-purpose flour", Amount = "" +
                "2 cups" }, new Ingredient() { Name = "Powdered sugar", Amount = "0,75 cup" }, new Ingredient() { Name = "Fine sea salt", Amount = "Half teaspoon" }, new Ingredient() { Name = "Cold unsalted butter", Amount = "0,75 cup" }, new Ingredient() { Name = "Egg yolks", Amount = "2" }, new Ingredient() { Name = "Vanilla extract", Amount = "1 teaspoon" }, new Ingredient() { Name = "Water", Amount = "1 teaspoon" }, new Ingredient() { Name = "Egg white", Amount = "1" }, new Ingredient() { Name = "Sanding sugar", Amount = "" } }
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 4,
=======
                Id = 7,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Chocolate Ice Cream",
                Description = "1.\tCombine milk, sugar, cocoa powder, and salt in a saucepan over medium heat. Bring to a simmer, stirring constantly.\r\n2.\tPlace egg yolks into a small bowl. Gradually whisk in about 1/2 cup of hot milk mixture, then return to the saucepan. Heat and stir until thickened, but do not boil.\r\n3.\tRemove from the heat and stir in chopped chocolate until melted.\r\n4.\tPour into a chilled bowl and refrigerate, stirring occasionally, until cold, about 2 hours.\r\n5.\tStir in cream and vanilla. Pour into an ice cream maker and freeze according to manufacturer's directions.\r\n",
                Type = "Dessert",
                ImageSource = "https://www.allrecipes.com/thmb/IA7OA82bnZnZ8V9CQKIHjtFn29M=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/369214-very-chocolate-ice-cream-Melissa-Goff-4x3-1-1dab9af6809244b19d0f8ec8e3986a48.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Milk", Amount = "" +
                "1 cup" }, new Ingredient() { Name = "Sugar", Amount = "0,75 cup" }, new Ingredient() { Name = "Unsweetened cocoa powder", Amount = "2 teaspoons" }, new Ingredient() { Name = "Salt", Amount = "0,25 teaspoon" }, new Ingredient() { Name = "Egg yolks", Amount = "3" }, new Ingredient() { Name = "Semisweet chocolate", Amount = "2 ounces" }, new Ingredient() { Name = "Heavy cream", Amount = "2 cups" }, new Ingredient() { Name = "vanilla extract", Amount = "1 teaspoon" }}
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 5,
=======
                Id = 8,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Vegan kale pesto pasta",
                Description = "STEP 1\r\nBring a pan of water to the boil. Cook the kale for 30 secs, drain and transfer to a bowl of ice-cold water for 5 mins. Drain again and pat dry with kitchen paper.\r\n\r\nSTEP 2\r\nPut the basil, garlic, seeds, oil, nutritional yeast, lemon juice and zest, and drained kale in a food processor. Blitz until smooth, then season. Loosen with a splash of water, if it’s too thick.\r\n\r\nSTEP 3\r\nCook the pasta following pack instructions, then toss with the pesto and serve.\r\n",
                Type = "Vegan",
                ImageSource = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/Kale-Pesto-df3faaf.jpg?quality=90&webp=true&resize=375,341",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Kale", Amount = "" +
                "150 g" }, new Ingredient() { Name = "Basil", Amount = "Small bunch" }, new Ingredient() { Name = "Garlic clove", Amount = "1 small" }, new Ingredient() { Name = "Pumpkin seeds", Amount = "3 teaspoon" }, new Ingredient() { Name = "Extra virgin olive oil", Amount = "5 tablespoons" }, new Ingredient() { Name = "Nutritional yeast", Amount = "3 tablespoon" }, new Ingredient() { Name = "Lemon juice", Amount = "1 lemon" }, new Ingredient() { Name = "wholemeal spaghetii", Amount = "350 g" }}
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 6,
=======
                Id = 9,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Vegan Pizza",
                Description = "1.\tPreheat the oven to 450°F.\r\n2.\tIn a medium bowl, combine the broccoli, tomatoes, corn, onion, jalapeño, and sun-dried tomatoes and drizzle with olive oil and pinches of salt and pepper. Toss to coat and taste. The vegetables should be well-seasoned and well-coated with the olive oil so that the vegetables are flavorful throughout the pizza.\r\n3.\tStretch the pizza dough onto a 14-inch pizza pan. Brush the outer edges of the dough lightly with olive oil and spoon a few scoops of cashew cream onto the center of the dough, just enough to spread it into a thin layer. Distribute the vegetables onto the dough.\r\n4.\tBake 15 minutes, or until the crust is golden, cooked through, and the broccoli is tender and roasted. Remove from the oven and drizzle generously with the cashew cream (if your cashew cream is too thick to drizzle, stir in a little water). Top with the fresh basil, fresh thyme, and pinches of red pepper flakes.\r\n",
                Type = "Vegan",
                ImageSource = "https://cdn.loveandlemons.com/wp-content/uploads/2018/09/vegan-pizza-719x1024.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Small head broccoli", Amount = "" +
                "1" }, new Ingredient() { Name = "Halved cherry tomatoes", Amount = "0,3 cup" }, new Ingredient() { Name = "Kernels from freash corn", Amount = "1 corn" }, new Ingredient() { Name = "Red onion", Amount = "0,25" }, new Ingredient() { Name = "Jalapeno", Amount = "0,5" }, new Ingredient() { Name = "oil-packed sun-dried tomatoes", Amount = "4" }, new Ingredient() { Name = "Extra-virgin olive oil", Amount = "4 tablespoons" }, new Ingredient() { Name = "pizza dough", Amount = "16 ounces" }, new Ingredient() { Name = "basil leaves", Amount = "0.5 cup" }, new Ingredient() { Name = "Thyme leaves", Amount = "2 tablespoons" }, new Ingredient() { Name = "Red pepper flakes", Amount = "1 pinch" }, new Ingredient() { Name = "sea salt and freshly grounded black pepper", Amount = "1 pinch" }, new Ingredient() { Name = "Cashew cream", Amount = "5 tablespoons" }}
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 7,
=======
                Id = 10,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Gnocchi with mushrooms & blue cheese",
                Description = "STEP 1\r\nBring a large pan of water to the boil and cook the gnocchi following pack instructions. When they float to the top of the pan, they are ready. Drain and set aside.\r\n\r\nSTEP 2\r\nMeanwhile, heat the oil and butter in a large lidded frying pan. Add the onion and mushrooms, cook for 1 min over a high heat, then turn down the heat to medium, put the lid on and cook for 5 mins, stirring a few times.\r\n\r\nSTEP 3\r\nRemove the lid and add the garlic, cook for 1-2 mins, then stir the gnocchi into the pan. Scatter over blobs of cheese and the parsley.\r\n",
                Type = "Vegetarian",
                ImageSource = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/gnocchi-with-mushrooms-ef4cba5.jpg?quality=90&webp=true&resize=440,400",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "gnocchi", Amount = "" +
                "800g" }, new Ingredient() { Name = "Olive oil", Amount = "1 tablespoon" }, new Ingredient() { Name = "Butter", Amount = "1 knob" }, new Ingredient() { Name = "Onion", Amount = "1" }, new Ingredient() { Name = "Forestière or Portobello mushrooms", Amount = "500g" }, new Ingredient() { Name = "Garlic cloves", Amount = "2" }, new Ingredient() { Name = "Creamy blue cheese", Amount = "150g" }, new Ingredient() { Name = "Parsley", Amount = "1 small pack" }}
            });
            RecipeHandler.RecipeList.Add(new Recipe()
            {
<<<<<<< HEAD
                ID = 8,
=======
                Id = 11,
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e
                Title = "Juicy Roasted Chicken",
                Description = "Preheat the oven to 350 degrees F (175 degrees C).\r\n\r\nPlace chicken in a roasting pan; season generously inside and out with onion powder, salt, and pepper. Place 3 tablespoons of butter in chicken cavity; arrange dollops of remaining butter on the outside of chicken. Cut celery into 3 or 4 pieces; place in the chicken cavity.\r\n\r\nBake chicken uncovered in the preheated oven until no longer pink at the bone and the juices run clear, about 1 hour and 15 minutes. An instant-read thermometer inserted into the thickest part of the thigh, near the bone, should read 165 degrees F (74 degrees C).\r\n\r\nRemove from the oven and baste with drippings. Cover with aluminum foil and allow to rest for about 30 minutes before serving.\r\n",
                Type = "Meat",
                ImageSource = "https://www.allrecipes.com/thmb/ZNARl52mibyF1XHwwIb5A1czmkY=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/83557-juicy-roast-chicken-mfs495-1-3d0f1e3e54104d43b24d4b480d2839ba.jpg",
                Ingredients = new List<Ingredient> { new Ingredient() { Name = "Whole chicken", Amount = "" +
<<<<<<< HEAD
                "3 pounds" }, new Ingredient() { Name = "Salt and black pepper", Amount = "Deppending on taste" }, new Ingredient() { Name = "Onion powder", Amount = "1 tablespoon" }, new Ingredient() { Name = "Butter or margarine", Amount = "0,5 cup" }, new Ingredient() { Name = "Celery", Amount = "1" }}
            });
=======
                "3 pounds" }, new Ingredient() { Name = "Onion powder", Amount = "1 tablespoon" }, new Ingredient() { Name = "Butter or margarine", Amount = "0,5 cup" }, new Ingredient() { Name = "Celery", Amount = "1" }}
            });

            RecipeHandler.SetTypes();
>>>>>>> a68378e41ff6f10bfaeca2b700d11361f24b675e

            InitializeComponent();
            BindingContext = this;
            RecipeHandler.RecipeList.CollectionChanged += Update;
            dataHandler.ProductUpdated += Update;
            Update(this, null);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update(this, null);
        }

        private async void BtnRecipeFilter(object sender, EventArgs e)
        {
            try
            {
                List<object> items = (List<object>)await Navigation.ShowPopupAsync(new RecipeFilterPage(selectedType, startDate, endDate));
                selectedType = (string)items[0];
                startDate = (DateTime?)items[1];
                endDate = (DateTime?)items[2];
                Update(this, null);
            }
            catch (NullReferenceException ex)
            {
                ExceptionLogger.LogExceptionToFile(ex, "Data from RecipeFilterPage could not be trasferred");
            }
        }

        public void Update(object sender, EventArgs args)
        {
            RecipeHandler.SetProductsForRecipes();

            IEnumerable<Recipe> ordered = from recipe in RecipeHandler.RecipeList
                                          where recipe.Title.ToLower().StartsWith(SearchFilter.Text)
                                          orderby RecipeHandler.GetMinExpiryDate(recipe)
                                          select recipe;


            if (selectedType != null && startDate != null && endDate != null)
            {
                IEnumerable<Recipe> filteredByDateAndType = from recipe in ordered
                                                            where recipe.Type == selectedType
                                                                && RecipeHandler.GetMinExpiryDate(recipe) >= startDate
                                                                && RecipeHandler.GetMaxExpiryDate(recipe) <= endDate
                                                            select recipe;

                recipeCollectionView.ItemsSource = filteredByDateAndType;

            }
            else if (selectedType != null)
            {
                IEnumerable<Recipe> filteredByType = from recipe in ordered
                                                     where recipe.Type == selectedType
                                                     select recipe;

                recipeCollectionView.ItemsSource = filteredByType;

            }
            else if (startDate != null && endDate != null)
            {
                IEnumerable<Recipe> filteredByDate = from recipe in ordered
                                                     where RecipeHandler.GetMinExpiryDate(recipe) >= startDate
                                                         && RecipeHandler.GetMaxExpiryDate(recipe) <= endDate
                                                     select recipe;

                recipeCollectionView.ItemsSource = filteredByDate;


            }
            else
            {
                recipeCollectionView.ItemsSource = ordered;
            }
        }
    }
}
