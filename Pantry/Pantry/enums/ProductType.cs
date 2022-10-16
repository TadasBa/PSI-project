using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pantry.models
{
    public enum ProductType
    {
        [Description("Baked goods")]
        BAKED_GOODS,

        [Description("Berries")]
        BERRIES,

        [Description("Dairy")]
        DAIRY,

        [Description("Drinks")]
        DRINKS,

        [Description("Eggs")]
        EGGS,

        [Description("Fruits")]
        FRUITS,

        [Description("Grains")]
        GRAINS,

        [Description("Legumes")]
        LEGUMES,

        [Description("Meat")]
        MEAT,

        [Description("Nuts and seeds")]
        NUTS_AND_SEEDS,

        [Description("Seafood")]
        SEAFOOD,

        [Description("Vegetables")]
        VEGETABLES,

        [Description("Fish")]
        FISH
    }
}