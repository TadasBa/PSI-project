using Pantry.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry.pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.Extensions;

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        ObservableCollection<Recipe> recipeList = new ObservableCollection<Recipe>();
   
        public RecipePage()
        {
            InitializeComponent();

            List<Ingredient> ingredientList = new List<Ingredient>();

            ingredientList.Add(new Ingredient() { Amount = "200 g", Name = "Bread" });
            ingredientList.Add(new Ingredient() { Amount = "200 g", Name = "Cheese" });

            string ingredients = string.Join(", ", ingredientList);

            recipeList.Add(new Recipe() { Title = "Cheese sandwich", Ingredients = ingredients, Description = "Spread 1/2 Tbsp of butter on one side of each slice of bread.\r\nSet a skillet over medium/low heat and place 2 slices of bread in the skillet with the butter-side-down.\r\nStack cheeses on one piece of toast: cheddar, havarti, then gouda. Once the breads are golden brown, closed the sandwich with the crisp sides on the outside.\r\nContinue cooking until the bread is a rich golden brown, flipping once and press down lightly to help the bread stick to the cheese. Total cooking time should one 5-6 minutes. Keep the heat on medium low for the breads to toast slowly, giving your cheese a chance to fully melt and adhere to the bread.", Type = "Vegetarian", ImageSource = "https://media.istockphoto.com/photos/close-up-shot-of-tomato-soup-with-a-grilled-cheese-sandwich-blue-and-picture-id898582260" });
            
            recipeListView.ItemsSource = recipeList;
        }

        public void OpenRecipeInfo(object sender, ItemTappedEventArgs e)
        {
            var recipe = e.Item as  Recipe;
            Navigation.ShowPopup(new RecipeInfoPage(recipe.Title, recipe.Ingredients, recipe.Description, recipe.ImageSource));
           
            
            
        }
    }
}