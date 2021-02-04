﻿using System.Collections.Generic;
using System.Linq;

namespace Dime.Scheduler.Sdk.Samples
{
    public class Filters<T> : List<Filter<T>>
    {
        public override string ToString()
        {
            string filtersString = string.Join(',', this.Select(x => x.ToString()));
            return $"[{filtersString}]";
        }
    }
}