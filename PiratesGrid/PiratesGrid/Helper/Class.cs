using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesGrid.Helper
{
    public static class StringHelper
    {
        public static string GiveUnderScoreIfEmpty(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "--";

            return s;
        }
    }
}
