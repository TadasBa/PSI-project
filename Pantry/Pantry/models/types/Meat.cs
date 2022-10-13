using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Meat : Product
    {
        public enum SubType
        {
            CHICKEN,
            BEEF,
            PORK,
            LAMB,
            DUCK,
            VEAL,
            TURKEY,
            RABBIT
        }

        public SubType subType { get; set; }
        public Meat()
        {
            type = ProductType.MEAT;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
