using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Vegetables : Product
    {
        public enum ESubType
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

        public ESubType SubType { get; set; }
        public Vegetables()
        {
            ProductType = ProductType.VEGETABLES;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
