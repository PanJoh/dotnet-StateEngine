using System;
using System.Collections.Generic;
using System.Text;

namespace HdcDst.Utils
{
    public static class Extensions
    {
        public static IEnterParameters ToEnterParameters(this IDictionary<string, object> paramMap)
        {
            return new EnterParameters(paramMap);
        }
    }
}
