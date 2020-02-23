using System;
using System.Collections.Generic;
using System.Text;

namespace HdcDst.Utils
{
    public class EnterParameters : IEnterParameters
    {
        private readonly IDictionary<string, object> paramMap;

        public object this[string paramName] => paramMap[paramName];

        public int Count => paramMap.Count;

        public IEnumerable<string> Keys => paramMap.Keys;

        public EnterParameters()
        {
            paramMap = new Dictionary<string, object>();
        }

        public EnterParameters(IDictionary<string, object> paramMap)
        {
            this.paramMap = paramMap ?? throw new ArgumentNullException(nameof(paramMap));
        }

        public void Add(string paramName, object value)
        {
            paramMap.Add(paramName, value);
        }

        public bool ContainsKey(string paramName)
        {
            return paramMap.ContainsKey(paramName);
        }

        public T Get<T>(string paramName)
        {
            return (T)paramMap[paramName];
        }

        public bool TryGetValue<T>(string paramName, out T value)
        {
            if(!paramMap.TryGetValue(paramName, out var obj))
            {
                value = default(T);
                return false;
            }

            if (!(obj is T))
            {
                value = default(T);
                return false;
            }

            value = (T)obj;
            return true;

        }
    }
}
