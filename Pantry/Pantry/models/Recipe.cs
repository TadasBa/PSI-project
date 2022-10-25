using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
  
    public class Recipe
    {
      public string Title { get; set; }
      public List<Ingredient> Ingredients { get; set; }
      public string Description { get; set; }
      

    }
}