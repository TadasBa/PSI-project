using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Eggs : Product
    {
        public enum ESubType
        {
            CHICKEN,
            GOOSE,
            QUAIL,
            PHEASANT,
            TURKEY
        }

        public ESubType SubType { get; set; }
        public Eggs()
        {
            ProductType = ProductType.EGGS;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}