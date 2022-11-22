using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.models
{
    public class DictionaryWrapper : Dictionary<int, List<DateTime>>
    {
        private Dictionary<int, List<DateTime>> internalDictionary = new Dictionary<int, List<DateTime>>();

        public DictionaryWrapper(Dictionary<int, List<DateTime>> dictionary)
        {
            internalDictionary = dictionary;
        }

        public void Add(int key, DateTime value)
        {

            if (this.internalDictionary.ContainsKey(key))
            {

                List<DateTime> list = this.internalDictionary[key];
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<DateTime> list = new List<DateTime>();
                list.Add(value);
                this.internalDictionary.Add(key, list);
            }
        }
    }
}
