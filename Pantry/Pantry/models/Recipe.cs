using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace Pantry.models
{

    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        //public string Ingredients { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ImageSource { get; set; }

        public Recipe()
        {

        }

        public Recipe(int ID, string title, string description, string type, string imageSource, List<Ingredient> ingredients)
        {
            this.ID = ID;
            this.Title = title;
            this.Description = description;
            this.Type = type;
            this.ImageSource = imageSource;
            this.Ingredients = ingredients;
        }
    }


}
