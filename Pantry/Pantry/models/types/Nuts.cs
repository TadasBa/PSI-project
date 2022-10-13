using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Nuts : Product
    {
        public enum SubType
        {
            ALMOND,
            HAZELNUT,
            CASHHEW,
            PEANUT,
            PISTACHIO,
            CHESTNUT,
            WALNUT,
            COCONUT
        }

        public SubType subType { get; set; }
        public Nuts()
        {
            type = ProductType.NUTS_AND_SEEDS;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
