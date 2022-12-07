using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public class RecipeDictionary : Dictionary<int, List<DateTime>>
    {
        public void Add(int key, DateTime value)
        {

            if (this.ContainsKey(key))
            {

                List<DateTime> list = this[key];
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<DateTime> list = new List<DateTime>();
                list.Add(value);
                this.Add(key, list);
            }
        }
    }
}
