using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Vegetables : Product
    {
        public enum SubType
        {
            TOMATO,
            POTATO,
            CABBAGE,
            CARROT,
            ONION,
            BEETROOT,
            PUMPKIN,
            ZUCCHINI,
            TURNIP,
            LEEK,
            RADISH,
            LETTUCE,
            BELL_PEPPER
        }

        public SubType subType { get; set; }
        public Vegetables()
        {
            type = ProductType.VEGETABLES;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
