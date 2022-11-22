﻿using Pantry.models;
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
        public Lazy<LazyIngrientsInitialization> lazy = new Lazy<LazyIngrientsInitialization>();
        private string selectedType = null;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        private IDataHandler dataHandler;
        public RecipePage()
        {
            dataHandler = DependencyService.Get<IDataHandler>(DependencyFetchTarget.GlobalInstance);

            List<Ingredient> list = new List<Ingredient>()
            {
                new Ingredient()
                {
                    Name = "bulve",
                    Amount = "200g"
                },

                new Ingredient()
                {
                    Name = "pienas",
                    Amount = "200ml"
                }
            };

            List<Ingredient> list2 = new List<Ingredient>()
            {
                new Ingredient()
                {
                    Name = "agurkas",
                    Amount = "200g"
                },

                new Ingredient()
                {
                    Name = "ananasas",
                    Amount = "200ml"
                }
            };

            InitializeComponent();
            RecipeHandler.RecipeList.Add(new Recipe() { ID = 1, Title = "Cheese sandwich", Description = "Spread 1/2 Tbsp of butter on one side of each slice of bread.\r\nSet a skillet over medium/low heat and place 2 slices of bread in the skillet with the butter-side-down.\r\nStack cheeses on one piece of toast: cheddar, havarti, then gouda. Once the breads are golden brown, closed the sandwich with the crisp sides on the outside.\r\nContinue cooking until the bread is a rich golden brown, flipping once and press down lightly to help the bread stick to the cheese. Total cooking time should one 5-6 minutes. Keep the heat on medium low for the breads to toast slowly, giving your cheese a chance to fully melt and adhere to the bread.", Type = "Vegetarian", ImageSource = "https://media.istockphoto.com/photos/close-up-shot-of-tomato-soup-with-a-grilled-cheese-sandwich-blue-and-picture-id898582260", Ingredients = list});
            RecipeHandler.RecipeList.Add(new Recipe() { ID = 2, Title = "hello", Description = "...", Type = "veg", ImageSource = null, Ingredients = list2 });

            RecipeHandler.RecipeList.CollectionChanged += Update;
            dataHandler.ProductUpdated += Update;

            Update(this, null);
        }

        string ingredients;
        public void OpenRecipeInfo(object sender, ItemTappedEventArgs e)
        {
            ingredients = null;
            foreach (var item in lazy.Value.Ingredients)
            {

                ingredients += item.Name + " " + item.Amount + ", ";
            }
            ingredients = ingredients.Remove(ingredients.Length - 2, 2);
            var recipe = e.Item as Recipe;

            Navigation.ShowPopup(new RecipeInfoPage(recipe.Title, ingredients, recipe.Description, recipe.ImageSource));

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
            catch (Exception ex)
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
                IEnumerable<Recipe> filteredByDate= from recipe in ordered
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