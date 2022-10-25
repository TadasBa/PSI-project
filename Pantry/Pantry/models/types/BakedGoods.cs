using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class BakedGoods : Product
    {
        public enum ESubType
        {
            PASTRY,
            BREAD
        }

        public ESubType SubType { get; set; }

        public BakedGoods()
        {
            ProductType = ProductType.BAKED_GOODS;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
