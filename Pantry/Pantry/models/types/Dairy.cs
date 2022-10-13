using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Dairy : Product
    {
        public enum SubType
        {
            MILK,
            CHEESE,
            BUTTER,
            YOGURT
        }

        public SubType subType { get; set; }
        public Dairy()
        {
            type = ProductType.DAIRY;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
