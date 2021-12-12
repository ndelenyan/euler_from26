using System;
using System.Collections.Generic;
using System.Text;

namespace euler_from26
{
    public static class MyCollections
    {
        public static string Print(IEnumerable<int> t)
        {
            var SB = new StringBuilder();
            SB.Append("{");
            foreach (var tt in t)
                SB.Append($" {tt}");
            SB.Append(" }");
            return SB.ToString();
        }
    }
}