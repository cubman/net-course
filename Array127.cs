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
            Task("Array127");
            var L =  GetInt();
            var ls = GetEnumerableInt().ToList();

            int cnt = 0;
            List<int> li = new List<int>();
            while (cnt < ls.Count)
            {
                var l_ind = ls.FindIndex(cnt, x => x != ls[cnt]);
                if (l_ind == -1)
                    l_ind = ls.Count;

                if (l_ind - cnt > L) {
                    li.Add(0);
                    cnt = l_ind;
                }
                else 
                    li.Add(ls[cnt++]);
            }

            foreach (var x in li)
                Put(x);
        }
    }
}
