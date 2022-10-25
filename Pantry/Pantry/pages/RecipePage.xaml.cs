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

namespace Pantry.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        ObservableCollection<Recipe> recipeList = new ObservableCollection<Recipe>();
        public RecipePage()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();
            ingredientList.Add(new Ingredient(){ Amount= 3, Name= "Bread"});
            ingredientList.Add(new Ingredient(){ Amount= 2, Name= "Cheese"});

            recipeList.Add(new Recipe() { Title = "Cheese sandwich", Ingredients = ingredientList, Description = "u dont need it" });
            InitializeComponent();
        }
    }
}