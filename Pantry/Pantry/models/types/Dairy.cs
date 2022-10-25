using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Dairy : Product
    {
        public enum ESubType
        {
            MILK,
            CHEESE,
            BUTTER,
            YOGURT
        }

        public ESubType SubType { get; set; }
        public Dairy()
        {
            ProductType = ProductType.DAIRY;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
