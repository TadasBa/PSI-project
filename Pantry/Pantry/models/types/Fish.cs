using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Fish : Product
    {
        public enum SubType
        {
            SALMON,
            COD,
            TUNA,
            CARP,
            POLLOCK,

        }

        public SubType subType { get; set; }
        public Fish()
        {
            type = ProductType.FISH;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
