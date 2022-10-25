using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models.types
{
    [Serializable]
    public class Legumes : Product
    {
        public enum ESubType
        {
            BEANS,
            SOYBEANS,
            GREEN_PEAS,
            CHICK_PEAS
        }

        public ESubType SubType { get; set; }
        public Legumes()
        {
            ProductType = ProductType.LEGUMES;
            ImageSource = ProductType.ToString().ToLower() + ".jpg";
        }
    }
}
