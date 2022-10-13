using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    internal static class ProfuctPrefabs
    {
        public static BakedGoods CreateBakedGoods(Product product)
        {
            return (BakedGoods)product;
        }
    }
}
