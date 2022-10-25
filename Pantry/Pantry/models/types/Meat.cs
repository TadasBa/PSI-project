using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Meat : Product
    {
        public enum ESubType
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

        public ESubType SubType { get; set; }
        public Meat()
        {
            ProductType = ProductType.MEAT;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
