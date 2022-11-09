using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.Utilities.Data.Events
{
    internal class ProductUpdatedFileArgs : EventArgs
    {
        public ProductUpdatedFileArgs(string path)
        {
            Path = path;
        }
        public string Path { get; set; }
    }
}
