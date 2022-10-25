using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Seafood : Product
    {
        public enum ESubType
        {
            SQUID,
            CLAM,
            OYSTER,
            CRAB,
            LOBSTER,
            MUSSEL
        }

        public ESubType SubType { get; set; }
        public Seafood()
        {
            ProductType = ProductType.SEAFOOD;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
