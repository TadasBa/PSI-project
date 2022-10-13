using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Lugemes : Product
    {
        public enum SubType
        {
            BEANS,
            SOYBEANS,
            GREEN_PEAS,
            CHICK_PEAS
        }

        public SubType subType { get; set; }
        public Lugemes()
        {
            type = ProductType.LEGUMES;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
