using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Array44");
            var l = GetEnumerableInt().ToList();
            var ind = -1;

            for (var i = 0; i < l.Count; ++i)
                if ((ind = l.FindLastIndex(x => x == l[i])) != i)
                {
                    Put(++i, ++ind);
                    return;
                }
        }
    }
}
