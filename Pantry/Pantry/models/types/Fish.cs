using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Fish : Product
    {
        public enum ESubType
        {
            SALMON,
            COD,
            TUNA,
            CARP,
            POLLOCK,

        }

        public ESubType SubType { get; set; }
        public Fish()
        {
            ProductType = ProductType.FISH;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
