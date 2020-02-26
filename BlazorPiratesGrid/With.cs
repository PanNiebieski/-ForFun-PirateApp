﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPiratesGrid
{
    public static class With
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
   => self.Select((item, index) => (item, index));
    }
}
