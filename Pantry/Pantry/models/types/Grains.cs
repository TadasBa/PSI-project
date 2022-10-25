using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Grains : Product
    {
        public enum ESubType
        {
            WHEAT,
            BARLEY,
            RYE,
            RICE,
            OATS,
            BUCKWHEAT
        }

        public ESubType DubType { get; set; }
        public Grains()
        {
            ProductType = ProductType.GRAINS;
            ImageSource = ProductType.ToString().ToLower() + ".png";
        }
    }
}
