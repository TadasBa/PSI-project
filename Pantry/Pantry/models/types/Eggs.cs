using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Eggs : Product
    {
        public enum SubType
        {
            CHICKEN,
            GOOSE,
            QUAIL,
            PHEASANT,
            TURKEY
        }

        public SubType subType { get; set; }
        public Eggs()
        {
            type = ProductType.EGGS;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}