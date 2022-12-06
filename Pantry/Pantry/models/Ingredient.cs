using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public class Ingredient
    {
        public int Owner { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }

        public override string ToString() =>
        $"{Name} {Amount}";
    }
}
