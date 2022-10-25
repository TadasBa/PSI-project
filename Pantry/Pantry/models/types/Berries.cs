using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Berries : Product
    {
        public enum ESubType
        {
            BLUEBERRY,
            STRAWBERRY,
            CRANBERRY,
            ELDERBERRY
        }

        public ESubType SubType { get; set; }
        public Berries()
        {
            ProductType = ProductType.BERRIES;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
