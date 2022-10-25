using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Fruits : Product
    {
        public enum ESubType
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

        public ESubType SubType { get; set; }
        public Fruits()
        {
            ProductType = ProductType.FRUITS;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
