using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    public class BakedGoods : Product
    {
        public enum SubType
        {
            PASTRY,
            BREAD
        }

        public SubType subType { get; set; }

        public BakedGoods()
        {
            type = ProductType.BAKED_GOODS;
            imageSource = type.ToString().ToLower() + ".jpg";
        }
    }
}
