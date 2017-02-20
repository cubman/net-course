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
            Task("Array100");

            var l  = GetEnumerableInt().ToList();
            int cnt = 0;

            while (cnt < l.Count)
                if (l.FindAll(x => x == l[cnt]).Count == 2)
                {
                    var c = l[cnt];
                    l.RemoveAll(x => x == c);
                }
                else
                    ++cnt;

            Put(cnt);

            foreach (var x in l)
                Put(x);
        }
    }
}
