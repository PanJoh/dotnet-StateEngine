using System;
using System.Collections.Generic;
using System.Text;

namespace HdcDst.Utils
{
    public interface IEnterParameters
    {
        object this[string paramName] { get; }

        int Count { get; }

        IEnumerable<string> Keys { get; }

        bool ContainsKey(string paramName);

        void Add(string paramName, object value);

        T Get<T>(string paramName);

        bool TryGetValue<T>(string paramName, out T value);
    }
}
