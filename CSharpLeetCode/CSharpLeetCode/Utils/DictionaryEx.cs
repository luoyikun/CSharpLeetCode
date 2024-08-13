using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Utils
{
    public class DictionaryEx<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey indexKey]
        {
            set {
                if (this.ContainsKey(indexKey) == false)
                {
                    base.Add(indexKey, value);
                }
                else
                {
                    base[indexKey] = value;
                }
            }
            get
            {
                try
                {
                    return base[indexKey];
                }
                catch (Exception)
                {
                    return default(TValue);
                }
            }
        }
    }
}
