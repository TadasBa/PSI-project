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
            ingredientList.Add(new Ingredient(){ amount= 3, name= "Bread"});
            ingredientList.Add(new Ingredient(){ amount= 2, name= "Cheese"});

            recipeList.Add(new Recipe() { title = "Cheese sandwich", ingredients = ingredientList, description = "u dont need it" });
            InitializeComponent();
        }
    }
}