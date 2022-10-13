using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Grains : Product
    {
        public enum SubType
        {
            WHEAT,
            BARLEY,
            RYE,
            RICE,
            OATS,
            BUCKWHEAT

        }

        public SubType subType { get; set; }
        public Grains()
        {
            type = ProductType.GRAINS;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
