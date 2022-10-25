using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Drinks : Product
    {
        public enum ESubType
        {
            SODA,
            JUICE,
            COFFEE,
            TEA
        }

        public ESubType SubType { get; set; }
        public Drinks()
        {
            ProductType = ProductType.DRINKS;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
