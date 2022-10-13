using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class Seafood : Product
    {
        public enum SubType
        {
            SQUID,
            CLAM,
            OYSTER,
            CRAB,
            LOBSTER,
            MUSSEL
        }

        public SubType subType { get; set; }
        public Seafood()
        {
            type = ProductType.SEAFOOD;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
