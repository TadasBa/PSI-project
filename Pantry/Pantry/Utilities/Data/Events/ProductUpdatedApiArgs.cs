using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.Utilities.Data.Events
{
    internal class ProductUpdatedApiArgs : EventArgs
    {
        public ProductUpdatedApiArgs(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
