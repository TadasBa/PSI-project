using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
  
    public class Recipe
    {
      public string title { get; set; }
      public List<Ingredient> ingredients { get; set; }
      public string description { get; set; }
      

    }
}