using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Fruits : Product
    {
        public enum SubType
        {
            APPLE,
            PAIR,
            MELON,
            WATERMELON,
            ORANGE,
            GRAPEFRUT,
            BANANA,
            MANGO
        }

        public SubType subType { get; set; }
        public Fruits()
        {
            type = ProductType.FRUITS;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
