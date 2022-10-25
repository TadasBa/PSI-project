using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Nuts : Product
    {
        public enum ESubType
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

        public ESubType SubType { get; set; }
        public Nuts()
        {
            ProductType = ProductType.NUTS_AND_SEEDS;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
