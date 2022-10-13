using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Berries : Product
    {
        public enum SubType
        {
            BLUEBERRY,
            STRAWBERRY,
            CRANBERRY,
            ELDERBERRY
        }

        public SubType subType { get; set; }
        public Berries()
        {
            type = ProductType.BERRIES;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
