using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static Func<double, double, double, bool> local_minimum = (a, b, c) => { return b < a && b < c; };

        public static void Solve()
        {
            Task("Array34");
            var l = GetEnumerableDouble().ToList();
            double loc_min = double.MinValue;

            if (l.Count < 2)
                return;

            loc_min = local_minimum(l[1], l[0], l[1]) ? l[0] : loc_min;
            loc_min = local_minimum(l[l.Count - 2], l[l.Count - 1], l[l.Count - 2]) ? Math.Max(l[l.Count - 1], loc_min) : loc_min;

            for (var i = 1; i < l.Count - 1; ++i) 
                loc_min = Math.Max(loc_min, local_minimum(l[i - 1], l[i], l[i + 1]) ? l[i] : double.MinValue);

            Put(loc_min);
        }
    }
}
