using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Drinks : Product
    {
        public enum SubType
        {
            SODA,
            JUICE,
            COFFEE,
            TEA
        }

        public SubType subType { get; set; }
        public Drinks()
        {
            type = ProductType.DRINKS;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
